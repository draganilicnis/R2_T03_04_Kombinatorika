using System;
class R2_T03_Rek_04_Komb_Ver_001
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());                  // N: Broj elemenata skupa
        int k = int.Parse(Console.ReadLine());                  // K: Duzina
        
        int[] a = new int[k];                                   // Rekurzivno
        Varijacija_Sledeca_Izracunaj_Rekurz(a, n, k);           // Rekurzivno

        //Varijacije_Iter(n, k);                                  // Iterativno
    }

    static void Niz_Ispisi(int[] a)                             // IZLAZ: Ispisivanje vrednosti elemenata niza
    {
        int n = a.Length;                                       // Duzina niza
        for (int i = 0; i < n; i++) Console.Write(a[i] + " ");
        Console.WriteLine();
    }

    // Rekurzivno
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

    // Iterativno (leksikografski)
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
}
