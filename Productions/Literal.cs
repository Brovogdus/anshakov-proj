using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Productions
{
    class Literal
    {
        public String VarName;// ключ для коллекции inputs
        public String LTName;//ключ для листа строковый - обращение к Lterm 
        public bool Neg;
        public Double Value;
        public Literal(String VarN,String LTN, bool Ng)//value вычисляется в calc
        {
        VarName=VarN;
        LTName=LTN;
        Neg = Ng;
        Value = 0;
        }
        public void Calc(FIS f)
        {
            Value = f.Inputs[VarName].LTerms[LTName].Value;
            if (Neg)//If Me.Neg Then  Me.Value = 1 - Me.Value
            {
                Value = 1 - Value;
            }
        }
    }
}
