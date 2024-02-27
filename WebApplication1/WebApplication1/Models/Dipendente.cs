using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Dipendente
    {
        public int IdDipendenti { get; set; }

       
        public string Nome { get; set; }

        
        public string Cognome { get; set; }

        
        public string Indirizzo { get; set; }

        [Display(Name = "Codice Fiscale")]
        public string CodiceFiscale { get; set; }

        public bool Sposato { get; set; }

        [Display(Name = "Numero Figli a Carico")]
        public int NumeroFigliACarico { get; set; }

        public string Mansione { get; set; }
    
    public Dipendente () { }

        public Dipendente (int idDipendenti, string nome, string cognome, string indirizzo, string codiceFiscale, bool sposato, int numeroFigliACarico, string mansione)
        {
            IdDipendenti = idDipendenti;
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            CodiceFiscale = codiceFiscale;
            Sposato = sposato;
            NumeroFigliACarico = numeroFigliACarico;
            Mansione = mansione;
        }
    }

}