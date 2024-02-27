using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Salario
    {
        public int IdPagamenti { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string DataPagamento { get; set; }
        public int Pagamento { get; set; }
        public bool Stipendio {  get; set; }
        public bool Acconto { get; set; }

        public Salario() { }
        public Salario(int idPagamenti, string nome, string cognome, string dataPagamento, int pagamento, bool stipendio, bool acconto)
        {
            IdPagamenti = idPagamenti;
            Nome = nome;
            Cognome = cognome;
            DataPagamento = dataPagamento;
            Pagamento = pagamento;
            Stipendio = stipendio;
            Acconto = acconto;
        }

    }
}