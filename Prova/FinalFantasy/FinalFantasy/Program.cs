using FinalFantasy.Core;
using FinalFantasy.RepositoryMock;
using System;

namespace FinalFantasy
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositoryGamerMock repoGamer = new RepositoryGamerMock();
            bool continua = true;
            while (continua)
            {
                Gamer gamer = Gaming.MenuIniziale();
                if(gamer != null)
                {
                    //continua = true;
                    //bool continua2 = 
                    Gaming.MenuGiocatore(gamer);
                    if(Gaming.MenuGiocatore(gamer) == false)
                    {
                        continua = false;
                    }
                }
                continua = false;
            }
        }
    }
}
