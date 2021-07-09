using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core
{
    public interface IRepositoryMostro : IRepository<Mostro>
    {
        public Mostro GetById(int id);
    }
}
