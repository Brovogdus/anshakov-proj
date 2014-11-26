using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Productions
{
    class MFunction
    {
        public string MFType;// = "";
        public List<Parameter> Parameters= new List<Parameter>();
        public MFunction(String MType, List<Parameter> Params)
        {
            MFType = MType;
            Parameters = Params;
        }
        public double Calc (Double x){// в виде большого свича от типа
            Debug.Print("MF was executed. Variable.Value=" + x + "\n===");
            switch (this.MFType)
            {
                case "Trap":
                    {
                        double y = 0;
                        double a = this.Parameters[0].Value;
                        double b = this.Parameters[1].Value;
                        double c = this.Parameters[2].Value;
                        double d = this.Parameters[3].Value;
                        if ((x >= a) && (x < b)) 
                        { 
                            y = (x - a) / (b - a); 
                        }
                        else if ((x >= b) && (x < c))
                        { 
                            y = 1;
                        }
                        else if ((x >= c) && (x <= d)) 
                        {
                            y = (d - x) / (d - c); 
                        }
                        else
                        {
                            y = 0;
                        }
                        return y;
                        
                    }
                case "Es":
                    {
                        double y = 0;
                        double a = this.Parameters[0].Value;
                        double b = this.Parameters[1].Value;
                        if (x <= a)
                        {
                            y = 0;
                        }
                        else if ((x > a) && (x < b))
                        {
                            y = (x - a) / (b - a);
                        }
                        else
                        {
                            y = 1;
                        }
                        return y;
                    
                    }
                case "Zed":
                    {
                        double y = 0;
                        double a = this.Parameters[0].Value;
                        double b = this.Parameters[1].Value;
                        if (x <= a) 
                        {
                            y = 1;
                        }
                        else if ((x > a) && (x <= b)) 
                        {
                            y = (b - x) / (b - a);
                        }
                        else
                        {
                            y = 0;
                        }
                        return y;
                        
                    }
                    
            }
            return -1; 
        }
    
    
    
       /* double Trap(double x,double a, double b,double c,double d){
            double y; 
                if ((x>=a)&&(x<b)){y = (x - a) / (b - a);}
                else if ((x>=b)&&(x<c)){y = 1;}
                else if((x>=c)&&(x<=d)){y = (d - x) / (d - c);}
                else{
                    y = 0;
                }
            return y;
        }//Trap
               */
      /*  double Zed(double x,double a, double b){
           double y; 
            if(x<= a){y = 1;}
            else if((x>a)&&(x<=b)){y = (b - x) / (b - a);}
            else {
                y = 0;
            }
            return y;
        }//Zed
        */
       /* double Es(double x, double a, double b)
        {
            double y = 0;
            if (x <= a) { 
                y = 0;
            }
            else if ((x > a) && (x < b)) 
            { 
                y = (x - a) / (b - a);
            }
            else 
            { 
                y = 1; 
            }
            return y;
        }
        * */

}//MFunction


}
