namespace WhatSmart
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.bwConsultaProximaMensagem = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciarConexao = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPausar = new System.Windows.Forms.Button();
            this.txtExecutar = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gbControle = new System.Windows.Forms.GroupBox();
            this.gbAutenticacao = new System.Windows.Forms.GroupBox();
            this.gbControle.SuspendLayout();
            this.gbAutenticacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.webView.Location = new System.Drawing.Point(271, 1);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(889, 507);
            this.webView.Source = new System.Uri("https://www.youdelivery.com.br/robo", System.UriKind.Absolute);
            this.webView.TabIndex = 0;
            this.webView.Text = "webView21";
            this.webView.ZoomFactor = 1D;
            this.webView.Click += new System.EventHandler(this.webView21_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(6, 110);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(172, 20);
            this.txtNumero.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(6, 136);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(253, 142);
            this.txtMsg.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtToken
            // 
            this.txtToken.Enabled = false;
            this.txtToken.Location = new System.Drawing.Point(3, 35);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(253, 20);
            this.txtToken.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Token";
            // 
            // btnIniciarConexao
            // 
            this.btnIniciarConexao.Location = new System.Drawing.Point(3, 61);
            this.btnIniciarConexao.Name = "btnIniciarConexao";
            this.btnIniciarConexao.Size = new System.Drawing.Size(253, 23);
            this.btnIniciarConexao.TabIndex = 7;
            this.btnIniciarConexao.Text = "Iniciar Conexão";
            this.btnIniciarConexao.UseVisualStyleBackColor = true;
            this.btnIniciarConexao.Click += new System.EventHandler(this.btnIniciarConexao_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Telefone";
            // 
            // txtPausar
            // 
            this.txtPausar.Location = new System.Drawing.Point(9, 19);
            this.txtPausar.Name = "txtPausar";
            this.txtPausar.Size = new System.Drawing.Size(117, 23);
            this.txtPausar.TabIndex = 9;
            this.txtPausar.Text = "Pausar";
            this.txtPausar.UseVisualStyleBackColor = true;
            this.txtPausar.Click += new System.EventHandler(this.txtPausar_Click);
            // 
            // txtExecutar
            // 
            this.txtExecutar.Location = new System.Drawing.Point(129, 19);
            this.txtExecutar.Name = "txtExecutar";
            this.txtExecutar.Size = new System.Drawing.Size(130, 23);
            this.txtExecutar.TabIndex = 10;
            this.txtExecutar.Text = "Executar";
            this.txtExecutar.UseVisualStyleBackColor = true;
            this.txtExecutar.Visible = false;
            this.txtExecutar.Click += new System.EventHandler(this.txtExecutar_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 300000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // gbControle
            // 
            this.gbControle.Controls.Add(this.txtMsg);
            this.gbControle.Controls.Add(this.txtExecutar);
            this.gbControle.Controls.Add(this.txtNumero);
            this.gbControle.Controls.Add(this.txtPausar);
            this.gbControle.Controls.Add(this.button1);
            this.gbControle.Controls.Add(this.label2);
            this.gbControle.Location = new System.Drawing.Point(0, 173);
            this.gbControle.Name = "gbControle";
            this.gbControle.Size = new System.Drawing.Size(265, 284);
            this.gbControle.TabIndex = 12;
            this.gbControle.TabStop = false;
            this.gbControle.Text = "Controle";
            this.gbControle.Visible = false;
            // 
            // gbAutenticacao
            // 
            this.gbAutenticacao.Controls.Add(this.btnIniciarConexao);
            this.gbAutenticacao.Controls.Add(this.txtToken);
            this.gbAutenticacao.Controls.Add(this.label1);
            this.gbAutenticacao.Location = new System.Drawing.Point(6, 1);
            this.gbAutenticacao.Name = "gbAutenticacao";
            this.gbAutenticacao.Size = new System.Drawing.Size(259, 114);
            this.gbAutenticacao.TabIndex = 13;
            this.gbAutenticacao.TabStop = false;
            this.gbAutenticacao.Text = "Autenticação";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 510);
            this.Controls.Add(this.gbAutenticacao);
            this.Controls.Add(this.gbControle);
            this.Controls.Add(this.webView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WhatSmart GVD";
            this.gbControle.ResumeLayout(false);
            this.gbControle.PerformLayout();
            this.gbAutenticacao.ResumeLayout(false);
            this.gbAutenticacao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.ComponentModel.BackgroundWorker bwConsultaProximaMensagem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciarConexao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button txtPausar;
        private System.Windows.Forms.Button txtExecutar;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox gbControle;
        private System.Windows.Forms.GroupBox gbAutenticacao;
    }
}

