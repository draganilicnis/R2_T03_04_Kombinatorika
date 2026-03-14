using System;
class R2_T03_Rek_04_Komb_Dopuna_binarnih_nizova_bez_susednih_1_v001
{
    static void Main()
    {
        //int n = int.Parse(Console.ReadLine());                  // N: Broj elemenata skupa
        //int k = int.Parse(Console.ReadLine());                  // K: Duzina
        string s = Console.ReadLine();                          // ULAZ: Ulazni string (delimicno popunjen niz nula i jedinica: 1...0
        int n = 2;                                              // N: Broj elemenata skupa = 2 = {0, 1}
        int k = s.Length;                                       // K: Duzina
        Varijacije_Iter(n, k);                                  // Iterativno
    }
    // Iterativno (leksikografski)
    static void Varijacije_Iter(int n, int k)                   // Iterativno
    {
        int[] a = new int[k];
        for (int i = 0; i < k; i++) a[i] = 0;                   // Inicijalizacija: Prva varijacija. Ako vrednosti mogu da budu od 1 do n (a ne od 0 do n-1)
        do
            Niz_Ispisi(a);
        while (Varijacija_Sledeca_Izracunaj(a, n));             // Dok postoji sledeca varijacija
    }
    static bool Varijacija_Sledeca_Izracunaj(int[] a, int n)    // Iterativno sledeca
    {
        int k = a.Length;                                       // Duzina niza
        int i = k - 1;                                          // Pozicija poslednjeg elementa u nizu (najmanje tezine)
        for (i = k - 1; i >= 0 && a[i] == n - 1; i--) 
            a[i] = 0;                                           // Sledeca varijacija
        if (i < 0) return false;                                // Ako je poslednja varijacija, odnosno ne postoji sledeca varijacija
        a[i]++;                                                 // Ako postoji sledeca varijacija
        return true;
    }
    static void Niz_Ispisi(int[] a)                             // IZLAZ: Ispisivanje vrednosti elemenata niza
    {
        int n = a.Length;                                       // Duzina niza
        for (int i = 0; i < n; i++) Console.Write(a[i]);
        Console.WriteLine();
    }
}
