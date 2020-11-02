using System;
using System.Collections.Generic;
using System.Threading;

namespace Scrambler
{
    class Scrambler
    {
        List<int> Schema = new List<int>();
        List<int> Registr = new List<int>();
        public Scrambler(int[] Registr, int[] Schema)
        {
            for(int i = 0; i < Registr.Length; i++)
            {
                this.Registr.Add(Registr[i]);
            }
            for(int i = 0; i < Schema.Length; i++)
            {
                this.Schema.Add(Schema[i]);
            }
        }
        public int BitGenerate()
        {
            int result;
            List<int> CalculatedBits = new List<int>();
            for(int i = 0; i < Registr.Count; i++)
            {
                if(Schema[i] == 1)
                {
                    CalculatedBits.Add(Registr[i]);
                }
            }
            result = CalculatedBits[0];
            for(int i = 1; i < CalculatedBits.Count; i++)
            {
                result = XOR(result, CalculatedBits[i]);
            }
            for(int i = Registr.Count - 1; i > 0; i--)
            {
                Registr[i] = Registr[i - 1];
            }
            Registr[0] = result;
            return result;
        }
        public int XOR(int num_0, int num_1)
        {
            if (num_0 + num_1 == 1)
            {
                return 1;
            }
            return 0;
        }
        public void RegistrShow()
        {
            Console.Write("Registr : ");
            foreach (int bit in Registr)
            {
                Console.Write("{0} ", bit);
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void ShowCode(int[] code, string name="Code: ")
        {
            Console.Write(name);
            foreach (int bit in code)
            {
                Console.Write("{0} ", bit);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] Registr = {1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
            int[] Scheme =  {1, 0, 1, 0, 1, 0, 0, 1, 0, 0 };

            int[] MyCode = {
                1, 1, 0, 0, 1, 1, 1, 1,
                1, 1, 0, 0, 0, 0, 0, 0,
                1, 1, 0, 0, 1, 0, 1, 1,
            };

            Scrambler scrambler = new Scrambler(Registr, Scheme);
            Scrambler descrambler = new Scrambler(Registr, Scheme);

            ShowCode(MyCode);

            for(int i = 0; i < MyCode.Length; i++)
            {
                MyCode[i] = scrambler.XOR(MyCode[i], scrambler.BitGenerate());
            }

            ShowCode(MyCode);

            for (int i = 0; i < MyCode.Length; i++)
            {
                MyCode[i] = descrambler.XOR(MyCode[i], descrambler.BitGenerate());
            }
            ShowCode(MyCode);
        }
    }
}
