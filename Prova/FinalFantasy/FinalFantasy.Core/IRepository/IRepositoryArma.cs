using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core
{
    public interface IRepositoryArma : IRepository<Arma>
    {
        //Per selezionare l'arma del personaggio mi serve il GetByNome:
        public Arma GetByNome(string nome);
    }
}
