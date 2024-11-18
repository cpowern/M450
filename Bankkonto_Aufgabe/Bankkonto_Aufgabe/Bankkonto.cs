using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Bankkonto
    {
        // Attribute, (Eigenschaften)
        public string KontoNummer { get; } // Readonly
        public decimal Guthaben { get; private set; } // Readonly für aussen, intern änderbar
        public decimal AktivZins { get; set; }
        public decimal PassivZins { get; set; }

        // Methoden (Funktionen)

        public Bankkonto(string kontoNummer, decimal startGuthaben)
        {
            KontoNummer = kontoNummer;
            Guthaben = startGuthaben;
        }

        public void ZahleEin(decimal betrag)
        {
            Guthaben += betrag;
        }

        public void Beziehe(decimal betrag)
        {
            if (betrag <= Guthaben)
            {
                Guthaben -= betrag;
            }
        }

        public void SchreibeZinsGut(int anzTage)
        {
            decimal zinsen = Guthaben * (AktivZins / 100) * anzTage / 360;
            Guthaben += zinsen;
        }

        public void SchliesseKontoAb()
        {
            Guthaben = 0;
            Console.WriteLine($"Das Konto {KontoNummer} wurde geschlossen.");
        }

        public void Transferiere(Bankkonto zielKonto, decimal betrag)
        {
            if (betrag <= Guthaben)
            {
                Guthaben -= betrag;        // Betrag vom aktuellen Konto abziehen
                zielKonto.ZahleEin(betrag); // Betrag auf das Zielkonto einzahlen
            }
        }


    }
}
