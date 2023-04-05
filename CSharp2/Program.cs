using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2
{
    internal class Program
    {

        static string[,] SAA_Menu_Options
            =
        {
                //pt-BR
                { "Português",  "-- Menu --\n(8) Número Aleatório\n(9) Mudar Idioma\n(-1) Sair\n------", "Digite o número correspondente à língua desejada.", "Definir valor mínimo e máximo? y = sim/n = não", "Digite o valor máximo.", "Digite o valor mínimo.", "Número aleatório é: ", "Opção inválida." },
                //en-US
                { "English",    "-- Menu --\n(8) Random Number\n(9) Change Language\n(-1) Exit\n------", "Enter the number corresponding to the desired language.", "Set min and max value? y = yes/n = no", "Enter the maximum value.", "Enter the minimum value.", "Random number is: ", "Invalid option." },
                //
                { "日本語 (Used Google Translator)",    "-- メニュー --\n(8) 乱数\n(9) 言語の変更\n(-1) 終了\n------", "希望する言語に対応する番号を入力してください。", "最小値と最大値を設定しますか? y = はい/n = いいえ", "最大値を入力してください。", "最小値を入力してください。", "乱数: ", "無効なオプションです。" }
            };
        //Last index 7
        static int I_Language = 0;

        static Random R_Source = new Random();


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int I_Menu_Option = -1;

            do
            {
                I_Menu_Option = I_Create_Menu(I_Language);

                switch (I_Menu_Option)
                {
                    case 8:
                        V_Clear();
                        Console.WriteLine(SAA_Menu_Options[I_Language, 6] + I_Get_Random_Number(I_Language));
                        break;
                    case 9:
                        V_Clear();
                        I_Language = I_Set_Language(I_Language);
                            break;
                    default:
                        Console.WriteLine(SAA_Menu_Options[I_Language, 7]);
                        break;
                }
            } while (I_Menu_Option > -1);
        }

        private static void V_Clear() { Console.Clear(); }

        /**
         * 
         */
        private static int I_Create_Menu(int Language = 0)
        {
            int I_Option = -1;

            Console.WriteLine(SAA_Menu_Options[Language, 1]);

            I_Option = Convert.ToInt32(Console.ReadLine());

            return I_Option;
        }

        /**
         * 
         */
        private static int I_Set_Language(int Language = 0)
        {
            int I_Option = -1;

            Console.WriteLine(SAA_Menu_Options[Language, 2]);

            for (int i = 0; i < SAA_Menu_Options.GetLength(0); i++)
            {
                Console.WriteLine($"{i} - {SAA_Menu_Options[i, 0]}");
            }

            I_Option = Convert.ToInt32(Console.ReadLine());

            return I_Option;
        }

        /**
         * 
         */
        private static int I_Get_Random_Number(int Language = 0)
        {
            string I_Option = "";
            int Number = -1;

            Console.WriteLine(SAA_Menu_Options[Language, 3]);

            I_Option = Console.ReadLine();

            if (I_Option.ToLower().Trim() == "y")
            {
                int[] Range = { 0, 0 };
                Console.WriteLine(SAA_Menu_Options[Language, 4]);
                Range[0] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(SAA_Menu_Options[Language, 5]);
                Range[1] = Convert.ToInt32(Console.ReadLine());
                Number = I_Get_Integer_Number(Range);
            }
            else
            {
                Number = I_Get_Integer_Number();
            }

            return Number;
        }

        private static int I_Get_Integer_Number() { return R_Source.Next(); }

        private static int I_Get_Integer_Number(int[] Range) { return R_Source.Next(Range[0], Range[1]); }
    }
}
