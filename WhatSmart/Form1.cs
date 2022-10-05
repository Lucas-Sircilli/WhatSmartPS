using Microsoft.Edge.SeleniumTools;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WhatSmart.Objetos;

namespace WhatSmart
{
    public partial class Form1 : Form
    {
        public List<ObjContato> contatos;
        private ContatoEtapa objcontatoetapa = new ContatoEtapa();
        public Form1()
        {
            InitializeComponent();

            this.Resize += new System.EventHandler(this.Form_Resize);
            webView.NavigationStarting += EnsureHttpsStarting;
            webView.NavigationCompleted += EnsureHttpsCompleteAsync;

            if (File.Exists(@".//Token.txt"))
            {
                txtToken.Text = File.ReadAllText(@".//Token.txt");
            }
            //InitializeAsync();
        }



        bool isMessage = false;
        bool isSistemaConectado = false;
        void EnsureHttpsStarting(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;

            if (uri.Contains("send?phone"))
            {
                isMessage = true;
            }
            else isMessage = false;
        }

        void EnsureHttpsCompleteAsync(object sender, CoreWebView2NavigationCompletedEventArgs args)
        {

            if (args.IsSuccess)
            {
                if (string.IsNullOrEmpty(urlAtual))
                {
                    webView.EnsureCoreWebView2Async(null);
                    webView.CoreWebView2.WebMessageReceived += UpdateAddressBar;
                    btnIniciarConexao.Enabled = true;
                    txtToken.Enabled = true;


                    // webView.CoreWebView2.OpenDevToolsWindow();
                }
                else if (urlAtual.Contains("whatsapp"))
                {
                    InitializeAsync();
                }
            }
            else
            {

            }
        }

        public async Task clicarEnvioMensagem()
        {
            // await Task.Delay(TimeSpan.FromSeconds(10));
            //webView.CoreWebView2.ExecuteScriptAsync("function clickMessage(){if (document.querySelector('button._1U1xa') == undefined) setTimeout(clickMessage, 500); else document.querySelector('button._1U1xa').click(); } setTimeout(clickMessage, 500);");
            webView.CoreWebView2.ExecuteScriptAsync("openChat('" + txtNumero.Text + "', '" + HttpUtility.UrlEncode(txtMsg.Text) + "')");

        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);

        }

        bool scriptInicializado = false;


        async void InitializeAsync()
        {
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");

            // Comando de enviar mensagem via link de envio

            /*var comandoEnvio = "function openChat(phone, texto) { " +
                    "const link = document.createElement('a');  " +
                    "link.setAttribute('href', `whatsapp://send?phone=${phone}&text=${texto}`); " +
                    "document.body.append(link); " +
                    "link.click(); " +
                    "document.body.removeChild(link); " +
                    " setTimeout(function(){document.querySelectorAll('[data-icon=\"send\"]')[0].parentElement.click();}, 1000);" +
                 "}; ";
            await webView.CoreWebView2.ExecuteScriptAsync(comandoEnvio);

            var comandoVerificaConexao = "function VerificaConexao(){" +
                "if(document.getElementsByTagName('h1')[0].outerText.indexOf('Mantenha seu celular conectado')!=-1)" +
                "{window.chrome.webview.postMessage('SistemaConectado');" +
                "}else{window.chrome.webview.postMessage('SistemacccccConectado');}};";
            await webView.CoreWebView2.ExecuteScriptAsync(comandoVerificaConexao);*/

            var script = File.ReadAllText(@".//ScriptLeitura.js");
            await webView.CoreWebView2.ExecuteScriptAsync(script);
            scriptInicializado = true;
            timer1.Start();

        }

        string urlAtual = "";
        void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            String uri = args.TryGetWebMessageAsString();
            webView.CoreWebView2.PostWebMessageAsString(uri);

            if (uri.Contains("SistemaConectado"))
            {
                isSistemaConectado = true;
            }
            else if (uri.Contains("gvdsolucoes"))
            {

            }
            else if (uri.Contains("whatsapp"))
            {
                urlAtual = uri;
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clicarEnvioMensagem();
        }

        public async Task<bool> iniciaNavegador()
        {
            try
            {



            }
            catch (Exception ex)
            {

            }
            return true;
        }

