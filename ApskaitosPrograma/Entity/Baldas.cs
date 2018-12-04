using System;

public partial class Baldas
{

    public Tipas Tipas { get; set; }
    public int Kaina { get; set; }
    public Double Laiko { get; set; }

    public Baldas(Tipas tipas, int kaina, double laiko)
    {
        Tipas = tipas;
        Kaina = kaina;
        Laiko = laiko;
    }
}