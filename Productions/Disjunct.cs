using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Productions
{
    class Disjunct
    {
        public List<Conjunct> Conjuncts=new List<Conjunct>();
        public Double Value;
        public Disjunct(List<Conjunct> Conj)//value вычисляется в calc
        {
            Conjuncts = Conj;
            Value = 0;
        }
        public void Calc(FIS f)
        {
            Value = 0;
            foreach (Conjunct C in Conjuncts)
            {
                C.Calc(f);
                Value = f.FuzzyOr(Value, C.Value);
            }
        }
    }
}
