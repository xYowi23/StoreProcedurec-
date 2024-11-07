using ProvaProce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvaProce.Repos
{
    internal class UtenteRepo : IRepo<Utente>
    {
        private static UtenteRepo? instance;
        public static UtenteRepo GetInstance()
        {
            if (instance == null)
                instance = new UtenteRepo();
            return instance;
        }
        public UtenteRepo() { }

        public bool Create(Utente entity)
        {
            bool risultato = false;

            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand("InserisciUtente",conn);
                cmd.CommandType = CommandType.StoredProcedure;

               
                cmd.Parameters.AddWithValue("@varNome", entity.Nome);
                cmd.Parameters.AddWithValue("@varCognome", entity.Cognome);
              

                try
                {
                    conn.Open();

                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        risultato = true;

                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return risultato;
        }

        public List<Utente> GetAll()
        {
            List<Utente> risultato = new List<Utente>();

            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT IdUtente, nome, cognome FROM Utente";

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Utente utente = new Utente()
                        {
                            IdUtente = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Cognome = reader.GetString(2),
                        };

                        risultato.Add(utente);
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }

            return risultato;


        }

        //public void StampaUtenti()
        //{
        //    List<Utente> utenti = GetAll();

        //    foreach (var utente in utenti)
        //    {
        //        Console.WriteLine($"ID: {utente.IdUtente}, Nome: {utente.Nome}, Cognome: {utente.Cognome}");
        //    }
        //}
    }
}
