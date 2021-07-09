using FinalFantasy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryMock
{
    public class RepositoryMostroMock : IRepositoryMostro
    {
        private ICollection<Mostro> Mostri = new List<Mostro>()
        {
            new Mostro { ID = 1, Nome = "Lucifero", Livello = 1, NomeArma = "Tempesta"}
        };
        public Mostro GetById(int id)
        {
            if (id > 0)
            {
                foreach (Mostro mostro in Mostri)
                {
                    if (mostro.ID == id)
                    {
                        return mostro;
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
