using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaProce.Models
{
    [Table("Utente")]
    internal class Utente
    {

        [Key]
        public int IdUtente { get; set; }
        [Column("nome")]
        public string? Nome { get; set; }
        [Column("cognome")]
        public string? Cognome { get; set; }

        public override string ToString()
        {
            return $"ID: {IdUtente}, Nome: {Nome}, Cognome: {Cognome}";
        }
    }
}
