using System;


namespace Rabatloty
{
    class Program
    {
        static void Main(string[] args)
        {
            int rabat = 0;
            bool krajowy;
            bool staly;
            DateTime dataUrodzenia = new DateTime();
            DateTime dataLotu = new DateTime();

            Console.WriteLine("Kalkulator rabatu");
            while (true)
            {
                Console.WriteLine("Czy przelot jest krajowy czy miedzynarodowy [K/M]?");
                string line = Console.ReadLine();
                if (line.Equals("K") || line.Equals("k"))
                {
                    //Przelot krajowy
                    krajowy = true;
                    break;
                }
                else if (line.Equals("M") || line.Equals("m"))
                {
                    krajowy = false;
                    break;
                }
                Console.WriteLine("Niepoprawny format.");
            }
            //Pobierz date urodzenia
            bool incorrectFormat = true;
            while (incorrectFormat)
            {
                Console.WriteLine("Prosze podac date urodzenia w formacie DD.MM.YYYY");
                string data = Console.ReadLine();
                try
                {
                    dataUrodzenia = DateTime.Parse(data);
                    incorrectFormat = false;
                }
                catch (Exception e)
                {
                    //Niepoprawny format
                    Console.WriteLine("Niepoprawny format daty.");
                    incorrectFormat = true;
                }
            }

            //Pobierz date lotu
            incorrectFormat = true;
            while (incorrectFormat)
            {
                Console.WriteLine("Na kiedy planujesz lot? DD.MM.YYYY");
                string data = Console.ReadLine();
                try
                {
                    dataLotu = DateTime.Parse(data);
                    incorrectFormat = false;
                }
                catch (Exception e)
                {
                    //Niepoprawny format 
                    Console.WriteLine("Niepoprawny format daty.");
                    incorrectFormat = true;
                }
            }

            while (true)
            {
                Console.WriteLine("Czy jestes stalym klientem? [T/N]"); string line = Console.ReadLine();
                if (line.Equals("T") || line.Equals("t"))
                {
                    //Staly klient
                    staly = true;
                    break;
                }
                else if (line.Equals("N") || line.Equals("n"))
                {
                    staly = false;
                    break;
                }
                Console.WriteLine("Niepoprawny format.");
            }

            double wiek = (DateTime.Now - dataUrodzenia).TotalDays / 365;

            if (wiek >= 2 && wiek < 16)
            {
                rabat += 10;
            }

            if (wiek > 18 && staly)
            {
                rabat += 15;
            }

            if ((dataLotu - DateTime.Now).TotalDays >= 30 * 5)
            {
                //rezerwacja 5 miesiecy przed podroza
                rabat += 10;
            }

            if (krajowy)
            {
                if (wiek < 2)
                    rabat += 80;
            }
            else
            {
                //miedzynarodowy
                if (wiek < 2)
                {
                    rabat += 70;
                    //jest niemowleciem
                }

                bool sezon = false;
                if ((dataLotu.Month == 12 && dataLotu.Day >= 20) ||
                    (dataLotu.Month == 1 && dataLotu.Day <= 10))
                {
                    sezon = true;
                    //sezon
                }
                else if (dataLotu.Month == 3 && dataLotu.Day >= 20)
                {
                    sezon = true;
                    //sezon
                }
                else if (dataLotu.Month == 4 && dataLotu.Day <= 10)
                {
                    sezon = true;
                    //sezon
                }
                else if (dataLotu.Month == 7 || dataLotu.Month == 8)
                {
                    sezon = true;
                    //sezon
                }

                if (sezon && wiek > 2)
                {
                    rabat = 0;
                }
                else
                {
                    rabat += 15;
                }
            }

            //maksimum
            if (wiek < 2 && rabat > 80)
                rabat = 80;
            else if (wiek >= 2 && rabat > 30)
                rabat = 30;

            Console.WriteLine("Rabat wynosi: " + rabat);
        }
    }
}
   
