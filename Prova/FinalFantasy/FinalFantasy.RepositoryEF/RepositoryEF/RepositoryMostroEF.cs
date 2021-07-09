using FinalFantasy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class RepositoryMostroEF : IRepositoryMostro
    {
        public Mostro GetById(int id)
        {
            using (var ctx = new Context())
            {
                if (id < 0)
                {
                    return null;
                }
                return ctx.Mostri.FirstOrDefault(n => n.ID == id);
            }
        }
    }
}