        int contadorConexao = 0;

        public async Task<bool> VerificaClickSend()
        {
            var clicousend = false;
            var agora = DateTime.Now;
            while (!clicousend && (DateTime.Now-agora).TotalSeconds<5)
            {
                try
                {
                    var task = await webView.CoreWebView2.ExecuteScriptAsync("VerificaClickBotaoSend()");
                    if (task == "\"true\"")
                        clicousend = true;
                    else Thread.Sleep(100);
                }
                catch (Exception ez)
                {
                    var dd = ez.Message;
                    MessageBox.Show(dd);
                    Thread.Sleep(100);
                }
            }

            if(clicousend)
                return true;
            return false;
        }

       
        private async Task<bool> timer1_tickasync()
        {
            try
            {
                if (!isSistemaConectado && contadorConexao < 40)
                {
                    contadorConexao++;
                    var comandoVerificaConexao = "VerificaConexao()";
                    webView.CoreWebView2.ExecuteScriptAsync(comandoVerificaConexao);
                }
                else if (!isSistemaConectado && contadorConexao >= 10)
                {
                    //timer1.Stop();

                    //MessageBox.Show("FALHA NA CONEXÃO VERIFICAR");
                    //   contadorConexao = 0;
                    //  InitializeAsync();
                }
                else
                {
                    tbMensagensWhatsapp msg = null; // GetProximaMensagem();
                    if (msg != null && msg.IdMensagemWhatsapp > 0)
                    {
                        var mensagem = HttpUtility.UrlEncode(InsereEmoticons(msg.Mensagem));
                        var rr = mensagem;
                        TimeSpan diffResult = DateTime.Now.Subtract(msg.DataCadastro.Value);
                        if (diffResult.TotalMinutes > 30)
                        {
                            DefineComoEnviada(msg);
                        }
                        /* Mensagem  */
                        await webView.CoreWebView2.ExecuteScriptAsync("openChat('" + msg.Telefone + "', '" + rr + "')");
                        if(await VerificaClickSend())
                            DefineComoEnviada(msg);
                    }

                    if (contatos != null && contatos.Count > 0)
                    {
                        timer1.Stop();
                        foreach (var item in contatos)
                        {
                            //Está Retornando o mesmo telefone
                            if (item.Telefone.Length <= 16)
                            {
                                
                              var telefone =  await webView.CoreWebView2.ExecuteScriptAsync("document.querySelectorAll('h1')[0].innerText");
                             
                                var espaco = "%0a";
                                    var texto = "Olá " + item.Nome + ", Boa tarde! " +
                                     "Meu nome é Yudi, sou assistente virtual da YouDelivery! Seja bem vindo(a) ao nosso canal! Por aqui você encontra tudo sobre a YouDelivery" +
                                     "através de uma simples conversa no Whatsapp." + espaco + espaco + " Digite uma das opções abaixo:" + espaco + "(Somente o número)" + espaco +
                                     espaco + "1 - [E7] Quem somos" +
                                     espaco + "2 - [E4] Nossas soluções" +
                                     espaco + "3 - [E1] Quero Pedir" +
                                     espaco + "4 - [E9] Suporte " + espaco + espaco +
                                    "Para finalizar esse atendimento digite Sair " + espaco;


                                await webView.CoreWebView2.ExecuteScriptAsync("openChat('" + item.Telefone + "', '" + InsereEmoticons(texto) + "')");
                                
                                await VerificaClickSend();
                                
                            }
                        }
                        contatos.Clear(); contatos = null;
                    }

                    timer1.Stop();
                     var script = File.ReadAllText(@".//ScriptLeitura.js");
                     webView.CoreWebView2.ExecuteScriptAsync(script);
                    await webView.CoreWebView2.ExecuteScriptAsync("GetNovasMensagens()");


                    var achou = false;

                    while (achou == false)
                    {
                        try
                        {
                            var task = await webView.CoreWebView2.ExecuteScriptAsync("IsProcessando()");
                            var teste = task;
                            var falso = "\"false\"";
                            if (String.Equals(teste, falso))
                                achou = true;

                        }
                        catch (Exception ez)
                        {
                            var dd = ez.Message;
                            MessageBox.Show(dd);
                        }
                    }
                    var push = await webView.CoreWebView2.ExecuteScriptAsync("PushContatos()");
                    if (!string.IsNullOrEmpty(push))
                    {
                        // Retornando Tudo Okay!
                        contatos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ObjContato>>(push);
                        objcontatoetapa.contatos = contatos;
                        objcontatoetapa.VerificaResposta();
                        //string teste = JsonConvert.SerializeObject(contatos);
                        //MessageBox.Show(teste);

                    }

                    timer1.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            return true;
        }



        private void timer1_Tick(object sender, EventArgs e){
           timer1_tickasync();
        }
        public string InsereEmoticons(string msg)
        {
            msg = msg.Replace("[E1]", "😍");
            msg = msg.Replace("[E2]", "⏳");
            msg = msg.Replace("[E3]", "💵");
            msg = msg.Replace("[E4]", "🚀");
            msg = msg.Replace("[E5]", "⛔");
            msg = msg.Replace("[E6]", "🔔");
            msg = msg.Replace("[E7]", "😜");
            msg = msg.Replace("[E8]", "🕑");
            msg = msg.Replace("[E9]", "📞");
            msg = msg.Replace("[E10]", "💳");
            msg = msg.Replace("[E11]", "◾");
            msg = msg.Replace("[E12]", "◻️");
            msg = msg.Replace("[E13]", "▫️");
            return msg;
            
        }

        public tbMensagensWhatsapp GetProximaMensagem()
        {
            tbMensagensWhatsapp msg = null;
            try
            {

                WebRequest request = WebRequest.Create("http://www.youdelivery.com.br/c/Api/api/printserver/AdquireProximaWhatSmart/"+txtToken.Text);
                request.Method = "GET";
                request.ContentType = "application/json";
                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();

                    /* Mensagem */
                    msg = JsonConvert.DeserializeObject<tbMensagensWhatsapp>(responseFromServer);
                    
                }

                // Close the response.
                response.Close();
            }
            catch(Exception e)
            {
                //MessageBox.Show("Falha procurando nova mensagem: " + e.Message);
            }
            return msg;
        }

        public tbMensagensWhatsapp DefineComoEnviada(tbMensagensWhatsapp msg)
        {
            try
            {

                var envio = JsonConvert.SerializeObject(msg);
                byte[] byteArray = Encoding.UTF8.GetBytes(envio);
                WebRequest request = WebRequest.Create("http://www.youdelivery.com.br/c/Api/api/printserver/MarcaWhatSmart");
                request.Method = "POST";
                request.ContentLength = byteArray.Length;
                request.ContentType = "application/json";
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                using (dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                }

                // Close the response.
                response.Close();
            }
            catch (Exception e)
            {
               
                MessageBox.Show("Falha na autenticação do Token");
            }
            return msg;
        }

        private void btnIniciarConexao_Click(object sender, EventArgs e)
        {
            try
            {

               // byte[] byteArray = Encoding.UTF8.GetBytes(envio);
                WebRequest request = WebRequest.Create("http://www.youdelivery.com.br/c/Api/api/printserver/VerificaTokenWhatSmart/"+txtToken.Text);
                request.Method = "GET";
                 request.ContentType = "application/json";
                
                WebResponse response = request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();

                    urlAtual = "https://web.whatsapp.com/";
                    webView.CoreWebView2.Navigate("https://web.whatsapp.com/");

                    gbAutenticacao.Visible = false;
                    gbControle.Visible = true;

                    File.WriteAllText(@".//Token.txt", txtToken.Text);
                }

                // Close the response.
                response.Close();
            }
            catch (WebException ex)
           {
                MessageBox.Show("Falha na autenticação do Token");
            }
            

            
        }


        bool paralisado = false;
        private void txtPausar_Click(object sender, EventArgs e)
        {
            txtPausar.Visible = false;
            paralisado = true;
            txtExecutar.Visible = true;
            timer2.Start();
        }

        private void txtExecutar_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            paralisado = false;
            txtPausar.Visible = true;
            txtExecutar.Visible = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            paralisado = false;
            txtPausar.Visible = true;
            txtExecutar.Visible = false;
        }
    }
}
