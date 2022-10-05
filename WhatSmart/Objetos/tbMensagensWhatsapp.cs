using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatSmart.Objetos
{
    public class tbMensagensWhatsapp
    {		
		public int IdMensagemWhatsapp { get; set; }

		public string Nome { get; set; }

		public string Telefone { get; set; }

		public string Empresa { get; set; }

		public string Codigo { get; set; }

		public string Mensagem { get; set; }

		public int? Status { get; set; }

		public DateTime? DataCadastro { get; set; }

		public DateTime? DataEnvio { get; set; }
	}
}
