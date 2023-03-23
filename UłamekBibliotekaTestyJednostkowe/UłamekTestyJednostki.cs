using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UlamekBiblioteka;

namespace UłamekBibliotekaTestyJednostkowe
{
    [TestClass]
    public class UłamekTestyJednostki
    {
        [TestMethod]
        public void TestKonstruktoraIWłasności()
        {
            //przygotowanie - arrange
            int licznik = 1;
            int mianownik = 2;


            //działanie - act
            Ułamek u = new Ułamek(licznik, mianownik);


            //weryfikacja - assert
            Assert.AreEqual(licznik, u.Licznik, "Niezgodność w liczniku");
            Assert.AreEqual(mianownik, u.Mianownik, "Niezgodność w mianowniku");
        }
        [TestMethod]
        public void TestKonstruktora()
        {
            int licznik = 1;
            int mianownik = 2;

            Ułamek u = new Ułamek(licznik, mianownik);

            PrivateObject po = new PrivateObject(u);
            int u_licznik = u.Licznik;
            int u_mianownik = (int)po.GetField("mianownik");

            Assert.AreEqual(licznik, u.Licznik, "Niezgodność w liczniku");
            Assert.AreEqual(mianownik, u.Mianownik, "Niezgodność w mianowniku");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestKonstruktoraWyjątek()
        {
            Ułamek u = new Ułamek(1, 0);
        }
        [TestMethod]
        public void TestMetodyUprość()
        {
            Ułamek u = new Ułamek(4, -2);

            u.Uprość();

            Assert.AreEqual(-2, u.Licznik);
            Assert.AreEqual(1, u.Mianownik);
        }
        [TestMethod]
        public void TestOperatorów()
        {
            Ułamek a = Ułamek.Połowa;
            Ułamek b = Ułamek.Ćwierć;



            Assert.AreEqual(new Ułamek(3, 4), a + b, "niepowodzenie przy dodawaniu");
            Assert.AreEqual(new Ułamek(1, 8), a * b, "niepowodzenie przy mnożeniu");
            Assert.AreEqual(Ułamek.Ćwierć, a - b, "niepowodzenie przy odejmowaniu");
            Assert.AreEqual(2, a / b, "niepowodzenie przy dzieleniu");
        }
        Random r = new Random();
        private int losujLiczbęCałkowitą(int? maksymalnaWartośćBezwzględna = null)
        {
            if (!maksymalnaWartośćBezwzględna.HasValue)
            {
                return r.Next(int.MinValue, int.MaxValue);
            }
            else
            {
                maksymalnaWartośćBezwzględna = Math.Abs(maksymalnaWartośćBezwzględna.Value);
                return r.Next(-maksymalnaWartośćBezwzględna.Value, maksymalnaWartośćBezwzględna.Value);
            }
        }
        private int losujLiczbęCałkowitąBezZera(int? maksymalnaWartośćBezwzględna = null)
        {
            int wartość;
            do
            {
                wartość = losujLiczbęCałkowitą(maksymalnaWartośćBezwzględna);
            } while (wartość == 0);
            return wartość;
        }
        [TestMethod]
        public void TestSortowania()
        {
            for (int j = 0; j < 100; j++)
            {
                Ułamek[] tablica = new Ułamek[100];
                for (int i = 0; i < tablica.Length; i++)
                {
                    tablica[i] = new Ułamek(losujLiczbęCałkowitą(), losujLiczbęCałkowitąBezZera());
                }
                Array.Sort(tablica);

                bool tablicaJestPosortowana = true;

                for (int i = 0; i < tablica.Length - 1; i++)
                {
                    if (tablica[i] > tablica[i + 1]) tablicaJestPosortowana = false;
                }
                Assert.IsTrue(tablicaJestPosortowana);
            }
        }
        [TestMethod]
        public void TestMetodyUprośćLosowy()
        {
            
            for (int j = 0; j < 100; j++)
            {
                Ułamek u = new Ułamek(losujLiczbęCałkowitą(), losujLiczbęCałkowitąBezZera());
                Ułamek kopia = u;
                u.Uprość();
                
                Assert.IsTrue(u.Mianownik>0);
                Assert.AreEqual(kopia.ToDouble(), u.ToDouble());
            }
        }
    }
}
