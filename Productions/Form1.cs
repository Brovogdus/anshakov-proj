using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Productions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Ok_but_Click(object sender, EventArgs e)
        {
       
            //init
            //input-output variables
            /*сначала по идее указывается их количество, и затем в цикле каждая будет инициализирована, сначала для инпута, 
            потом для аутпута*/
            Variable S = new Variable("Score", 50, 0, 80);
            Variable P = new Variable("Penal", 50, 0, 100);
            Variable Q = new Variable("Mark", 0, 1, 5);
            IDictionary<String, Variable> InVars = new Dictionary<String, Variable>();
            IDictionary<String, Variable> OutVars = new Dictionary<String, Variable>();
            InVars.Add(S.Name, S);/*тут не очень понятно,
                                   * зачем вообще нужен строковый ключ, раз в самой
                                   * переменной есть имя, которое по идее уникально для всего ФИЗа,
                                   поэтому я пока в качестве ключа сделаю имя переменной*/
            InVars.Add(P.Name, P);

            OutVars.Add(Q.Name, Q);

            // Lterms
            /*parameters для ling-term Mfunction - 
             * у нас есть  Ling term "Great" и его мфункция Es в диапазоне от 52 до 60
             * эта модель явно перегружена, как мне кажется, но аншаков любит классы, 
             * в которых всего два свойства и нет методов
             я не уверена относительно того, какое значение должен иметь терм.
             возможно, мы нормируем его в диапазон от 0 до 1, тогда у этого терма должно быть значение 1*/
             
            List<Parameter> L1Params = new List<Parameter>();
            Parameter L1a = new Parameter("a", 52);
            Parameter L1b = new Parameter("b", 60);
            L1Params.Add(L1a);
            L1Params.Add(L1b);
            LTerm L1 = new LTerm("SproutGreat", new MFunction("Es",L1Params));

            List<Parameter> L2Params = new List<Parameter>();
            Parameter L2a = new Parameter("a", 32);
            Parameter L2b = new Parameter("b", 40);
            Parameter L2c = new Parameter("c", 60);
            Parameter L2d = new Parameter("d", 72);
            L2Params.Add(L2a);
            L2Params.Add(L2b);
            LTerm L2 = new LTerm("SproutHigh", new MFunction("Trap", L2Params));
            //аналогично надо заполнить остальные лтермы для обеих входных переменных

            //literals
            Literal Lit1 = new Literal(S.Name,L2.Name,false);
            Literal Lit2 = new Literal(P.Name,L2.Name,false);
            List<Literal> LitsC1L = new List<Literal>();
            LitsC1L.Add(Lit1);
            LitsC1L.Add(Lit2);

            List<Literal> LitsC2L = new List<Literal>();
            LitsC2L.Add(Lit1);
            //conjuncts, disjuncts
            List<Conjunct> ConjL1 = new List<Conjunct>();
            Conjunct CL1 = new Conjunct(LitsC1L);
            Conjunct CL2 = new Conjunct(LitsC2L);
            ConjL1.Add(CL1);
            ConjL1.Add(CL2);
            Disjunct Dis1 = new Disjunct(ConjL1);
            
            double bF1 = 0.5, bF2 = 0.5;//степени доверия к продукциям, от 0 до 1
            //productions
            Production P1 = new Production(Dis1, Lit1, bF1);
            
            List<Production> Prods = new List<Production>();
            Prods.Add(P1);
            

            List<Parameter> Params = new List<Parameter>();

            FIS F = new FIS(InVars, OutVars, Prods, Params);
            //run
            F.Fuzzification();
            F.Agregation();
            F.Activation();
            F.Accumulation();
            F.CutAndUnion();
            F.Defuzzification();
            //terminate
           output.Text="output is "+F.Outputs.ToString();
        }
    }
}
