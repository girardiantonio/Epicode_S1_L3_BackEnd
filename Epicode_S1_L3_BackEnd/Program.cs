using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Security.Principal;

namespace Epicode_S1_L3_BackEnd
{
    internal class Program
    {
        public class ContoCorrente
        {
            public bool contoAperto;
            public decimal saldo;

            public ContoCorrente()
            {
                contoAperto = false;
                saldo = 0;
            }

            public void ApriConto(decimal importoInziale)
            {
                if (!contoAperto && importoInziale >= 1000)
                {
                    contoAperto = true;
                    saldo = importoInziale;
                    Console.WriteLine($"Il conto è stato aperto con successo, il saldo attuale è: {saldo}");
                }
                else
                {
                    Console.WriteLine($"Impossibile aprire il conto con {importoInziale} euro. Assicurati di avere almeno 1000 euro iniziali.");
                }
            }
            public void Versa(decimal importo)
            {
                if (contoAperto == true && importo > 0)
                {
                    saldo += importo;
                    Console.WriteLine($"Il versamento di {importo} euro è stato effettuato. Il nuovo saldo è: {saldo}");
                }
                else if (contoAperto == false)
                {
                    Console.WriteLine("Impossibile effettuare il versamento. Non hai un conto aperto.");
                }
                else
                {
                    Console.WriteLine("Impossibile effettuare il versamento.");
                }
            }

            public void Preleva(decimal importo)
            {
                if (contoAperto == true && importo >= 0 && saldo >= importo)
                {
                    saldo -= importo;
                    Console.WriteLine($"Il prelievo di {importo} euro è stato effettuato. Il nuovo saldo è: {saldo}");
                }
                else if (contoAperto == false)
                {
                    Console.WriteLine("Impossibile effettuare il prelievo. Non hai un conto aperto.");
                }
                else
                {
                    Console.WriteLine($"Impossibile effettuare il prelievo di {importo}, saldo disponibile {saldo}");
                }
            }

            public decimal GetSaldo()
            {
                return saldo;
            }

            static void Main(string[] args)
            {
                Console.WriteLine("++++ESERCIZIO 1 CONTO CORRENTE++++");
                Console.WriteLine("++++CONTO 1 CON 1500 EURO INIZIALI++++");
                ContoCorrente Conto1 = new ContoCorrente();
                Conto1.ApriConto(1500);
                Conto1.Versa(500);
                Conto1.Preleva(1300);
                decimal Saldo1 = Conto1.GetSaldo();
                Console.WriteLine($"Saldo attuale: {Saldo1} euro");
                Console.WriteLine("++++CONTO 1 CON 1500 EURO INIZIALI++++");
                Console.ReadLine();

                Console.WriteLine("++++CONTO 2 CON 1000 EURO INIZIALI++++");
                ContoCorrente Conto2 = new ContoCorrente();
                Conto2.ApriConto(1000);
                Conto2.Versa(100);
                Conto2.Preleva(1500);
                decimal Saldo2 = Conto2.GetSaldo();
                Console.WriteLine($"Saldo attuale: {Saldo2} euro");
                Console.WriteLine("++++CONTO 2 CON 1000 EURO INIZIALI++++");
                Console.ReadLine();

                Console.WriteLine("++++CONTO 3 CON 500 EURO INIZIALI++++");
                ContoCorrente Conto3 = new ContoCorrente();
                Conto3.ApriConto(500);
                Conto3.Versa(200);
                Conto3.Preleva(300);
                decimal Saldo3 = Conto3.GetSaldo();
                Console.WriteLine($"Saldo attuale: {Saldo3} euro");
                Console.WriteLine("++++CONTO 3 CON 500 EURO INIZIALI++++");
                Console.WriteLine("++++ESERCIZIO 1 CONTO CORRENTE++++");
                Console.ReadLine();



                Console.WriteLine("++++ESERCIZIO 2 CON ARRAY NOMI++++");
                Console.WriteLine("Quanti nomi vuoi inserire (numero):");
                int numeroNomi = int.Parse(Console.ReadLine());
                string[] nomi = new string[numeroNomi];
                Console.WriteLine("Inserisci i nomi:");
                for (int i = 0; i < nomi.Length; i++)
                {
                    nomi[i] = Console.ReadLine();
                }
                Console.WriteLine("Qual'è il nome che vuoi verificare?:");
                string nome = Console.ReadLine();
                bool presente = false;
                for (int i = 0; i < nomi.Length; i++)
                {
                    if (nome == nomi[i])
                    {
                        presente = true;
                        break;
                    }
                }
                if (presente)
                {
                    Console.WriteLine($"Il nome {nome} è presente nella lista");
                }
                else
                {
                    Console.WriteLine("Il nome non è presente in lista");
                }
                Console.WriteLine("++++ESERCIZIO 2 CON ARRAY NOMI++++");
                Console.ReadLine();



                Console.WriteLine("++++ESERCIZIO 3 CON ARRAY NUMERI++++");
                Console.WriteLine("Quanti numeri vuoi inserire (numero):");
                int numeroNumeri = int.Parse(Console.ReadLine());
                int[] numeri = new int[numeroNumeri];
                Console.WriteLine("Inserisci i numeri:");
                for (int i = 0; i < numeri.Length; i++)
                {
                    numeri[i] = int.Parse(Console.ReadLine());
                }
                decimal somma = 0;
                decimal media = 0;
                foreach (int numero in numeri) 
                {
                    somma += numero;

                    media = somma / numeroNumeri;
                }
                Console.WriteLine($"La somma dei numeri è: {somma}");
                Console.WriteLine($"La media dei numeri è: {media}");
                Console.WriteLine("++++ESERCIZIO 3 CON ARRAY NUMERI++++");
                Console.ReadLine();
            }
        }
    }
}
