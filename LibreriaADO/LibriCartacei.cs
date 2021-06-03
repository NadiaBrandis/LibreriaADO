using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaADO
{
    class LibriCartacei:Libri
    {
        public int NumeroPagine { get; set; }
        public int Quantita { get; set; }
        public LibriCartacei(string titolo,string autore,string ibsn,int pagine,int quantita)
           : base(titolo,autore,ibsn)
        {
            NumeroPagine = pagine;
            Quantita = quantita;
        }
    }
}
