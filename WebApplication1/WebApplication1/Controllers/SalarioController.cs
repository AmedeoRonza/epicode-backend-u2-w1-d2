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
                conn.Close(); 
            }
            return View(paymentList);            
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create (Salario soldi)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {  
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Pagamenti (Nome, Cognome, DataPagamento, Pagamento, Stipendio, Acconto) VALUES (@Nome, @Cognome, @DataPagamento, @Pagamento, @Stipendio, @Acconto)", conn);
                cmd.Parameters.AddWithValue("@Nome", soldi.Nome);
                cmd.Parameters.AddWithValue("@Cognome", soldi.Cognome);
                cmd.Parameters.AddWithValue("@DataPagamento", soldi.DataPagamento);
                cmd.Parameters.AddWithValue("@Pagamento", soldi.Pagamento);
                cmd.Parameters.AddWithValue("@Stipendio", soldi.Stipendio);
                cmd.Parameters.AddWithValue("@Acconto", soldi.Acconto);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close(); 
            }

            return View();
        }
    }
}