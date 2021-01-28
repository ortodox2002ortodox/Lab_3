using System;
using System.Collections.Generic;
using System.Text;

namespace lr3
{
    class MyFrac
    {
        long nom;
        long denom;

        public long Num { get { return nom; } }
        public long Denom { get { return denom; } }

        public MyFrac(long nom_, long denom_)
        {
            long g1 = nom_;
            long g2 = denom_;

            nom = nom_;
            denom = denom_;

            while ((g1 != 0) && (g2 != 0))
            {
                if (g1 > g2)
                    g1 %= g2;
                else
                    g2 %= g1;
            }
            this.nom = this.nom / Math.Max(g1, g2);
            this.denom = this.denom / Math.Max(g1, g2);
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", this.nom, this.denom);
        }

        public static double DoubleValue(MyFrac f1)
        {
            double b = 0;
            b = (double)f1.nom / f1.denom;
            return b;
        }


        public static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom,
            f1.denom * f2.denom);
        }

        public static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom,
            f1.denom * f2.denom);
        }

        public static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom,
           f1.denom * f2.denom);
        }

        public static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom,
           f1.denom * f2.nom);
        }


        public static MyFrac GetRGR115LeftSum(int n)
        {
            MyFrac res = new MyFrac(1, 1);

            for (int i = 2; i <= n; i++)
            {
                res = Multiply(res, Minus(new MyFrac(1, 1), new MyFrac(1, i * i)));
            }
            return res;
        }

        public static MyFrac GetRGR113LeftSum(int n)
        {
            MyFrac objS = new MyFrac(1, 1 * 3);

            for (int i = 2; i <= n; i++)
            {
                MyFrac obj = new MyFrac(1, (2 * i - 1) * (2 * i + 1));
                objS = Plus(objS, obj);
            }
            return objS;
        }
    }
}
