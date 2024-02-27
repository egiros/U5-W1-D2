using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace U5_W1_D2.Models
{
    public class Dipendenti
    {
        public int DipendenteID { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo Cognome è obbligatorio.")]
        public string Cognome { get; set; }

        public string Indirizzo { get; set; }

        [Required(ErrorMessage = "Il campo Codice Fiscale è obbligatorio.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il Codice Fiscale deve essere di 16 caratteri.")]
        public string CodiceFiscale { get; set; }

        public bool Coniugato { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Il Numero Figli deve essere un valore positivo.")]
        public int NumeroFigli { get; set; }

        [Required(ErrorMessage = "Il campo Mansione è obbligatorio.")]
        public string Mansione { get; set; }

    }
}