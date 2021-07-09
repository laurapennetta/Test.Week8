using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy
{
    public class Helper
    {
        public static int VerificaInput(int max)
        {
            var conversione = int.TryParse(Console.ReadLine(), out int result);
            while (conversione == false || result < 0 || result > max)
            {
                conversione = int.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }
        public static int VerificaInt()
        {
            bool verifica = Int32.TryParse(Console.ReadLine(), out int num);
            while (!verifica)
            {
                Console.WriteLine("Devi inserire un valore numerico");
                verifica = Int32.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }
    }
}
