using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class help
    {
        public static (double, double[]) ЭнтропияПоШенонуДефолтыч(char[] alp, string source)
        {
            var result = 0d;
            var prob = new double [alp.Length];
            foreach(var symb in alp)
            {
                if (sources.skipped.Contains(symb))
                    continue;
                var index = Array.IndexOf(alp, symb);
                if (source.Contains(symb))
                {
                    prob[index] = source.Count(el => el == symb) / (double)source.Count(c=>!sources.skipped.Contains(c));
                    var logEtoiHuini = Math.Log2(prob[index]);
                    result += logEtoiHuini * prob[index];
                }
            }
            return (0 - result, prob);
        }

        public static double ЭнтропияБинарногоПоШенонуДефолтыч(char[] alp, string src)
        {
            var result = 0d;
            var prob = new double[alp.Length];
            foreach (var symb in alp)
            {;
                var index = Array.IndexOf(alp, symb);
                if (src.Contains(symb))
                {
                    prob[index] = src.Count(el => el == symb) / (double)src.Length;
                    var logEtoiHuini = Math.Log2(prob[index]);
                    result += logEtoiHuini * prob[index];
                }
            }
            return 0 - result;
        }
    }
}
