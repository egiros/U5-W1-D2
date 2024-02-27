using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Web.Mvc;
using U5_W1_D2.Models;

namespace U5_W1_D2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            List<Dipendenti> dipendenti = new List<Dipendenti>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM Dipendenti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())

                {
                    Dipendenti dipendente = new Dipendenti();
                    dipendente.DipendenteID = Convert.ToInt32(reader["DipendenteID"]);
                    dipendente.Nome = reader["Nome"].ToString();
                    dipendente.Cognome = reader["Cognome"].ToString();
                    dipendente.Indirizzo = reader["Indirizzo"].ToString();
                    dipendente.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    dipendente.Coniugato = Convert.ToBoolean(reader["Coniugato"]);
                    dipendente.NumeroFigli = Convert.ToInt32(reader["NumeroFigli"]);
                    dipendente.Mansione = reader["Mansione"].ToString();
                    dipendenti.Add(dipendente);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: ");
                Response.Write(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return View(dipendenti);
        }

        public ActionResult CreateDipendenti() { return View(); }
        [HttpPost]
        public ActionResult CreateDipendenti(Dipendenti dipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "INSERT INTO Dipendenti (Nome, Cognome, Indirizzo, CodiceFiscale, Coniugato, NumeroFigli,  Mansione)" +
                    " VALUES (@Nome, @Cognome, @Indirizzo, @CodiceFiscale, @Coniugato, @NumeroFigli, @Mansione)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", dipendente.Nome);
                cmd.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                cmd.Parameters.AddWithValue("@Indirizzo", dipendente.Indirizzo);
                cmd.Parameters.AddWithValue("@CodiceFiscale", dipendente.CodiceFiscale);
                cmd.Parameters.AddWithValue("@Coniugato", dipendente.Coniugato);
                cmd.Parameters.AddWithValue("@NumeroFigli", dipendente.NumeroFigli);
                cmd.Parameters.AddWithValue("@Mansione", dipendente.Mansione);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write("Error: ");
                Response.Write(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");
        }

        List<Pagamenti> pagamenti = new List<Pagamenti>();
        public ActionResult CreatePayment() { return View(); }
        [HttpPost]
        public ActionResult CreatePayment(Pagamenti pagamento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "INSERT INTO Pagamenti (FK_DipendenteID, PeriodoPagamento, AmmontarePagamento, Tipo)" +
                    " VALUES (@FK_DipendenteID, @PeriodoPagamento, @AmmontarePagamento, @Tipo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FK_DipendenteID", pagamento.DipendenteID);
                cmd.Parameters.AddWithValue("@PeriodoPagamento", pagamento.PeriodoPagamento);
                cmd.Parameters.AddWithValue("@Ammontare", pagamento.Ammontare);
                cmd.Parameters.AddWithValue("@TipoPagamento", pagamento.TipoPagamento);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write("Error: ");
                Response.Write(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionStringDb"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Pagamenti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())

                {
                    Pagamenti pagamento = new Pagamenti();
                    pagamento.DipendenteID = Convert.ToInt32(reader["FK_DipendenteID"]);
                    pagamento.PeriodoPagamento = Convert.ToDateTime(reader["PeriodoPagamento"]);
                    pagamento.Ammontare = Convert.ToDecimal(reader["AmmontarePagamento"]);
                    pagamento.TipoPagamento = reader["Tipo"].ToString();

                    pagamenti.Add(pagamento);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: ");
                Response.Write(ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return View(pagamenti);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
