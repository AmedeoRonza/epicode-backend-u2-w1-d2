using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DipendentiController : Controller
    {
        // GET: Dipendenti
        public ActionResult Index() // int idDipendenti, string nome, string cognome, string indirizzo, string codiceFiscale, bool sposato, int numeroFigliACarico, string mansione
        {
            //   List<Dipendente> list = new List<Dipendente>();
            //   list.Add(new Dipendente(1, "Marco", "Nino", "Via giallo", "ghcdff88h54m088t", false, 8, "killer"));
            // Connessione al db tramite la stringa di connessione presente nel file Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();

            // Creo la connessione al db tramite la stringa di connessione 
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Dipendenti", conn);

            // Creo una lista di oggetti di tipo Employee
            List<Dipendente> employeesList = new List<Dipendente>();

            try
            {
                // Apro la connessione al db
                conn.Open();

                // Eseguo il comando sql
                SqlDataReader reader = cmd.ExecuteReader();

                // Leggo i dati dal db
                while (reader.Read())
                {
                    // Creo un oggetto di tipo Employee
                    Dipendente employee = new Dipendente(
                        Convert.ToInt32(reader["IdDipendenti"]),
                        reader["Nome"].ToString(),
                        reader["Cognome"].ToString(),
                        reader["Indirizzo"].ToString(),
                        reader["CodiceFiscale"].ToString(),
                        Convert.ToBoolean(reader["Sposato"]),
                        Convert.ToInt32(reader["NumeroFigliACarico"]),
                        reader["Mansione"].ToString());

                    // Aggiungo l'oggetto alla lista che poi verrà passata alla view
                    employeesList.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close(); // Chiudo la connessione al db, NECESSARIO
            }
            return View(employeesList);
        }
        
        public ActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Create(Dipendente dipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();

            // Creo la connessione al db tramite la stringa di connessione 
            SqlConnection conn = new SqlConnection(connectionString);
            

          

            try
            {
                // Apro la connessione al db
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Dipendenti (Nome, Cognome, Indirizzo, CodiceFiscale, Sposato, NumeroFigliACarico, Mansione) VALUES (@Nome, @Cognome, @Indirizzo, @CodiceFiscale, @Sposato, @NumeroFigliACarico, @Mansione)", conn);
                cmd.Parameters.AddWithValue("@Nome", dipendente.Nome);
                cmd.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                cmd.Parameters.AddWithValue("@Indirizzo", dipendente.Indirizzo);
                cmd.Parameters.AddWithValue("@CodiceFiscale", dipendente.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Sposato", dipendente.Sposato);
                cmd.Parameters.AddWithValue("@NumeroFigliACarico", dipendente.NumeroFigliACarico);
                cmd.Parameters.AddWithValue("@Mansione", dipendente.Mansione);

                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close(); // Chiudo la connessione al db, NECESSARIO
            }
            return View();
        }




    }
}