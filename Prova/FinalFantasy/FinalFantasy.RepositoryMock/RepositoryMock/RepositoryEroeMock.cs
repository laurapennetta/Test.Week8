using FinalFantasy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryMock
{
    public class RepositoryEroeMock : IRepositoryEroe
    {
        private ICollection<Eroe> Eroi = new List<Eroe>()
        {
            new Eroe { ID = 1, Nome = "Hercules", Livello = 1, NomeArma = "Spada", PuntiLivello = 20, NickNameGamer = "Laura_Pennetta" }
        };
        public bool Add(Eroe eroe)
        {
            if (eroe != null)
            {
                Eroi.Add(eroe);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Eroe eroe)
        {
            var eroeToDelete = Eroi.FirstOrDefault(x => x.ID == eroe.ID);
            return Eroi.Remove(eroeToDelete);
        }

        public ICollection<Eroe> GetAll()
        {
            return Eroi;
        }

        public Eroe GetById(int id)
        {
            if (id > 0)
            {
                foreach (Eroe eroe in Eroi)
                {
                    if (eroe.ID == id)
                    {
                        return eroe;
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
