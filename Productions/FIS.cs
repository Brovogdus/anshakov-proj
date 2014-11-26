using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;//to enable debug. delete in final version
//using System.Math;
namespace Productions
{
    class FIS
    {
        public   IDictionary<String,Variable> Inputs;// = new Dictionary<String,Variable>();
        public   IDictionary<String, Variable> Outputs;// = new Dictionary<String, Variable>();
        public   List<Production> Productions;// = new List<Production>();
        public   List <Parameter>Parameters;//=new List <Parameter>();

        public FIS(IDictionary<string, Variable> InVars, IDictionary<string, Variable> OutVars, List<Production> Prods, List<Parameter> Params)
        {
            this.Inputs = InVars; 
            this.Outputs = OutVars; 
            this.Productions = Prods; 
            this.Parameters = Params;
            //зададим коллекцию Мvalues
            double h = 0;
            foreach (Variable Y in this.Outputs.Values)
            {
                h = (Y.RightB - Y.LeftB) / 100;
                for (int i = 0; i < 100; i++)
                {
                    MFValue mf = new MFValue(Y.LeftB + i * h);
                    Y.MFValues.Add(mf);
                }
            }
            /*
             Public Sub CreateMFValues()
    Dim i As Integer, h As Double, _
    Y As Variable, mv As MFValue
    For Each Y In Me.Outputs
    h = (Y.RightB - Y.LeftB) / 100
        For i = 0 To 100
            Set mv = New MFValue
            mv.Arg = Y.LeftB + i * h
            Y.MFValues.Add mv
       Next   
    Next
End Sub
             */
        }
//Methods----------------------------------------------

   //return double--------------------------------------------
        /*
         Public Function fuzzyAnd(ByVal X As Double, _
Y As Double) As Double
Dim z As Double

Select Case Me.Parameters("FAndType")
Case "Min"
z = Min(X, Y)
Case "Prod"
z = X * Y
End Select
fuzzyAnd = z
End Function
*/
        
        public Double FuzzyAnd(Double Value,Double LValue)
        {
            return Math.Max(Value,LValue);
        }
        /*
    Public Function fuzzyOr(ByVal X As Double, _
    Y As Double) As Double
    Dim z As Double

    Select Case Me.Parameters("ForType")
    Case "Max"
    z = Max(X, Y)
    Case "Sum"
    z = X + Y - X * Y

    End Select
    fuzzyOr = z
    End Function
             */
        public Double FuzzyOr(Double Value, Double LValue)
        {
            return Math.Min(Value, LValue);
        }
    
        
   //void-----------------------------------------------
        public void Agregation()//Double Value, Double LValue)
        {
            foreach (Production P in this.Productions)
            {
                Debug.Print("aggregation is on.");
                P.Antecedent.Calc(this);
            }
            //return 0;
        }


        public void Activation()//(Double Value, Double LValue)
        {
            Debug.Print("activation is on.");
            foreach (Production P in this.Productions)
            { 
                P.Consequent.Value = this.FuzzyAnd(P.Antecedent.Value, P.BF);
            }
        }

        
        public void Accumulation()//(Double Value, Double LValue)
        {
            foreach (Variable Y in this.Outputs.Values)
                {
                foreach (LTerm L in Y.LTerms.Values)
                    {
                    L.Value = 0;
                      foreach(Production P in this.Productions)
                        {
                          if ((P.Consequent.LTName == L.Name) && (P.Consequent.VarName == Y.Name))
                            {
                              L.Value = this.FuzzyOr(L.Value, P.Consequent.Value);
                            }
                        }
                    }
                }// return 0;
        }


        public Double CutAndUnion()
        {
            foreach (Variable Y in this.Outputs.Values)
            {
                foreach (MFValue M in Y.MFValues) //предварительно для мф задать размер в конструкторе (выходных переменных)
                {
                    //.Values){
                   M.Value = 0;  // вообще это делается в конструкторе но на всякий случай оставлю
                    foreach (LTerm L in Y.LTerms.Values)
                        
                         {
                              M.Value = this.FuzzyOr(M.Value, this.FuzzyAnd(L.MF.Calc(M.Arg), L.Value)); 
                         }


                 }
            }
            return 0;
        }
 ////FUZZ==========================================================
        public void Fuzzification()
        {//(IDictionary Inputs){
           // MFValue MFV=new MFValue(0);
            
           
            foreach (KeyValuePair<string, Variable> X in this.Inputs)
            {
              foreach (LTerm L  in X.Value.LTerms.Values)
                {
                        Debug.Print("LTerm = " + L.Name);
                        L.Value=L.MF.Calc(X.Value.Value);
                //MFV=new MFValue(X.Value.Name,L.MFunction(X.Value).Value);
               // X.Value.MFValues.Add(MFV);
                
               }                
            }
            //return 0;
        }
////================================================================
        public void Defuzzification()// значение итоговой функции - мы пока будем считать только по центроидному методу
        {
            
            foreach (Variable Y in this.Outputs.Values)
            {
                Y.Value = DeFuzzMeth(Y.MFValues);
            }
        }
         public Double DeFuzzMeth(List<MFValue>MValues)//должна быть дискретная дефаззификация через суммы и дробь
        {
           
             //Centroid
            return Centroid(MValues);
        }
// --fuzzification methods----------------------------------------------
        

        double Max(double x)//, List<Parameter> Params)
        {
        double z;
        int i;
        z = x;
            for (i =0;i<this.Parameters.Count();i++) 
            {
                if (this.Parameters.ElementAt(i).Value > z)
                {
                    z = this.Parameters.ElementAt(i).Value;
                }
            }
            //Params.Min();i=Params.Max(); i++)
           return z;
         }//Max

        double Min(double x)//, List<Parameter> Params)
        {
            double z;
            int i;
            z = x;
            for (i = 0; i < this.Parameters.Count(); i++)
            {
                if (this.Parameters.ElementAt(i).Value < z)
                {
                    z = this.Parameters.ElementAt(i).Value; 
                }
            }
            return z;
         }//Min end

        /*  Centroid excel Dim N As Double, D As Double, M As MFValue
   N = 0
   D = 0
       For Each M In mfv
           N = N + M.Arg + M.Value
           D = D + M.Value
       Next
   Centroid = N / D*/
        public double Centroid(List<MFValue>MVals)
        {
        double Num=0, Den=0;
          
    foreach (MFValue M in MVals)
    {
        Num = Num + M.Arg + M.Value;
        Den = Den + M.Value;
       /* Num = Num + x(i) * i;
        Den = Den + x(i);
        */
         }
    return Num / Den;
            
        }



    }//FIS
}
