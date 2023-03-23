using System;
using System.Diagnostics.CodeAnalysis;
using UlamekBiblioteka;

namespace UłamekDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(Ułamek.Info());

            //Ułamek u13 = new Ułamek(1, 3);
            //Ułamek u2 = new Ułamek(2);
            //Ułamek u0 = Ułamek.Zero;
            //Ułamek u12 = Ułamek.Połowa;

            //Console.WriteLine(u13.ToString());
            //Console.WriteLine(u2.ToString());
            //Console.WriteLine(u0.ToString());
            //Console.WriteLine(u12.ToString());

            //Ułamek uP = new Ułamek() { Licznik = 1, Mianownik = 2 };
            //Console.WriteLine(uP);

            Ułamek a = Ułamek.Połowa;
            Ułamek b = Ułamek.Ćwierć;

            //Console.WriteLine("a+b=1/2+1/4 " + (a + b));
            //Console.WriteLine("a-b=1/2-1/4 " + (a - b));
            //Console.WriteLine("b-a=1/4-1/2 " + (b - a));
            //Console.WriteLine("a*b=1/2*1/4 " + (a * b));
            //Console.WriteLine("a/b=1/2/1/4 " + (a / b));

            //Console.WriteLine("a<b=1/2<1/4 " + (a < b));
            //Console.WriteLine("a>b=1/2>1/4 " + (a > b));
            //Console.WriteLine("a#b=1/2#1/4 " + a.GetHashCode() + "  "+ b.GetHashCode());
            //Console.WriteLine("a==b 1/2==1/4 " + (a == b));
            //Console.WriteLine("a>=b 1/2>=1/4 " + (a >= b));
            //Console.WriteLine("a<=b 1/2<=1/4 " + (a <= b));
            //Console.WriteLine("a!=b 1/2!=1/4 " + (a != b));
            //Console.WriteLine("a.equals(b) 1/2 1/4 " + a.Equals(b));

            Console.WriteLine("(double)a " + (double)new Ułamek(1,3));
            Ułamek c = 4;
            Console.WriteLine("(Ułamek)a " + c);

            Ułamek[] tablica = new Ułamek[10];
            for(int i=0; i<tablica.Length; i++)
            {
                tablica[i] = new Ułamek(1, i + 1);
            }
            foreach(Ułamek u in tablica)
            {
                Console.WriteLine(u + " = " + (double)u);
            }

            Array.Sort(tablica);

            foreach (Ułamek u in tablica)
            {
                Console.WriteLine(u + " = " + (double)u);
            }
        }

    }
}
