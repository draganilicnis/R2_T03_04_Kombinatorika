// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka2/sledeca_varijacija
// https://arena.petlja.org/sr-Latn-RS/competition/r2-t03-rekurzije-04-kombinatorika#tab_132187
// Sledeca varijacija duzine k od n elemenata u leksikografskom poretku
// Primer:
// K = 3    => Duzina          3 
// N = 2    => Broj elemenata  2 (ti elementi su 1, 2)
// Varijacije su (ukupno ih ima 8 = 2^3): 111 112 121 122 211 212 221 222
//    ako bi brojevi bili od 0 do n-1   : 000 001 010 011 100 101 110 111

using System;
class R2_T03_Rekurzije_04_Kombinatorika
{
    static void Main()
    {
        Varijacija();
    }
    static void Varijacija()
    {
        int k = int.Parse(Console.ReadLine());              // k: 1 <= k <= 100 : Varijacija duzine k       : 5
        int n = int.Parse(Console.ReadLine());              // n: 1 <= n <= 100 : Varijacija od n elemenata : 4
        int[] a = new int[k];                               // a: Varijacija duzine k od n elemenata        : 1 1 2 3 4
        string[] s = Console.ReadLine().Split();            // ULAZ 3. linija: Varijacija                   : 1 1 2 3 4
        for (int i = 0; i < k; i++) a[i] = int.Parse(s[i]);

        Varijacija_Sledeca(a, n);
        // while (Varijacija_Sledeca(n, a)) { }             // Ukoliko zelimo da ispise sve sledece varijacije 
        // int p=0; while (Varijacija_Sledeca(n, a)) p++;   // Ukoliko zelimo da ispise sve sledece varijacije i da ih prebroji (koliko ima sledecih varijacija)
    }

    static bool Varijacija_Sledeca(int[] a, int n)
    {
        bool bVarijacija_Sledeca_Postoji = Varijacija_Sledeca_Izracunaj(a, n);
        if (bVarijacija_Sledeca_Postoji) Varijacija_Ispisi(a);  // Ako postoji sledeca varijacija ispisuje se
        else Console.WriteLine("-");                            // Ako ne postoji sledeca varijacija (ako su svih k brojeva n: 4 4 4 4 4
        return bVarijacija_Sledeca_Postoji;
    }
    static bool Varijacija_Sledeca_Izracunaj(int[] a, int n)
    {
        int k = a.Length;                                       // k: 1 <= k <= 100 : Varijacija duzine k   : 5
        int i = k - 1;                                          // Od kraja varijacije (sa desne strane) tražimo prvi element koji se moze povecati
        for (i = k - 1; i >= 0 && a[i] == n; i--) a[i] = 1;     // i istovremeno sve elemente sa desne strane (od kraja do prelomne tacke) postavljamo na najmanju vrednost: 1
        if (i < 0) return false;                                // Samo ako su svi elementi jednaki n => ne postoji naredna varijacija
        a[i]++;                                                 // Uvecavamo element koji je moguće uvecati
        return true;
    }
    static void Varijacija_Ispisi(int[] a)
    {
        foreach (int x in a) Console.Write(x + " ");
        Console.WriteLine();
    }
}
