using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CTP
{
    public abstract class TFractionalNum

    {
        private int numerator;
        private int denominator;


        /// Числитель
        public int Numerator
        {
            get => numerator;
            set => numerator = value;

        }

        /// Знаменатель
        public int Denominator
        {
            get => denominator;
            set => denominator = value;
        }

        public TFractionalNum()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public TFractionalNum(int a, int b)
        {
            if (b == 0)
            {
                throw new Exception("Деление на ноль невозможно!");
            }
            Numerator = a;
            Denominator = b;
            Norm(this);
        }

        public TFractionalNum(string str)
        {
            var index = str.IndexOf("/");
            if (index < 0)
            {
                throw new Exception("Строка пуста!");
            }

            var num = str.Substring(0, index);
            var den = str.Substring(index + 1);
            var numInt = Convert.ToInt32(num);
            var denInt = Convert.ToInt32(den);
            if (denInt == 0)
            {
                throw new Exception("Деление на ноль невозможно!");
            }
            Numerator = numInt;
            Denominator = denInt;
            Norm(this);
        }

        public TFractionalNum Copy() => (TFractionalNum)this.MemberwiseClone();


        /// Сумма
        public TFractionalNum Add(TFractionalNum b)
        {
            TFractionalNum res = b.Copy();
            if (this.Denominator == b.Denominator)
            {
                res.denominator = this.Denominator;
                res.numerator = this.Numerator + b.Numerator;
            }
            else
            {
                int nok = NOK(Convert.ToInt32(this.Denominator), Convert.ToInt32(b.Denominator));
                res.denominator = nok;
                res.numerator = this.Numerator * (nok / this.Denominator) + b.Numerator * (nok / b.Denominator);
            }
            return Norm(res);
        }

        /// Разность
        public TFractionalNum Difference(TFractionalNum B)
        {
            //if (A.Numerator == 0) return Multiplication(Norm(B), new TFrac(-1, 1));
            if (B.Numerator == 0) return Norm(this);
            TFractionalNum res = this.Copy();
            TFractionalNum a = Norm(this), b = Norm(B);
            if (a.Denominator == b.Denominator)
            {
                res.Denominator = a.Denominator;
                res.Numerator = a.Numerator - b.Numerator;
            }
            else
            {
                int nok = NOK(Convert.ToInt32(a.Denominator), Convert.ToInt32(b.Denominator));
                res.Denominator = nok;
                res.Numerator = a.Numerator * (nok / a.Denominator) - b.Numerator * (nok / b.Denominator);
            }
            return Norm(res);
        }

        /// Произведение
        public TFractionalNum Multiplication(TFractionalNum b)
        {
            TFractionalNum res = this.Copy();
            res.Denominator = this.Denominator * b.Denominator;
            res.Numerator = this.Numerator * b.Numerator;
            return res;
        }


        /// Деление
        public TFractionalNum Division(TFractionalNum b)
        {
            TFractionalNum res = this.Copy();
            res.Denominator = this.Denominator * b.Numerator;
            res.Numerator = this.Numerator * b.Denominator;
            return Norm(res);
        }


        /// Квадрат
        public TFractionalNum Square() => this.Multiplication(this);

        /// Обратное
        public TFractionalNum Reverse()
        {
            TFractionalNum res = this.Copy();
            res.Denominator = this.Numerator;
            res.Numerator = this.Denominator;
            return res;
        }

        /// Минус
        public TFractionalNum Minus()
        {
            TFractionalNum res = this.Copy();
            res.Denominator = this.Denominator;
            res.Numerator = 0 - this.Numerator;
            return res;
        }

        /// Равно
        public bool Equal(TFractionalNum b)
        {
            /*
            TFrac res = this.Difference(b);
            if (res.Numerator == 0)
            {
                return true;
            }

            return false;
            */
            if ((b.Numerator == this.Numerator) && (this.Denominator == b.Denominator))
            {
                return true;
            }
            else return false;
        }

        /// Больше
        public bool More(TFractionalNum d)
        {
            TFractionalNum otv = this.Difference(d);
            if ((otv.Numerator > 0 && otv.Denominator > 0)
                || (otv.Numerator < 0 && otv.Denominator < 0))
            {
                return true;
            }

            return false;
        }

        /// ВзятьЧислительЧисло
        public int GetNumeratorNumber() => numerator;

        /// ВзятьЗнаменательЧисло
        public int GetDenominatorNumber() => denominator;
        

        /// ВзятьЧислительСтрока
        public string GetNumeratorString() => numerator.ToString();


        /// ВзятьЗнаменательСтрока
        public string GetDenominatorString() => denominator.ToString();

        /// ВзятьДробьСтрока
        public string GetString() => numerator + "/" + denominator;

        private int NOK(int a, int b) => (a * b) / Gcd(a, b);
        
        private int Gcd(int a, int b) => a != 0 ? Gcd(b % a, a) : b;
        
        public int NOD(List<int> list)
        {
            if (list.Count == 0) return 0;
            int i;
            int gcd = list[0];
            for (i = 0; i < list.Count - 1; i++)
                gcd = NOD(gcd, list[i + 1]);
            return gcd;
        }
        static int NOD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        private TFractionalNum Norm(TFractionalNum SimpleFractions)
        {
            TFractionalNum fractions = SimpleFractions;
            if (fractions.Numerator == 0) { fractions.Denominator = 1; return fractions; }
            fractions = Reduction(fractions);
            if (NOD(new List<int> { fractions.Numerator, fractions.Denominator }) != 0)
            {
                int nod = NOD(new List<int> { fractions.Numerator, fractions.Denominator });
                fractions.Numerator /= nod;
                fractions.Denominator /= nod;
            }
            if (fractions.Denominator < 0)
            {
                fractions.Numerator *= -1;
                fractions.Denominator *= -1;
            }
            return fractions;
        }
        public TFractionalNum Reduction(TFractionalNum SimpleFractions)
        {
            TFractionalNum a = SimpleFractions;
            if ((SimpleFractions.Numerator >= 0 && SimpleFractions.Denominator < 0) || (SimpleFractions.Numerator < 0 && SimpleFractions.Denominator < 0))
            {
                SimpleFractions.Numerator *= -1;
                SimpleFractions.Denominator *= -1;
            }
            var nod = NOD(new List<int> { a.Numerator, a.Denominator });
            if (nod != 1)
            {
                a.Denominator /= nod;
                a.Numerator /= nod;
            }
            return a;
        }
    }
}
