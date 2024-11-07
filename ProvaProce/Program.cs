using ProvaProce.Models;
using ProvaProce.Repos;

namespace ProvaProce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci cognome");
            string? inNome = Console.ReadLine();

            Console.WriteLine("Inserisci cognome");
            string? inCognome = Console.ReadLine();

            Utente lib = new Utente()
            {
                Nome = inNome is not null ? inNome : "N.D.",
                Cognome = inCognome is not null ? inCognome : "N.D.",
               
            };

            if (UtenteRepo.GetInstance().Create(lib))
                Console.WriteLine("Libro inserito con successo");
            else
                Console.WriteLine("ERRORE di inserimento");



            List<Utente> elenco = UtenteRepo.GetInstance().GetAll();

            foreach (Utente utente in elenco)
            {
                Console.WriteLine(utente);
            }


        }
    }
}
