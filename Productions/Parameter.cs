using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Productions
{
    class Parameter
    {
        public string Name="ParamName";
        public double Value=0;
        public Parameter(String N, Double Val)
        {
            Name = N;
            Value = Val;
        }
        //public void set(string name, double value) { this.Name = name; this.Value = value; }
    }
}
