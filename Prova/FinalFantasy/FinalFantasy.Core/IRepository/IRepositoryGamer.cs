using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core
{
    public interface IRepositoryGamer : IRepository<Gamer>
    {
        //Per registrati serve Create:
        public Gamer Add(Gamer gamer);
        //Per accedi serve GetByNickName:
        public Gamer GetByNickName(string nickname);
        public ICollection<Gamer> GetAll();
    }
}
