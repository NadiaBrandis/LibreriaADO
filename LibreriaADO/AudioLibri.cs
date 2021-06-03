using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaADO
{
    class AudioLibri:Libri
    {
        public int Durata{ get; set; }
        public AudioLibri()
        {

        }
        public AudioLibri(string titolo, string autore, string ibsn,int durata)
            :base(titolo,autore,ibsn)
        {
            Durata = durata;
        }
    }
}
