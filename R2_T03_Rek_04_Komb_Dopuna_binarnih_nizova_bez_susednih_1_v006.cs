using System;
using System.Text;
class R2_T03_Rek_04_Komb_Dopuna_binarnih_nizova_bez_susednih_1_v006
{
    static void Main()
    {
        string s = Console.ReadLine();                          // ULAZ: Ulazni string (delimicno popunjen niz nula i jedinica: 1...0
        Varijacije_Iter(s);                                     // Iterativno
    }
    // Iterativno (leksikografski)
    static void Varijacije_Iter(string s)                       // Iterativno
    {
        int k = s.Length;                                       // Duzina niza
        int[] a = new int[k];
        for (int i = 0; i < k; i++)                             // Inicijalizacija: Prva varijacija 
            if (s[i] == '1') a[i] = 1;
        do
            Niz_Ispisi(a);
        while (Varijacija_Sledeca_Izracunaj(a, s));             // Dok postoji sledeca varijacija
    }
    static bool Varijacija_Sledeca_Izracunaj(int[] a, string s) // Iterativno sledeca
    {
        int k = a.Length;                                       // Duzina niza
        // Korak 0: Pronalazenje (s desne strane) prve prazne pozicije i na kojoj vrednost nije 1 (odnosno prve nule, koju bi trebalo da postavimo na 1)
        int i = k - 1;                                          // Pozicija poslednjeg elementa u nizu (najmanje tezine)
        for (i = k - 1; i >= 0 && (a[i] == 1 || s[i] != '.'); i--) 
            if (s[i] == '.')
                a[i] = 0;                                       // Sledeca varijacija
        if (i < 0) return false;                                // Ako je poslednja varijacija, odnosno ne postoji sledeca varijacija

        // Samo ako nije poslednja varijacija
        // Korak 1: Postavljanje prve jedinice (na prvoj sledecoj poziciji i) pod uslovom da nema susednih jedinica
        while (i >= 0 && ((s[i] != '.') || (a[i] == 1) || (i > 0 && a[i - 1] == 1) || (i < k - 1 && a[i + 1] == 1)))
        {
            if (a[i] == 1 && s[i] == '.') a[i] = 0;
            i--;                                                
        }
        if (i < 0) return false;                                // Ako je poslednja varijacija, odnosno ne postoji sledeca varijacija

        // Samo ako nije poslednja varijacija
        // Korak 2: Samo ako je pronadjena prva prazna pozicija i (pretagom s desne strane) na kojoj nema susednih jedinica
        a[i]++;                                                 // Inkrementiramo vrednost samo na toj poziciji i
        return true;
    }
    static void Niz_Ispisi(int[] a)                             // IZLAZ: Ispisivanje vrednosti elemenata niza
    {
        int n = a.Length;                                       // Duzina niza
        StringBuilder s = new StringBuilder();
        for (int i = 0; i < n; i++) s.Append(a[i]);             // Console.Write(a[i]);
        Console.WriteLine(s);                                   // Console.WriteLine();
    }
}
