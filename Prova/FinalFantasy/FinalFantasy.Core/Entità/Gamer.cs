using System;
using System.Collections.Generic;
using System.Text;

namespace FinalFantasy.Core
{
    public class Gamer
    {
        public string NickName { get; set; }
        public ICollection<Eroe> Eroi { get; set; } = new List<Eroe>();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"NickName: {NickName}\n");
            return sb.ToString();
        }
    }
}
