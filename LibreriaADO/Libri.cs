using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaADO
{
   public abstract class Libri
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string ISBN { get; set; }
        public Libri()
        {

        }
        public Libri(string titolo,string autore,string isbn)
        {
            Titolo = titolo;
            Autore = autore;
            ISBN = isbn;

        }
    }
}
