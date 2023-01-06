using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt1
{
    public static class PeselCheck
    {
        public static bool IsValid(string pesel)
        {
            //sprawdzanie długości peselu
            if (pesel.Length != 11)
            {

                return false;

            }
            //sprawdzanie sumy kontrolnej 
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
            int checkSum = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                checkSum += weights[i] * int.Parse(pesel[i].ToString());
            }

            int lastDigit = checkSum % 10;
            if (lastDigit == 0)
            {
                Console.WriteLine("Pesel poprawny!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
