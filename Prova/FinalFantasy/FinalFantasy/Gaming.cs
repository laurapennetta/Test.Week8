using FinalFantasy.Core;
using FinalFantasy.RepositoryEF;
using FinalFantasy.RepositoryMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy
{
    public class Gaming
    {
        //static IRepositoryGamer repoGamer = new RepositoryGamerMock();
        //MENU INIZIALE DI GESTIONE DELL'UTENTE
        public static Gamer MenuIniziale()
        {
            RepositoryGamerEF repoGamer = new RepositoryGamerEF();
            int scelta = 0;
            Console.WriteLine("Benvenuto!");
            Console.WriteLine();
            Console.WriteLine("1. Accedi");
            Console.WriteLine("2. Registrati");
            Console.WriteLine("3. Exit");
            scelta = Helper.VerificaInput(3);
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il tuo NickName:");
                    string nickName = Console.ReadLine();
                    return repoGamer.GetByNickName(nickName);
                case 2:
                    //Registrazione
                    Console.WriteLine("Inserisci il NickName per la registrazione:");
                    string newNickName = Console.ReadLine();
                    while (newNickName.Length == 0)
                    {
                        Console.WriteLine("NickName non valido, riprova:");
                        newNickName = Console.ReadLine();
                    }
                    Gamer newGamer = new Gamer() { NickName = newNickName };
                    repoGamer.Add(newGamer);
                    return newGamer;
                case 3:
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    break;
            }
            return null;
        }

        //MENU PRINCIPALE DI INIZIO PARTITA
        public static bool MenuGiocatore(Gamer gamer)
        {
            //ALL'INTERNO DI QUESTO MENU VADO A GESTIRE LE OPERAZIONI
            //INIZIALE DI CREAZIONE PARTITA
            //CREAZIONE EROE
            //SCELTA EROE
            //ELIMINARE EROE
            Console.WriteLine();
            Console.WriteLine("MENU:");
            Console.WriteLine();
            Console.WriteLine("1. Inizia la partita");
            Console.WriteLine("2. Crea un Eroe");
            Console.WriteLine("3. Elimina un Eroe");
            Console.WriteLine("4. Exit");
            int scelta = Helper.VerificaInput(4);
            bool go = true;
            switch (scelta)
            {
                case 1:
                    Eroe eroeScelto = ScegliEroe(gamer); //da rivedere
                    Partita(eroeScelto);
                    break;
                case 2:
                    AddEroe(gamer);
                    break;
                case 3:
                    DeleteEroe(gamer);
                    break;
                case 4:
                    Console.WriteLine("Arrivederci!");
                    go = false;
                    break;
                default:
                    go = false;
                    break;
            }
            return go;
        }

        public static Eroe ScegliEroe(Gamer gamer)
        {
            RepositoryEroeEF repoEroe = new RepositoryEroeEF();
            RepositoryGamerEF repoGamer = new RepositoryGamerEF();
            Console.WriteLine("Questi sono i tuoi eroi, scegline uno:");
            Console.WriteLine();
            var e = repoGamer.GetAll().FirstOrDefault(x => x.NickName.Equals(gamer.NickName));
            foreach (var eroi in e.Eroi)
            {
                Console.WriteLine(eroi);
            }
            //var eroi = repoGamer.GetAll().FirstOrDefault(x => x.NickName.Equals(gamer.NickName));
            //Console.WriteLine(eroi);
            Console.WriteLine("Per selezionare l'eroe da usare in battaglia, inserisci l'id corrispondente:");
            int id = Helper.VerificaInt();
            Eroe eroe = new Eroe()
            {
                NickNameGamer = gamer.NickName
            };
            eroe = repoEroe.GetById(id);
            return eroe;
        }

        private static void DeleteEroe(Gamer gamer)
        {
            RepositoryEroeEF repoEroe = new RepositoryEroeEF();
            Console.WriteLine("Inserisci l'id dell'eroe che vuoi eliminare:");
            int id = Helper.VerificaInt();
            Eroe eroe = new Eroe()
            {
                ID = id,
                NickNameGamer = gamer.NickName
            };
            if (repoEroe.Delete(eroe))
            {
                Console.WriteLine("L'eroe è stato cancellato.");
            }
            else
            {
                Console.WriteLine("Ops, qualcosa è andato storto.");
            };
        }

        public static void AddEroe(Gamer gamer)
        {
            RepositoryEroeEF repoEroe = new RepositoryEroeEF();
            Console.WriteLine("Pronto a creare il tuo eroe?");
            Console.WriteLine("Premi invio per iniziare la creazione.");
            Console.ReadLine();
            Console.WriteLine("Iniziamo!");
            //Console.WriteLine("Inserisci l'ID del tuo nuovo eroe:");
            //int id = Helper.VerificaInt();
            Console.WriteLine("Inserisci il nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Per selezionare il tipo di eroe che preferisci, inserisci il numero corrispondente:");
            Console.WriteLine("0. Soldier");
            Console.WriteLine("1. Wizard");
            var categoria = (CategoriaEroe)Convert.ToInt32(Console.ReadLine());
            if (categoria == CategoriaEroe.Soldier)
            {
                Console.WriteLine("Per selezionare il tipo di arma che preferisci dare al tuo eroe, inserisci il numero corrispondente:");
                Console.WriteLine("1. Ascia");
                Console.WriteLine("2. Mazza");
                Console.WriteLine("3. Spada");
                int arma = Helper.VerificaInput(3);
                string nomeA = null;
                if(arma == 1)
                {
                    nomeA = "Ascia";
                }
                else if (arma == 2)
                {
                    nomeA = "Mazza";
                }
                else if (arma == 3)
                {
                    nomeA = "Spada";
                }
                Eroe soldato = new Eroe()
                {
                    Nome = nome,
                    Livello = 1,
                    NomeArma = nomeA,
                    Categoria = categoria,
                    PuntiLivello = 0,
                    NickNameGamer = gamer.NickName
                };
                if (repoEroe.Add(soldato))
                {
                    Console.WriteLine("Ottimo! L'eroe è stato registrato");
                }
                else
                {
                    Console.WriteLine("Ops, qualcosa è andato storto.");
                };
            }
            else if (categoria == CategoriaEroe.Wizard)
            {
                Console.WriteLine("Per selezionare il tipo di arma che preferisci dare al tuo eroe, inserisci il numero corrispondente:");
                Console.WriteLine("1. Arco e frecce");
                Console.WriteLine("2. Bacchetta");
                Console.WriteLine("3. Bastone Magico");
                int arma = Helper.VerificaInput(3);
                string nomeA = null;
                if (arma == 1)
                {
                    nomeA = "Arco e frecce";
                }
                else if (arma == 2)
                {
                    nomeA = "Bacchetta";
                }
                else if (arma == 3)
                {
                    nomeA = "Bastone Magico";
                }
                Eroe mago = new Eroe()
                {
                    Nome = nome,
                    Livello = 1,
                    NomeArma = nomeA,
                    Categoria = categoria,
                    PuntiLivello = 0,
                    NickNameGamer = gamer.NickName
                };
                if (repoEroe.Add(mago))
                {
                    Console.WriteLine("Ottimo! L'eroe è stato registrato");
                }
                else
                {
                    Console.WriteLine("Ops, qualcosa è andato storto.");
                };
            }
        }

        public static void Partita(Eroe eroeScelto)
        {
            //METODO ALL'INTERNO DEL QUALE VADO A GESTIRE 
            //LA LOGICA RELATIVA AD UNA PARTITA
            RepositoryMostroEF repoMostro = new RepositoryMostroEF();
            RepositoryArmaEF repoArma = new RepositoryArmaEF();
            Console.WriteLine("Iniziamo!");
            Console.WriteLine("Hai deciso di combattere con:");
            Console.WriteLine();
            Console.WriteLine(eroeScelto);
            Console.WriteLine("Il tuo avversario è:");
            Console.WriteLine();
            Mostro mostroSorteggiato = new Mostro();
            do
            {
                var rand = new Random();
                int id = rand.Next(6); //spiegazione:
                //poichè decido io quanti mostri mettere e avere in database, ho il controllo sul num max
                mostroSorteggiato = repoMostro.GetById(id);
            } while (mostroSorteggiato == null || mostroSorteggiato.Livello > eroeScelto.Livello);
            Console.WriteLine(mostroSorteggiato);
            Console.WriteLine();
            Console.WriteLine("Quando sei pronto a combattere, premi invio:");
            Console.ReadLine();
            Console.WriteLine("Che la battaglia abbia inizio!!!");
            Battaglia(eroeScelto, mostroSorteggiato);
        }

        public static void Battaglia(Eroe eroeScelto, Mostro mostroSorteggiato)
        {
            //ALL'INTERNO DI QUESTO METODO VENGONO GESTITE LE CASISTICHE DI 
            //VITTORIA-PERDITA DELL'EROE
            //LA BATTAGLIA SI RIPETE FINCHE' L'EROE NON UCCIDE IL MOSTRO O VICEVERSA
            RepositoryArmaEF repoArma = new RepositoryArmaEF();
            int vitaMostro = mostroSorteggiato.PuntiVita;
            int vitaEroe = eroeScelto.PuntiVita;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Tocca a te.");
                Console.WriteLine();
                bool azione = SceltaTurno();
                switch (azione)
                {
                    case true:
                        string nome = eroeScelto.NomeArma;
                        Arma armaEroe = repoArma.GetByNome(nome);
                        vitaMostro -= armaEroe.PuntiDanno;
                        Console.WriteLine("Colpo riuscito.");
                        Console.WriteLine();
                        break;
                    case false:
                        var rand = new Random();
                        int esitoFuga = rand.Next(3);
                        switch (esitoFuga)
                        {
                            case 1:
                                Console.WriteLine("Fuga non riuscita. Resisti.");
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.WriteLine("Fuga riuscita!");
                                Console.WriteLine();
                                vitaEroe = 2000;
                                vitaMostro = 0;
                                break;
                        }
                        break;
                }
                if(vitaEroe != 2000)
                {
                    Console.WriteLine("E' il turno del mostro.");
                    Console.WriteLine("...");
                    Console.WriteLine("BOOM!");
                    Console.WriteLine("Il mostro ti ha colpito!!!");
                    Console.WriteLine();
                    string nome2 = mostroSorteggiato.NomeArma;
                    Arma armaMostro = repoArma.GetByNome(nome2);
                    vitaEroe -= armaMostro.PuntiDanno;
                }
            }while (vitaEroe > 0 && vitaMostro > 0);
            if (vitaEroe == 2000 && vitaMostro == 0)
            {
                eroeScelto.PuntiLivello -= (mostroSorteggiato.Livello * 5);
            }
            if (vitaMostro <= 0 && vitaEroe > 0 && vitaEroe != 2000)
            {
                Console.WriteLine("Congratulazioni, hai vinto!");
                eroeScelto.PuntiLivello += (mostroSorteggiato.Livello * 10);
            }
            if (vitaEroe <= 0)
            {
                Console.WriteLine("...");
                Console.WriteLine("Purtroppo è stato un colpo decisivo...");
                Console.WriteLine("Hai perso lo scontro.");
            }
            if(eroeScelto.PuntiLivello >= 30 && eroeScelto.Livello == 1)
            {
                eroeScelto.Livello = 2;
                eroeScelto.PuntiLivello = 0;
            }
            if (eroeScelto.PuntiLivello >= 60 && eroeScelto.Livello == 2)
            {
                eroeScelto.Livello = 3;
                eroeScelto.PuntiLivello = 0;
            }
            if (eroeScelto.PuntiLivello >= 90 && eroeScelto.Livello == 3)
            {
                eroeScelto.Livello = 4;
                eroeScelto.PuntiLivello = 0;
            }
            if (eroeScelto.PuntiLivello >= 120 && eroeScelto.Livello == 4)
            {
                eroeScelto.Livello = 5;
                eroeScelto.PuntiLivello = 0;
            }
        }

        public static bool SceltaTurno()
        {
            //METODO CHE CHIEDE ALL'UTENTE QUALE MOSSA ESEGUIRE
            //LOTTA O FUGA;
            bool azione;
            Console.WriteLine("Cosa vuoi fare?");
            Console.WriteLine("1. Sferrare un attacco");
            Console.WriteLine("2. Metterti in fuga");
            int scelta = Helper.VerificaInput(2);
            switch (scelta)
            {
                case 1:
                    azione = true;
                    break;
                case 2:
                    azione = false;
                    break;
                default:
                    azione = false;
                    break;
            }
            return azione;
        }

        
    }
}
