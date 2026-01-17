using System;

class Program
{
    static Random r = new Random();

    static void Main()
    {
        int[] titolariA = new int[11];
        int[] titolariB = new int[11];

        int golSquadraA = 0;
        int golSquadraB = 0;

        int cartelliniGialliA = 0;
        int cartelliniGialliB = 0;

        int cartelliniRossiA = 0;
        int cartelliniRossiB = 0;

        // forza giocatori A e B
        for (int i = 0; i < 11; i++)
        {
            titolariA[i] = r.Next(30, 101);
            titolariB[i] = r.Next(30, 101);
        }

        int recupero = r.Next(1, 6);

        for (int minuto = 1; minuto <= 90 + recupero; minuto++)
        {
            // stanchezza 
            if (minuto % 15 == 0)
            {
                for (int i = 0; i < 11; i++)
                {
                    if (titolariA[i] > 0) titolariA[i] -= 2;
                    if (titolariB[i] > 0) titolariB[i] -= 2;
                }
                Console.WriteLine("Min " + minuto + ": i giocatori sono stanchi un po");
            }

            // Gol 
            if (r.Next(100) < 2)
            {
                int potA = 0;
                int potB = 0;
                for (int i = 0; i < 11; i++)
                {
                    potA += titolariA[i];
                    potB += titolariB[i];
                }

                if (potA > potB)
                {
                    golSquadraA++;
                    for (int i = 0; i < 11; i++) if (titolariA[i] > 0) titolariA[i]++;
                    Console.WriteLine("Min " + minuto + ": gol squadra A perche piu forte");
                }
                else
                {
                    golSquadraB++;
                    for (int i = 0; i < 11; i++) if (titolariB[i] > 0) titolariB[i]++;
                    Console.WriteLine("Min " + minuto + ": squadra B segna un gol");
                }
            }

            // Cartellino giallo 
            if (r.Next(100) < 7)
            {
                int giocatoreCasuale = r.Next(11);
                for (int i = 0; i < 11; i++)
                {
                    if (i == giocatoreCasuale)
                    {
                        titolariA[i] -= 5;
                        if (titolariA[i] < 0) titolariA[i] = 0;
                        cartelliniGialliA++;
                        Console.WriteLine("Min " + minuto + ": cartellino giallo squadra A");
                    }
                }
            }

            // Cartellino rosso 
            if (r.Next(100) < 1)
            {
                int giocatoreCasuale = r.Next(11);
                for (int i = 0; i < 11; i++)
                {
                    if (i == giocatoreCasuale)
                    {
                        titolariA[i] = 0;
                        cartelliniRossiA++;
                        Console.WriteLine("Min " + minuto + ": cartellino rosso squadra A");
                    }
                }
            }

            // Infortunio 
            if (r.Next(100) < 1)
            {
                int giocatoreCasuale = r.Next(11);
                for (int i = 0; i < 11; i++)
                {
                    if (i == giocatoreCasuale)
                    {
                        titolariA[i] -= 20;
                        if (titolariA[i] < 0) titolariA[i] = 0;
                        Console.WriteLine("Min " + minuto + ": infortunio giocatore A");
                    }
                }
            }


            if (r.Next(100) < 50)
            {
                Console.WriteLine("Min " + minuto + ": non succede niente");
            }
        }

        // stampa risultato finale
        int potFinaleA = 0;
        int potFinaleB = 0;
        for (int i = 0; i < 11; i++)
        {
            potFinaleA += titolariA[i];
            potFinaleB += titolariB[i];
        }

        Console.WriteLine("\nRISULTATO FINALE DELLA PARTITA");
        Console.WriteLine("goal Squadra A: " + golSquadraA);
        Console.WriteLine("goal Squadra B: " + golSquadraB);
        Console.WriteLine("Gialli sqquadraA: " + cartelliniGialliA + " Rossi A: " + cartelliniRossiA);
        Console.WriteLine("Gialli squadra B: " + cartelliniGialliB + " Rossi B: " + cartelliniRossiB);
        Console.WriteLine("overall finale A: " + potFinaleA);
        Console.WriteLine("overall finale B: " + potFinaleB);

    }
}
