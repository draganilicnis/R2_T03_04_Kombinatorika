using System;
class R2_T03_Rek_04_Komb_Dopuna_binarnih_nizova_bez_susednih_1_v004
{
    static void Main()
    {
        //int n = int.Parse(Console.ReadLine());                  // N: Broj elemenata skupa
        //int k = int.Parse(Console.ReadLine());                  // K: Duzina
        string s = Console.ReadLine();                          // ULAZ: Ulazni string (delimicno popunjen niz nula i jedinica: 1...0
        int n = 2;                                              // N: Broj elemenata skupa = 2 = {0, 1}
        int k = s.Length;                                       // K: Duzina
        Varijacije_Iter(n, k, s);                               // Iterativno
    }
    // Iterativno (leksikografski)
    static void Varijacije_Iter(int n, int k, string s)         // Iterativno
    {
        int[] a = new int[k];
        for (int i = 0; i < k; i++)                             // Inicijalizacija: Prva varijacija 
            if (s[i] == '1') a[i] = 1;
        do
            //if (!Niz_ima_2_susedne_jedinice(a))
                Niz_Ispisi(a);
        while (Varijacija_Sledeca_Izracunaj(a, n, s));          // Dok postoji sledeca varijacija
    }
    static bool Varijacija_Sledeca_Izracunaj(int[] a, int n, string s)  // Iterativno sledeca
    {
        int k = a.Length;                                       // Duzina niza
        int i = k - 1;                                          // Pozicija poslednjeg elementa u nizu (najmanje tezine)
        for (i = k - 1; i >= 0 && (a[i] == n - 1 || s[i] != '.'); i--) 
            if (s[i] == '.')
                a[i] = 0;                                       // Sledeca varijacija
        if (i < 0) return false;                                // Ako je poslednja varijacija, odnosno ne postoji sledeca varijacija
        while (i >= 0 && ((s[i] != '.') || (a[i] == n - 1) || (i > 0 && a[i - 1] == n - 1) || (i < k - 1 && a[i + 1] == n - 1)))
        {
            if (a[i] == n - 1 && s[i] == '.') a[i] = 0;
            i--;                                                // Ako treba postaviti 1 na poziciji i potrebno je proveriti da li ima susednih 1
        }
        if (i < 0) return false;                                // Ako je poslednja varijacija, odnosno ne postoji sledeca varijacija
        a[i]++;                                                 // Ako postoji sledeca varijacija
        return true;
    }
    static bool Niz_ima_2_susedne_jedinice(int[] a)
    {
        bool bDve_susedne_jedinice = false;
        int k = a.Length;
        int i = 0;
        while (i < k - 1 && !bDve_susedne_jedinice)
        {
            if (a[i] == 1 && a[i + 1] == 1)
                bDve_susedne_jedinice = true;
            i++;
        }
        return bDve_susedne_jedinice;
    }
    static void Niz_Ispisi(int[] a)                             // IZLAZ: Ispisivanje vrednosti elemenata niza
    {
        int n = a.Length;                                       // Duzina niza
        for (int i = 0; i < n; i++) Console.Write(a[i]);
        Console.WriteLine();
    }
}
