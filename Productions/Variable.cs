using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Productions
{
    class Variable {
        public IDictionary<String,LTerm> LTerms = new Dictionary<String,LTerm>();
        //public IDictionary<String, MFValue> MFValues = new Dictionary<String, MFValue>();
        public List<MFValue> MFValues = new List<MFValue>();//массив возможных значений
        public string Name;
        public double Value;
        public Double LeftB;
        public Double RightB;
        public Variable(String N, Double Val, Double Left, Double Right)
        {
            Name = N;
            Value = Val;
            LeftB = Left;
            RightB = Right;
        }

    }
}
