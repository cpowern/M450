using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankkontoTests
{
    [TestClass]
    public class BankkontoTests
    {
        [TestMethod]
        public void TestGuthabenNull()
        {
            // Arrange
            string kontoNummer = "12345";
            decimal startGuthaben = 1000;

            // Act
            Bankkonto konto = new Bankkonto(kontoNummer, startGuthaben);

            // Assert
            Assert.AreEqual(kontoNummer, konto.KontoNummer);
            Assert.AreEqual(startGuthaben, konto.Guthaben);
        }

        [TestMethod]
        public void EinzahlenTest() 
        {
            //
            Bankkonto konto = new Bankkonto("12345", 1000);
            decimal einzahlung = 500;

            // Act
            konto.ZahleEin(einzahlung);

            // Assert
            Assert.AreEqual(1500, konto.Guthaben);
        }

        [TestMethod]
        public void Beziehe_ZiehtBetragVomGuthabenAb()
        {
            // Arrange
            Bankkonto konto = new Bankkonto("12345", 1000);
            decimal abhebung = 500;

            // Act
            konto.Beziehe(abhebung);

            // Assert
            Assert.AreEqual(500, konto.Guthaben);
        }

        [TestMethod]
        public void Beziehe_BetragNichtGenugGuthaben_VerändertNichts()
        {
            // Arrange
            Bankkonto konto = new Bankkonto("12345", 1000);
            decimal abhebung = 1500;

            // Act
            konto.Beziehe(abhebung);

            // Assert
            Assert.AreEqual(1000, konto.Guthaben);
        }

        [TestMethod]
        public void SchreibeZinsGut_BerechnetUndAddiertZinsen()
        {
            // Arrange
            Bankkonto konto = new Bankkonto("12345", 1000);
            konto.AktivZins = 3; // 3% Jahreszins
            int anzTage = 30;

            // Act
            konto.SchreibeZinsGut(anzTage);

            // Assert
            decimal erwarteterZins = 1000 * (3m / 100) * (30m / 360);
            Assert.AreEqual(1000 + erwarteterZins, konto.Guthaben);
        }

        [TestMethod]
        public void SchliesseKontoAb_SetztGuthabenAufNull()
        {
            // Arrange
            Bankkonto konto = new Bankkonto("12345", 1000);

            // Act
            konto.SchliesseKontoAb();

            // Assert
            Assert.AreEqual(0, konto.Guthaben);
        }

    }
}
