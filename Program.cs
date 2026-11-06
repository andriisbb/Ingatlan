using Ingatlanok;

List<Ingatlan> ing = new List<Ingatlan>();

if (File.Exists("ingatlanok.txt"))
{
    foreach (string sor in File.ReadAllLines("ingatlanok.txt"))
    {
        if (string.IsNullOrWhiteSpace(sor)) continue;

        string[] adatok = sor.Split(';');
        int db = adatok.Count();
        if (db < 4) continue;
        string azonosito = adatok[0];
        string cim = adatok[1];
        string kategoria = adatok[2];
        if (db == 4)
        {
            if (int.TryParse(adatok[3], out int alapteruletM2))
            {
                Ingatlan ingatlannemtudom = new Ingatlan(azonosito, cim, kategoria, alapteruletM2);
                ing.Add(ingatlannemtudom);
            }
            else
            {
                Console.WriteLine($"[HIBA] A(z) {adatok[0]} azonosítójú eszköz adatai hibásak, átugorva!");
            }
        }
        else if (db == 5)
        {
            if (int.TryParse(adatok[3], out int alapteruletM2) && int.TryParse(adatok[4], out int arEzerFt))
            {
                Ingatlan ingatlannemtudom = new Ingatlan(azonosito, cim, kategoria, alapteruletM2, arEzerFt);
                ing.Add(ingatlannemtudom);
            }
            else
            {
                Console.WriteLine($"[HIBA] A(z) {adatok[0]} azonosítójú eszköz adatai hibásak, átugorva!");
            }
        }

    }

}

//6.
foreach (Ingatlan ingatlan in ing)
{
    Console.WriteLine(ingatlan);
}

//7.
Console.WriteLine($"\nRegisztrált ingatlanok száma a rendszerben: {Ingatlan.OsszesRegisztraltIngatlan} db");

Ingatlan legnagyobb = ing[3];
int osszeg = 0;
foreach (Ingatlan i in ing)
{
    if (i.AlapteruletM2 > legnagyobb.AlapteruletM2)
    {
        legnagyobb = i;

    }
}

//Nem jó
//int ossszeg = 0;
//foreach (Ingatlan i in ing)
//{
//    osszeg += i.ArEzerFt;
//    osszeg = osszeg / i.AlapteruletM2;
//}
Console.WriteLine($"Legnagyobb alapterületű ingatlan:: {legnagyobb.Cim} ({legnagyobb.AlapteruletM2}m2)");

Console.WriteLine($"{Adokalkulator.VagyonszerzesiAdo(osszeg)}");