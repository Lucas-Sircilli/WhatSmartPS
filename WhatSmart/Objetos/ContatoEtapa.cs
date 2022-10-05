using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WhatSmart.Objetos 
{
    public class ContatoEtapa {
        
        public List<ObjContato> contatos { get; set; }
        public ContatoEtapa etapa = new ContatoEtapa();

        public void VerificaResposta()
        {
            foreach (ObjContato contato in contatos)
            {
                switch (contato.Mensagens.LastOrDefault())
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:

                        break;
                }
            }

            if ( .Equals("1"))
            {
                // responde opção 1
            }
            else if (a.Equals("2"))
            {
                // responde opção 2
            }
            else if (a.Equals("3"))
            {
                // responde opção 3
            }
            else if (a.Equals("4"))
            {
                // responde opção 4
            }
            else if (a.Equals("Sair"))
            {
                // responde opção Sair
            }
            else
            {
                // responde Erro
            }
        }
        public void VerificaMensagens(){ 
        // Aqui verificamos as mensagens enviadas e recebidas do contato
        
        }
        public void VerificaEtapa(){ 
        // Aqui Fariamos uma verificação para ver as últimas mensagens recebidas e enviadas e vermos se o atendimento foi finalizado ou não e se não qual etapa o mesmo está inserido.

        }


    }
}
