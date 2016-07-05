using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    struct Rational
    {
        private int _numerator;
        private int _denominator;

        public Rational(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
            Reduce(ref this);
        }

        public Rational(int numerator) : this(numerator, 1) { }

        public int Numerator
        {
            get
            {
                return _numerator;
            }
            set
            {
                _numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return _denominator;
            }
            set
            {
                if (value != 0)
                {
                    _denominator = value;
                }
                else
                {
                    _denominator = 1;
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

        public static Rational Add(Rational first, Rational second)
        {
            return new Rational(first.Numerator * second.Denominator + second.Numerator * first.Denominator, first.Denominator * second.Denominator);
        }

        public static Rational Mul(Rational first, Rational second)
        {
            return new Rational(first.Numerator * second.Numerator, first.Denominator * second.Denominator);
        }

        public void Reduce(ref Rational rational)
        {
            int a = rational.Numerator;
            int b = rational.Denominator;
            int gcd, temp;

            while (a > 0)
            {
                b %= a;
                temp = a;
                a = b;
                b = temp;
            }

            gcd = b;
            rational.Numerator = rational.Numerator / gcd;
            rational.Denominator = rational.Denominator / gcd;
        }

        public override string ToString()
        {
            if(Numerator != 0)
            {
                if(Numerator == 1 && Denominator == 1)
                {
                    return "1";
                }
                else
                {
                    return Numerator + "/" + Denominator;
                }
            }
            else 
            {
                return "0";
            }
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Rational operator + (Rational left, Rational right)
        {
            return new Rational((left.Numerator * right.Denominator) + (left.Denominator * right.Numerator), left.Denominator * right.Denominator);
        }

        public static Rational operator - (Rational left, Rational right)
        {
            return new Rational((left.Numerator * right.Denominator) - (left.Denominator * right.Numerator), left.Denominator * right.Denominator);
        }

        public static Rational operator *(Rational left, Rational right)
        {
            return new Rational(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        }

        public static Rational operator /(Rational left, Rational right)
        {
            return new Rational(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }

        public static implicit operator double(Rational rational)
        {
            return rational.Value;
        }

        public static explicit operator Rational(int number)
        {
            return new Rational(number, 1);
        }
    }
}
