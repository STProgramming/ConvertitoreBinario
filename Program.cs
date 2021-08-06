using System;
using System.Linq;
using System.Collections.Generic;

namespace NumberToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Convertitore binario v1.0");
            string UserContinue = string.Empty;
            do
            {
                Console.WriteLine("Operazioni possibili: \n");
                Console.WriteLine("Seleziona il numero corrispondente all'operazione\n");
                Console.WriteLine("1)Convertire da numero a binario\n");
                Console.WriteLine("2)Convertire da binario a numero\n");
                var Answer = InputValidation(1, 2);
                switch (Answer)
                {
                    case 1:
                        Console.WriteLine("Inserire il numero che si vuole convertire");
                        var Number = InputValidation(1, Int32.MaxValue);
                        NumberToBinary(Number);
                        break;

                    case 2:
                        Console.WriteLine("Inserire la stringa binaria che si vuole convertire");
                        BinaryValor BinaryScene = new BinaryValor();
                        var Binary = ValidStringBinary(ref BinaryScene);
                        BinaryToNumber(Binary, ref BinaryScene);
                        break;

                }
                Console.WriteLine("\nOperazione conclusa!");
                Console.WriteLine("Per uscire scrivere \"esci\"");
                UserContinue = Console.ReadLine();
            }
            while (!UserContinue.Contains("esci") && !UserContinue.Contains("Esci"));
            Console.WriteLine("Grazie e arrivederci");
        }
        public static int InputValidation(int min, int max)
        {
            int Answer = 0;
            string UserAnswer = string.Empty;
            bool success = false;
            do
            {
                UserAnswer = Console.ReadLine();
                success = Int32.TryParse(UserAnswer, out Answer);
            }
            while (!success || Answer < min || Answer > max);
            return Answer;
        }

        public static List<int> ValidStringBinary(ref BinaryValor BinaryScene)
        {
            long Answer = 0;
            List<int> BinaryValue = new List<int> { };
            string UserAnswer = string.Empty;
            bool success;
            bool IsNotBinary ;
            bool IsMoreThan32Bit;
            do
            {
                do
                {
                    IsNotBinary = false;
                    IsMoreThan32Bit = false; 
                    BinaryValue.Clear();
                    UserAnswer = Console.ReadLine();
                    success = Int64.TryParse(UserAnswer, out Answer);
                }
                while (!success || String.IsNullOrEmpty(UserAnswer));
                while (Answer > 0)
                {
                    
                    BinaryValue.Add(Convert.ToInt32(Answer%10));
                    Answer = Answer / 10;
                }
                BinaryValue.Reverse();
                if(BinaryValue.Count() > BinaryScene.BinaryValor32Bit.Count())
                {
                    IsMoreThan32Bit = true;
                }
                else
                {
                    foreach (int Binary in BinaryValue)
                    {
                        if (Binary < 0 || Binary > 1)
                        {
                            IsNotBinary = true;
                        }
                    }
                }
            }
            while (IsNotBinary || IsMoreThan32Bit);
            return BinaryValue;
        }
        public static void NumberToBinary(int Number) 
        {
            List<int> BinaryValue = new List<int> { };
            int Result = Number;
            do
            {
                int Reminder = Result % 2;
                BinaryValue.Add(Reminder);
                Result = Result / 2;
            }
            while (Result > 0);
            BinaryValue.Reverse();
            foreach(int Binary in BinaryValue)
            {
                Console.Write(Binary);
            }
        }
        public static void BinaryToNumber(List<int> BinaryValue, ref BinaryValor BinaryScene)
        {
            BinaryValue.Reverse();
            int i = 0;
            uint Value = 0;
            foreach(int Binary in BinaryValue)
            {
                if(Binary == 1)
                {
                    Value = Value + BinaryScene.BinaryValor32Bit[i];
                }
                i++;
            }
            Console.WriteLine(Value);
        }

    }
}
