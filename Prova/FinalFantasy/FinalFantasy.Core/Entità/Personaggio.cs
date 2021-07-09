using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core
{
    public class Personaggio
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Livello { get; set; }
        public int PuntiVita
        {
            get
            {
                if (Livello == 1)
                {
                    return 20;
                }
                if (Livello == 2)
                {
                    return 40;
                }
                if (Livello == 3)
                {
                    return 60;
                }
                if (Livello == 4)
                {
                    return 80;
                }
                if (Livello == 5)
                {
                    return 100;
                }
                return 0;
            }
        }
        public string NomeArma { get; set; }
        public Arma Arma { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {ID}\nNome: {Nome}\nLivello: {Livello}\nPunti Vita: {PuntiVita}\n");
            return sb.ToString();
        }
    }
}
