using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreInformationerNy
{
    class Program
    {
        private static string FLAG = "F";
        private static string ESC = "E";

        private static string stuff(string tekst)
        {
            string res = "";
            tekst = tekst.Replace(ESC, ESC + ESC);
            res = tekst.Replace(FLAG, ESC + FLAG) + FLAG;
            return res;
        }

        private static string unStuff(string stuffedText)
        {
            string res = "";
            res = stuffedText.Replace(ESC + ESC, ESC);

            res = res.Replace(ESC + FLAG, FLAG);
            return res;
        }

        private static string[] split(string tekst)
        {
            string[] res = new string[] { "", "", "", "" };
            string currChar = "";
            string lastChar = "";
            int stringIndex = 0;
            for (int i = 0; i < tekst.Length; i++)
            {
                currChar = tekst[i].ToString();
                if (currChar == FLAG && !lastChar.Equals(ESC))
                {
                    res[stringIndex] = unStuff(res[stringIndex]);
                    stringIndex++;
                }
                else
                    res[stringIndex] += currChar;

                //Console.WriteLine();
                lastChar = currChar;
            }

            //res = tekst.Replace(ESC + FLAG, FLAG);
            //tekst = tekst.Replace(ESC+ESC, ESC);
            return res;
        }


        static void Main(string[] args)
        {
            string kaldenavn, email, tal;
            string samlet = "";
            kaldenavn = "EFi EFInsen";
            // kaldenavn = Console.ReadLine();
            email = "Jeg vil FindeEnFinne@Finland.EF";
            tal = "123.345";
            Console.WriteLine("oprindelig text: " + kaldenavn + " " + email + " " + tal);
            samlet = stuff(kaldenavn);
            samlet += stuff(email);
            samlet += stuff(tal);
            Console.WriteLine("Stuffed tekst:" + samlet);
            string[] unstuffed = split(samlet);
            Console.Write("Unstuffed Tekst :");
            for (int i = 0; i < unstuffed.Length; i++)
            {
                Console.Write(unstuffed[i] + " ");

            }
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}