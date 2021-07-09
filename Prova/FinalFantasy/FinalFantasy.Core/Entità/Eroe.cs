using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy.Core
{
    public enum CategoriaEroe
    {
        Soldier,
        Wizard
    }
    public class Eroe : Personaggio
    {
        public CategoriaEroe Categoria { get; set; }
        public int PuntiLivello { get; set; }
        public string NickNameGamer { get; set; }
        public Gamer Gamer { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ID: {ID}\nNome: {Nome}\nLivello: {Livello}\nPunti Vita: {PuntiVita}\nPunti Livello: {PuntiLivello}\nCategoria Eroe: {Categoria}\n");
            return sb.ToString();
        }
    }
}
