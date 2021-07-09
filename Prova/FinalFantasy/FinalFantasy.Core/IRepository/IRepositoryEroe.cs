using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core
{
    public interface IRepositoryEroe : IRepository<Eroe>
    {
        public Eroe GetById(int id);
        public bool Add(Eroe eroe);
        public bool Delete(Eroe eroe);
        public ICollection<Eroe> GetAll();
    }
}
