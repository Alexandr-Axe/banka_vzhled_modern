using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banka_Vzhled
{
    public class Ucet
    {
        public double Zustatek { get; set; }
        public double Urok { get; set; }
        public int PIN { get; set;  }
        public string Nazev { get; set; }
        public DateTime DatumZalozeni { get; set; }
        public string TypUctu { get; set; }
        public Ucet(string nazev, double zustatek, double urok, int pin, DateTime datumZalozeni)
        {
            Zustatek = zustatek;
            Urok = urok;
            PIN = pin;
            Nazev = nazev;
            DatumZalozeni = datumZalozeni;
        }
    }
    public class Sporici : Ucet
    {
        public Sporici(string nazev, double zustatek, double urok, int pin, DateTime datumZalozeni) : base(nazev, zustatek, urok, pin, datumZalozeni)
        {
            TypUctu = "Spořící";
        }
        public override string ToString() => $"Název účtu : {Nazev}\nTyp : {TypUctu}\nZůstatek na účtě : {Zustatek} Kč\nMěsíční úrok : {Urok}%\nDatum splátky : {DatumZalozeni.ToString("dd/MM/yyyy")}\nDatum úročení : {DatumZalozeni.AddMonths(1).ToString("dd/MM/yyyy")}";
    }
    public class Studentsky : Sporici
    {
        public int MaxVyber { get; set; }
        public Studentsky(string nazev, double zustatek, double urok, int pin, int maxVyber, DateTime datumZalozeni) : base(nazev, zustatek, urok, pin, datumZalozeni)
        {
            MaxVyber = maxVyber;
            TypUctu = "Spořící studentský";
        }
        public override string ToString() => $"Název účtu : {Nazev}\nTyp : {TypUctu}\nZůstatek na účtě : {Zustatek} Kč\nMěsíční úrok : {Urok}%\nMaximální výběr : {MaxVyber}Kč\nDatum splátky : {DatumZalozeni.ToString("dd/MM/yyyy")}\nDatum úročení : {DatumZalozeni.AddMonths(1).ToString("dd/MM/yyyy")}";
    }

    public class Kreditni : Ucet
    {
        //Nula je maximální hodnota, pokud přelezu nulu, banka mi peníze vrátí
        //Při koupi budu mít hodnotu < 0
        //Další měsíc mám základ < 0 (mínus, kde jsem skončil)
        //Možnost zaplatit peníze, abych se dostal z mínusu

        public double ChybiSplatit { get; set; }

        public Kreditni(string nazev, double zustatek, double urok, int pin, DateTime datumZalozeni) : base(nazev, zustatek, urok, pin, datumZalozeni)
        {
            TypUctu = "Kreditní";
        }
        public override string ToString() => $"Název účtu : {Nazev}\nTyp : {TypUctu}\nMaximální půjčka : {Zustatek} Kč\nMěsíční úrok : {Urok}%\nDatum splátky : {DatumZalozeni.ToString("dd/MM/yyyy")}\nDatum úročení : {DatumZalozeni.AddMonths(1).ToString("dd/MM/yyyy")}";
    }
}