using System;
using System.Collections.Generic;

namespace LibreriaADO
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creare un programma per la gestione di libri da parte del proprietario del sito
            // I libri hanno titolo - autore - codice ISBN -> abstract
            // Gli audiolibri hanno anche la durata in minuti
            // I libri cartacei hanno il numero di pagine e la quantità in magazzino
            // due libri sono uguali se hanno lo stesso ISBN( cartecei e audiolibri NON hanno lo stesso ISBN)

            // Il proprietario può vedere tutti i libri stampando titolo, autore e se è o no audiolibro
            // vedere tutta la lista di libri cartacei
            // vedere tutta la lista di audiolibri
            // Modificare la quantità di libri cartacei in magazzino
            // Modificare la durata in minuti di un audiolibro
            // Se inserisce un titolo gli viene mostrato sia il libro cartaceo che l'audiolibro
            // Se inserisce un nuovo libro cartaceo o audiolibro, 
            //     prima di inserirlo verificare che non sia già presente tramite codice ISBN)

            //  Gestire il db sia in connected mode che in disconnected mode
            Console.WriteLine("--------LIBRERIA GIUNTI AL PUNTO---------");
            Console.WriteLine("Benvenuto!!\n");
            //creo la classe libri
            //creo le classi audiolibri e libri cartacei(figlie della classe padre "libri")
            //audiolibi e libri cartacei saranno anche i nomi delle due tabelle del DB
            //una volta impostate le classi procedo con la creazione del menu (mi trovo meglio impostandolo dal inizio)
            //creo le tabelle su sql server menagement studio
            string scelta;
            do
            {
                Console.WriteLine("1. Gurda la lista dei libri presenti nel magazzino");
                Console.WriteLine("2. Guarda la lista dei libri cartacei già presenti in magazzino");
                Console.WriteLine("3. Guarda la lista degli audiolibri già presenti in magazzino");
                Console.WriteLine("4. modifica la quantità dei libri cartacei presenti in magazzino");
                Console.WriteLine("5. modifica la durata in minuti di un audiolibro");
                Console.WriteLine("6. inserisci un nuovo libro");
                Console.WriteLine("7. Inserisci un titolo e visualizza libro e audiolibro");
                Console.WriteLine("0. Esci dal applicazione");
                Console.WriteLine("");
                Console.Write("fai la tua scelta: ");
                Console.WriteLine("");
                scelta = Console.ReadLine();
                switch(scelta)
                {
                    case "1":
                        Console.WriteLine("-----------------------TUTTI I LIBRI-------------------------");
                        DbManagerConnectedMode.GetTuttiLibri();
                        Console.WriteLine("--------------------------------------------------------------\n");
                        
                        break;
                    case "2":
                        Console.WriteLine("-----------------------LIBRI CARTACEI-------------------------");
                        DbManagerConnectedMode.GetLibriCartacei();
                        Console.WriteLine("--------------------------------------------------------------\n");
                        break;
                    case "3":
                        Console.WriteLine("-----------------------AUDIOLIBRI-------------------------");
                        DbManagerConnectedMode.GetAudiolibri();
                        Console.WriteLine("--------------------------------------------------------------\n");

                        break;
                    case "4":
                        DbManagerConnectedMode.GetLibriCartacei();
                        Console.Write("indica il titolo del libro: ");
                        string titolo = Console.ReadLine();
                        Console.Write("Indica la nuova quantità: ");
                        int quantita = int.Parse(Console.ReadLine());
                        DbManagerConnectedMode.ModificaQuantita(titolo, quantita);
                        break;
                    case "5":
                        Console.Write("Indica il titolo del Audiolibro: ");
                        string t = Console.ReadLine();
                        Console.Write("Nuovo minutaggio: ");
                        int minuti= int.Parse(Console.ReadLine());
                        DbManagerConnectedMode.ModificaMinuti(t, minuti);
                        break;
                    case "6":
                        Console.Write("vuoi inserire un libro cartaceo ?? si/no: ");
                        string risposta = Console.ReadLine();
                        Console.WriteLine("INSERISCI UN NUOVO LIBRO");
                        if (risposta == "si")
                        {
                            
                            Console.WriteLine("INSERISCI UN NUOVO LIBRO CARTACEO");
                            Console.Write("Titolo: ");
                            string titolO = Console.ReadLine();
                            Console.Write("Autore: ");
                            string aut= Console.ReadLine();
                            Console.Write("Numero di pagine: ");
                            int num = int.Parse(Console.ReadLine());
                            Console.Write("Quantita: ");
                            int quan = int.Parse(Console.ReadLine());
                            Console.Write("Codice ISBN: ");
                            string isbn = Console.ReadLine();
                            
                            List<LibriCartacei> TuttiLibriCartacei = DbManagerConnectedMode.GetLibriCartacei();
                            foreach (var item in TuttiLibriCartacei)
                            {
                                if(item.ISBN==isbn)
                                {
                                    Console.WriteLine("Codice ISBN esistente, non puoi aggiungere un libro con lo stesso codice!!");
                                    break;
                                }
                                else
                                {
                                    DbManagerConnectedMode.InserisciLibroCartaceo(titolO, aut, num, quan, isbn);
                                    break;
                                }
                            }
                          
                        }
                        else
                        {
                            Console.WriteLine("INSERISCI UN NUOVO AUDIOLIBRO");
                            Console.Write("Titolo: ");
                            string tito = Console.ReadLine();
                            Console.Write("Autore: ");
                            string auto = Console.ReadLine();
                            Console.Write("Durata: ");
                            int dura = int.Parse(Console.ReadLine());
                            
                            Console.Write("Codice ISBN: ");
                            string isBn = Console.ReadLine();

                            List<AudioLibri> TuttiAudioLibri = DbManagerConnectedMode.GetAudiolibri();
                            foreach (var item in TuttiAudioLibri)
                            {
                                if (item.ISBN == isBn)
                                {
                                    Console.WriteLine("Codice ISBN esistente, non puoi aggiungere un libro con lo stesso codice!!");
                                    break;
                                }
                                else
                                {
                                    DbManagerConnectedMode.InserisciAudioLibro(tito, auto, dura, isBn);
                                    break;
                                }
                            }

                        }
                        break;
                    case "7":
                        Console.Write("indica il titolo del libro: ");
                        string tit = Console.ReadLine();
                        DbManagerConnectedMode.VisualizzaLibro(tit);
                        break;
                }

            } while(scelta!="0");

        }
    }
}
