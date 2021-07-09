using FinalFantasy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.RepositoryEF
{
    public class RepositoryArmaEF : IRepositoryArma
    {
        public Arma GetByNome(string nome)
        {
            using (var ctx = new Context())
            {
                if (nome.Length == 0)
                {
                    return null;
                }
                return ctx.Armi.FirstOrDefault(n => n.Nome == nome);
            }
        }
    }
}
