using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Productions
{
    class Conjunct
    {
        public List <Literal> Literals=new List<Literal>();
        public Double Value;
        public Conjunct(List<Literal> Lits)
        {
            Literals = Lits;
            Value = 0;
        }
        public void Calc(FIS f)
        {
            Value = 1;
            foreach(Literal L in Literals)
                {
                     L.Calc(f);
                     Value = f.FuzzyAnd(Value, L.Value);

                }
        }
    }
}
