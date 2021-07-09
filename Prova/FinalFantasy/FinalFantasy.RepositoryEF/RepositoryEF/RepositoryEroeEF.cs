using FinalFantasy.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class RepositoryEroeEF : IRepositoryEroe
    {
        public bool Add(Eroe eroe)
        {
            using (var ctx = new Context())
            {
                try
                {
                    if (eroe == null)
                    {
                        return false;
                    }
                    ctx.Entry<Eroe>(eroe).State = EntityState.Added;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public bool Delete(Eroe eroe)
        {
            using (var ctx = new Context())
            {
                if (eroe.ID > 0)
                {
                    eroe = ctx.Eroi.Find();
                }
            }
            using (var ctx = new Context())
            {
                try
                {
                    if (eroe == null)
                    {
                        return false;
                    }
                    ctx.Entry<Eroe>(eroe).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public ICollection<Eroe> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Eroi.Include(x=>x.Arma).ToList();
            }
        }

        public Eroe GetById(int id)
        {
            using (var ctx = new Context())
            {
                if (id < 0)
                {
                    return null;
                }
                return ctx.Eroi.FirstOrDefault(n => n.ID == id);
            }
        }
    }
}
