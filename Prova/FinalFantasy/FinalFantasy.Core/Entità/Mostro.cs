using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core
{
    public enum CategoriaMostro
    {
        Lucifer,
        Ghost
    }
    public class Mostro : Personaggio
    {
        public CategoriaMostro Categoria { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {ID}\nNome: {Nome}\nLivello: {Livello}\nPunti Vita: {PuntiVita}\nCategoria Mostro: {Categoria}\n");
            return sb.ToString();
        }
    }
}
