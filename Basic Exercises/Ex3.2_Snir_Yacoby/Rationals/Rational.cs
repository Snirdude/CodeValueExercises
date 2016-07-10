using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    struct Rational
    {
        private int m_Numerator;
        private int m_Denominator;

        public Rational(int i_Numerator, int i_Denominator)
        {
            m_Numerator = i_Numerator;
            m_Denominator = i_Denominator;
            Reduce(ref this);
        }

        public Rational(int i_Numerator) : this(i_Numerator, 1) { }

        public int Numerator
        {
            get
            {
                return m_Numerator;
            }
            set
            {
                m_Numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return m_Denominator;
            }
            set
            {
                if (value != 0)
                {
                    m_Denominator = value;
                }
                else
                {
                    m_Denominator = 1;
                }
            }
        }

        public double Value
        {
            get
            {
                return (double)Numerator / Denominator;
            }
        }

        public static Rational Add(Rational i_First, Rational i_Second)
        {
            return new Rational(i_First.Numerator * i_Second.Denominator + i_Second.Numerator * i_First.Denominator, i_First.Denominator * i_Second.Denominator);
        }

        public static Rational Mul(Rational i_First, Rational i_Second)
        {
            return new Rational(i_First.Numerator * i_Second.Numerator, i_First.Denominator * i_Second.Denominator);
        }

        public void Reduce(ref Rational i_Rational)
        {
            int a = i_Rational.Numerator;
            int b = i_Rational.Denominator;
            int gcd, temp;

            while (a > 0)
            {
                b %= a;
                temp = a;
                a = b;
                b = temp;
            }

            gcd = b;
            i_Rational.Numerator = i_Rational.Numerator / gcd;
            i_Rational.Denominator = i_Rational.Denominator / gcd;
        }

        public override string ToString()
        {
            return this.Numerator + "/" + this.Denominator;
        }

        public override bool Equals(object obj)
        {
            bool isEquals = false;

            if (obj is Rational)
            {
                isEquals = this.Numerator == ((Rational)obj).Numerator && this.Denominator == ((Rational)obj).Denominator;
            }

            return isEquals;
        }
    }
}
