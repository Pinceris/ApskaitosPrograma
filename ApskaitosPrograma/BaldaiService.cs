using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class BaldaiService
{

    public static List<Baldas> getBaldai()
    {
        List<Baldas> bSarasas = new List<Baldas>();

        string q = "select Pavadinimas, Kaina, Laikas from baldai";

        using (MySqlConnection con = MySqlService.getConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand(q, con))
            {
                con.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var ws = new Baldas("", 0, 0);
                    ws.Pavadinimas = reader.GetString("Pavadinimas");
                    ws.Kaina = reader.GetInt32("Kaina");
                    ws.Laiko = reader.GetInt32("Laikas");
                    bSarasas.Add(ws);
                }
                reader.Close();
                return bSarasas;
            }
        }
    }
}