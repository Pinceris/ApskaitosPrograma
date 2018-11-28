using System;

public class Baldas
{
    public string Pavadinimas { get; set; }
    public int Kaina { get; set; }
    public Double Laiko { get; set; }
    public Baldas(string pavadinimas, int kaina, double laiko)
    {
        Pavadinimas = pavadinimas;
        Kaina = kaina;
        Laiko = laiko;
    }
}