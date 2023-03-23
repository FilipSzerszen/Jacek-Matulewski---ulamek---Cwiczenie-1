using System;
using System.Diagnostics.CodeAnalysis;

namespace UlamekBiblioteka 
{
    public struct Ułamek : IComparable<Ułamek>
    {
        private int mianownik;

        public Ułamek(int licznik, int mianownik = 1)
            : this()
        {

            {
                this.Licznik = licznik;
                this.Mianownik = mianownik;
            }

        }
        public static readonly Ułamek Zero = new Ułamek(0);
        public static readonly Ułamek Jeden = new Ułamek(1);
        public static readonly Ułamek Połowa = new Ułamek(1, 2);
        public static readonly Ułamek Ćwierć = new Ułamek(1, 4);

        public static string Info()
        {
            return "Struktura Ułamek";
        }
        public override string ToString()
        {
            return Licznik.ToString() + "/" + mianownik.ToString();
        }
        public readonly double ToDouble()
        {
            return Licznik / (double)(mianownik);
        }
        public void Uprość()
        {
            int a = Licznik;
            int b = mianownik;
            int c;

            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            Licznik /= a;
            mianownik /= a;

            if (Math.Sign(Licznik) * Math.Sign(mianownik) < 0)
            {
                Licznik = -Math.Abs(Licznik);
                mianownik = Math.Abs(mianownik);
            }
            else
            {
                Licznik = Math.Abs(Licznik);
                mianownik = Math.Abs(mianownik);
            }
        }
        #region Własności
        public int Licznik { get; set; }

        //{
        //    get => licznik;
        //    set => licznik = value;
        //}
        public int Mianownik
        {
            get => mianownik;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Mianownik nie może być zerem!");
                }
                else
                {
                    mianownik = value;
                }
            }
        }
        #endregion

        #region Operatory arytmetyczne

        public static Ułamek operator -(Ułamek u)
        {
            return new Ułamek(-u.Licznik, u.Mianownik);
        }

        public static Ułamek operator +(Ułamek u)
        {
            return u;
        }

        public static Ułamek operator +(Ułamek u1, Ułamek u2)
        {
            Ułamek wynik = new Ułamek(u1.Licznik * u2.Mianownik+u2.Licznik * u1.Mianownik, u1.Mianownik * u2.Mianownik);
            wynik.Uprość();
            return wynik;
        }

        public static Ułamek operator -(Ułamek u1, Ułamek u2)
        {
            Ułamek wynik = new Ułamek(u1.Licznik * u2.Mianownik - u2.Licznik * u1.Mianownik, u1.Mianownik * u2.Mianownik);
            wynik.Uprość();
            return wynik;
        }

        public static Ułamek operator *(Ułamek u1, Ułamek u2)
        {
            Ułamek wynik = new Ułamek(u1.Licznik * u2.Licznik, u1.Mianownik * u2.Mianownik);
            wynik.Uprość();
            return wynik;
        }

        public static Ułamek operator /(Ułamek u1, Ułamek u2)
        {
            Ułamek wynik = new Ułamek(u1.Licznik * u2.Mianownik, u1.Mianownik * u2.Licznik);
            wynik.Uprość();
            return wynik;
        }
        #endregion

        #region Operatory porównania
        public static bool operator ==(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() == u2.ToDouble());
        }
        public static bool operator !=(Ułamek u1, Ułamek u2)
        {
            return !(u1.ToDouble() == u2.ToDouble());
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Ułamek)) return false;
            Ułamek u = (Ułamek)obj;
            return (this == u);
        }
        public override int GetHashCode()
        {
            return (Licznik^Mianownik);
        }

        public static bool operator <(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() < u2.ToDouble());
        }

        public static bool operator >(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() > u2.ToDouble());
        }
        public static bool operator <=(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() <= u2.ToDouble());
        }

        public static bool operator >=(Ułamek u1, Ułamek u2)
        {
            return (u1.ToDouble() >= u2.ToDouble());
        }
        #endregion

        #region Operatory konwersji
        public static explicit operator double(Ułamek u)
        {
            return u.ToDouble();
        }
        public static implicit operator Ułamek(int u)
        {
            return new Ułamek(u);
        }
        #endregion

        public int CompareTo(Ułamek other)
        {
            double różnica = this.ToDouble()-other.ToDouble();
            if (różnica != 0) różnica /= Math.Abs(różnica);
            return (int)różnica;
        }
    }
}
