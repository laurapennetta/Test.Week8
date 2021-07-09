using FinalFantasy.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class RepositoryGamerEF : IRepositoryGamer
    {
        public Gamer Add(Gamer gamer)
        {
            using (var ctx = new Context())
            {
                try
                {
                    if (gamer == null)
                    {
                        return null;
                    }
                    ctx.Entry<Gamer>(gamer).State = EntityState.Added;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return gamer;
        }

        public ICollection<Gamer> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Gamers.Include(x => x.Eroi).ToList();
            }
        }

        public Gamer GetByNickName(string nickname)
        {
            using (var ctx = new Context())
            {
                if (nickname.Length == 0)
                {
                    return null;
                }
                return ctx.Gamers.FirstOrDefault(n => n.NickName == nickname);
            }
        }
    }
}
