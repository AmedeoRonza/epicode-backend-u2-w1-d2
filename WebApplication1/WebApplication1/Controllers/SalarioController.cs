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
    public class SalarioController : Controller
    {
        // GET: Salario
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM Pagamenti", conn);
            List<Salario> paymentList = new List<Salario>();
            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Salario soldi = new Salario(
                        Convert.ToInt32(reader["IdPagamenti"]),
                        reader["Nome"].ToString(),
                        reader["Cognome"].ToString(),
                        reader["DataPagamento"].ToString(),
                        Convert.ToInt32(reader["Pagamento"]),
                        Convert.ToBoolean(reader["Stipendio"]),
                        Convert.ToBoolean(reader["Acconto"]));

                    paymentList.Add(soldi);
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
            return View(paymentList);            
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}