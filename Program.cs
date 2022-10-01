Game A = new();
try
{
    A.Menu();
}
catch (Exception) { }


class Game
{
    char[,] mas;
    int str, sto, xod;
    Random rand = new Random();
    public Game()
    {
        xod = 0;
        str = 3;
        sto = 3;
        mas = new char[str, sto];
        RandMas();
    }
    public Game(int s, int o)
    {
        xod = 0;
        str = s;
        sto = o;
        mas = new char[str, sto];
        RandMas();
    }
    public bool Proverka(string A)
    {
        if (A[0] < '1')
            return false;
        for (int i = 0; i < A.Length; i++)
            if (!char.IsDigit(A[i]))
                return false;
        return true;
    }
    public int ProverkaSTO()
    {
        int kolX = 0, kolO = 0;
        for (int i = 0; i < str; i++)
        {
            for (int u = 0; u < sto; u++)
            {
                if (mas[i, u] == 'X')
                    kolX++;
                else if (mas[i, u] == 'O')
                    kolO++;
                else
                    break;
            }
            if (kolX == sto)
                return 1;
            if (kolO == sto)
                return 2;
            kolO = 0;
            kolX = 0;
        }
        return 0;
    }
    public int ProverkaSTR()
    {
        int kolX = 0, kolO = 0;
        for (int i = 0; i < str; i++)
        {
            for (int u = 0; u < sto; u++)
            {
                if (mas[u, i] == 'X')
                    kolX++;
                else if (mas[u, i] == 'O')
                    kolO++;
                else
                    break;
            }
            if (kolX == str)
                return 1;
            if (kolO == str)
                return 2;
            kolO = 0;
            kolX = 0;
        }
        return 0;
    }
    public int ProverkaDIA()
    {
        int kolX = 0, kolO = 0;
        for (int i = 0; i < str; i++)
        {
            for (int u = 0; u < sto; u++)
            {
                if (u == i)
                {
                    if (mas[i, u] == 'X')
                        kolX++;
                    else if (mas[i, u] == 'O')
                        kolO++;
                    else
                        break;
                }
            }
            if (kolX == str)
                return 1;
            if (kolO == str)
                return 2;
        }
        return 0;
    }
    public int ProverkaDIA2()
    {
        int kolX = 0, kolO = 0;
        for (int i = 0; i < str; i++)
        {
            for (int u = 0; u < sto; u++)
            {
                if (u + i == sto - 1)
                {
                    if (mas[i, u] == 'X')
                        kolX++;
                    else if (mas[i, u] == 'O')
                        kolO++;
                    else
                        break;
                }
            }
            if (kolX == str)
                return 1;
            if (kolO == str)
                return 2;
        }
        return 0;
    }
    public void PrintMas()
    {
        for (int i = 0; i < str; i++)
        {
            if (i == 0)
            {
                for (int u = 0; u < sto; u++)
                {
                    Console.Write("\t    "+(u+1));
                }
                Console.WriteLine();
                for (int u = 0; u < sto; u++)
                {
                    Console.Write("\t  -----");
                }
                Console.WriteLine();
            }
            Console.Write(i+1);
            for (int u = 0; u < sto; u++)
            {
                Console.Write("\t|   " + mas[i, u]);
                if (u == sto - 1)
                    Console.Write("\t|");
            }
            Console.WriteLine();
            for (int u = 0; u < sto; u++)
            {
                Console.Write("\t  -----");
            }
            Console.WriteLine();
        }
    }
    public void RandMas()
    {
        for (int i = 0; i < str; i++)
        {
            for (int u = 0; u < sto; u++)
            {
                mas[i, u] = ' ';
            }
        }
        xod = 0;
    }
    public bool VvodX()
    {
        int st, o;
        Console.Clear();
        PrintMas();
        string? pr = "adad";
    re1: Console.WriteLine("Enter coordinates for 'X'.");
        while (!Proverka(pr) || int.Parse(pr) > str)
        {
            Console.Write("str: ");
            pr = Console.ReadLine();
            if (!Proverka(pr) || int.Parse(pr) > str)
                Console.WriteLine("Wrong input.");
        }
        st = int.Parse(pr) - 1;
        pr = "adad";
        while (!Proverka(pr) || int.Parse(pr) > str)
        {
            Console.Write("sto: ");
            pr = Console.ReadLine();
            if (!Proverka(pr) || int.Parse(pr) > str)
                Console.WriteLine("Wrong input.");
        }
        o = int.Parse(pr) - 1;
        if (mas[st, o] == 'X' || mas[st, o] == 'O')
        {
            pr = "adad";
            Console.WriteLine("Error.Enter again.");
            goto re1;
        }
        mas[st, o] = 'X';
        xod++;
        Console.Clear();
        PrintMas();
        if (ProverkaSTO() == 1 || ProverkaSTR() == 1 || ProverkaDIA() == 1 || ProverkaDIA2() == 1)
        {
            Console.WriteLine("\t\t~~~~~~~ 'X' won! ~~~~~~~\n");
            return true;
        }
        if (ProverkaSTO() == 2 || ProverkaSTR() == 2 || ProverkaDIA() == 2 || ProverkaDIA2() == 2)
        {
            Console.WriteLine("\t\t~~~~~~~ 'O' won! ~~~~~~~\n");
            return true;
        }
        if (xod >= str * sto)
        {
            Console.WriteLine("\tNobody won.");
            return false;
        }
        return false;
    }
    public bool VvodO()
    {
        int st, o;
        Console.Clear();
        PrintMas();
        string? pr = "adad";
    re2: Console.WriteLine("Enter coordinates for 'O'.");
        while (!Proverka(pr) || int.Parse(pr) > str)
        {
            Console.Write("str: ");
            pr = Console.ReadLine();
            if (!Proverka(pr) || int.Parse(pr) > str)
                Console.WriteLine("Wrong input.");
        }
        st = int.Parse(pr) - 1;
        pr = "adad";
        while (!Proverka(pr) || int.Parse(pr) > sto)
        {
            Console.Write("sto: ");
            pr = Console.ReadLine();
            if (!Proverka(pr) || int.Parse(pr) > sto)
                Console.WriteLine("Wrong input.");
        }
        o = int.Parse(pr) - 1;
        if (mas[st, o] == 'X' || mas[st, o] == 'O')
        {
            pr = "adad";
            goto re2;
        }
        mas[st, o] = 'O';
        xod++;
        Console.Clear();
        PrintMas();
        if (ProverkaSTO() == 1 || ProverkaSTR() == 1 || ProverkaDIA() == 1 || ProverkaDIA2() == 1)
        {
            Console.WriteLine("\t\t~~~~~~~ 'X' won! ~~~~~~~\n");
            return true;
        }
        if (ProverkaSTO() == 2 || ProverkaSTR() == 2 || ProverkaDIA() == 2 || ProverkaDIA2() == 2)
        {
            Console.WriteLine("\t\t~~~~~~~ 'O' won! ~~~~~~~\n");
            return true;
        }
        if (xod >= str * sto)
        {
            Console.WriteLine("\tNobody won.");
            return false;
        }
        return false;
    }
    public bool BotO()
    {
        bool f = true;
        int s = rand.Next(0,str), g = rand.Next(0, sto);
        while (f)
        {
            if (mas[s, g] == 'X' || mas[s, g] == 'O')
            {
                s = rand.Next(0, str);
                g = rand.Next(0, sto);
            }
            else
            {
                mas[s, g] = 'O';
                xod++;
                f = false;
            }
        }
        Console.WriteLine("Bot is thinking...");
        //this_thread::sleep_for(chrono::milliseconds(rand() % 1000 + 500));
        Console.Clear();
        PrintMas();
        if (ProverkaSTO() == 1 || ProverkaSTR() == 1 || ProverkaDIA() == 1 || ProverkaDIA2() == 1)
        {
            Console.WriteLine("\t\t~~~~~~~ 'X' won! ~~~~~~~\n");
            return true;
        }
        if (ProverkaSTO() == 2 || ProverkaSTR() == 2 || ProverkaDIA() == 2 || ProverkaDIA2() == 2)
        {
            Console.WriteLine("\t\t~~~~~~~ 'O' won! ~~~~~~~\n");
            return true;
        }
        if (xod >= str * sto)
        {
            Console.WriteLine("\tNobody won.");
            return false;
        }
        return false;
    }
    public void Menu()
    {
        char vvod;
        do
        {
            Console.Clear();
            Console.WriteLine("\t1. Game VS Bot.\n\t2. Solo game.");
            vvod = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (vvod)
            {
                case '1':
                    {
                        while (xod < str * sto)
                        {
                            if (VvodX() || xod >= str * sto)
                                break;

                            if (BotO() || xod >= str * sto)
                                break;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        RandMas();
                        break;
                    }
                case '2':
                    {
                        while (xod < str * sto)
                        {
                            if (VvodX() || xod >= str * sto)
                                break;

                            if (VvodO() || xod >= str * sto)
                                break;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        RandMas();
                        break;
                    }
            }

        } while (vvod != 27);
    }

};