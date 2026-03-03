using System;
class R2_T03_Rek_04_Komb_Ver_000
{
    static void Main()
    {
        // Dvocifreni();
        // Sat3();
        // Binarni_duzine_4();

        int n = int.Parse(Console.ReadLine());                  // N: Broj elemenata skupa
        int k = int.Parse(Console.ReadLine());                  // K: Duzina
        
        Varijacije_Iter(n, k);                                  // Iterativno
        
        //int[] a = new int[k];                                 // Rekurzivno
        //Varijacija_Sledeca_Izracunaj_Rekurz(a, n, k);         // Rekurzivno
    }

    static void Dvocifreni()                                    // O(N^2)
    {
        for (int d = 0; d <= 9; d++)
            for (int j = 0; j <= 9; j++)
                Console.WriteLine(d + "" + j);
    }
    static void Sat3()                                          // O(N^3)
    {
        for (int h = 0; h <= 23; h++)                           // H: sat od 0 do 23
            for (int m = 0; m <= 59; m++)                       // M: min od 0 do 59
                for (int s = 0; s <= 59; s++)                   // S: sek od 0 do 59
                    Console.WriteLine(h + ":" + m + ":" + s);   // Cekanje (Wait) 1 sekundu?
    }
    static void Binarni_duzine_2()                              // O(N^2)
    {
        for (int i = 0; i <= 1; i++)
            for (int j = 0; j <= 1; j++)
                Console.WriteLine(i + "" + j);
    }
    static void Binarni_duzine_3()                              // O(N^3)
    {
        for (int i = 0; i <= 1; i++)
            for (int j = 0; j <= 1; j++)
                for (int k = 0; k <= 1; k++)
                    Console.WriteLine(i + "" + j + "" + k);
    }
    static void Binarni_duzine_4()                              // O(N^4)
    {
        for (int i = 0; i <= 1; i++)
            for (int j = 0; j <= 1; j++)
                for (int k = 0; k <= 1; k++)
                    for (int l = 0; l <= 1; l++)
                        Console.WriteLine(i + "" + j + "" + k + "" + l);
    }

    static void Niz_Ispisi(int[] a)                             // IZLAZ: Ispisivanje vrednosti elemenata niza
    {
        int n = a.Length;                                       // Duzina niza
        for (int i = 0; i < n; i++) Console.Write(a[i] + " ");
        Console.WriteLine();
    }
    static void Varijacije_Iter(int n, int k)                   // Iterativno
    {
        int[] a = new int[k];
        for (int i = 0; i < k; i++) a[i] = 1;                   // Ako vrednosti mogu da budu od 1 do n (a ne od 0 do n-1)
        do
            Niz_Ispisi(a);
        while (Varijacija_Sledeca_Izracunaj(a, n));             // Dok postoji sledeca varijacija
    }
    static bool Varijacija_Sledeca_Izracunaj(int[] a, int n)    // Iterativno sledeca
    {
        int k = a.Length;                                       // Duzina niza
        int i = k - 1;                                          // Pozicija poslednjeg elementa u nizu (najmanje tezine)
        for (i = k - 1; i >= 0 && a[i] == n; i--) a[i] = 1;     // Inicijalizacija: Prva varijacija
        if (i < 0) return false;                                // Ako je poslednja varijacija, odnosno ne postoji sledeca varijacija
        a[i]++;                                                 // Ako postoji sledeca varijacija
        return true;
    }
    static void Varijacija_Sledeca_Izracunaj_Rekurz(int[] a, int n, int k)  // Rekurzivno
    {
        if (k == 0) Niz_Ispisi(a);
        else
            for (int v = 1; v <= n; v++)
            {
                a[a.Length - k] = v;
                Varijacija_Sledeca_Izracunaj_Rekurz(a, n, k - 1); 
            }
    }
}
