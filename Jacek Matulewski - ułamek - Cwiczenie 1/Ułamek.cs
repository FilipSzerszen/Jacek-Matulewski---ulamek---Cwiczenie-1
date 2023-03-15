using System;


namespace UlamekBiblioteka
{
    public struct Ułamek
    {
        private int  mianownik;

        public Ułamek(int licznik, int mianownik = 1)
            :this()
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
            return Licznik.ToString() + " / " + mianownik.ToString();
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

            if (Licznik * mianownik < 0)
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

    }
}
