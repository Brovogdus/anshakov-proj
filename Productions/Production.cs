using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Productions
{
    class Production
    {
      public Disjunct Antecedent;
        public Literal Consequent;
        public Double BF;//число от 0 до 1 - степень доверия к продукции
        
        public Production(Disjunct A, Literal C, Double bF)
        {
            Antecedent = A;
            Consequent = C;
            BF = bF;
        }
    }
}
