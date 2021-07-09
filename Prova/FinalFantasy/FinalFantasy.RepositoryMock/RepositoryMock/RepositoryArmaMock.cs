using FinalFantasy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryMock
{
    public class RepositoryArmaMock : IRepositoryArma
    {
        private ICollection<Arma> Armi = new List<Arma>()
        {
            new Arma { Nome = "Ascia", PuntiDanno = 8 },
            new Arma { Nome = "Mazza", PuntiDanno = 5 },
            new Arma { Nome = "Spada", PuntiDanno = 10 },
            new Arma { Nome = "Arco e frecce", PuntiDanno = 8 },
            new Arma { Nome = "Bacchetta", PuntiDanno = 5 },
            new Arma { Nome = "Bastone Magico", PuntiDanno = 10 },
            new Arma { Nome = "Arco", PuntiDanno = 7 },
            new Arma { Nome = "Clava", PuntiDanno = 5 },
            new Arma { Nome = "Divinazione", PuntiDanno = 15 },
            new Arma { Nome = "Fulmine", PuntiDanno = 10 },
            new Arma { Nome = "Tempesta", PuntiDanno = 8 },
        };
        public Arma GetByNome(string nome)
        {
            if (nome != null)
            {
                foreach (Arma arma in Armi)
                {
                    if (arma.Nome == nome)
                    {
                        return arma;
                    }
                }
                Console.WriteLine("Error");
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
