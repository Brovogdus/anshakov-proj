using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;//to enable debug. delete in final version

namespace Productions
{
    class LTerm{
        public String Name;
        public Double Value;
        public MFunction MF;//=new MFunction();
        public LTerm(String nam, MFunction Mf)//значение терма вычисляется в фаззификации
        {
            this.Name=nam; 
             MF = Mf;
             Value = 0;
        }
       
        
    }
}
