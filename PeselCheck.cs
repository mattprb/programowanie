using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    public static class PeselCheck
    {
        //metoda zwraca true w przypadku pomyślnej walidacji oraz false w przypadku błednej
        public static bool IsValid(string pesel)
        {
            //sprawdzanie długości peselu
            if (pesel.Length != 11)
            {
                Console.Write("Długość numeru PESEL jest zła. ");
                return false;
            }
            //sprawdzanie sumy kontrolnej 
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
            int checkSum = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                checkSum = checkSum + weights[i] * int.Parse(pesel[i].ToString()); //do sumy kontrolnej dodajemy iloczyn wag i cyfr peselu
            }

            int lastDigit = checkSum % 10;
            if (lastDigit == 0)
            {
                Console.Write("PESEL poprawny! ");
                return true;
            }
            else
            {
                Console.Write("Suma kontrolna PESELU błędna. ");
                return false;
            }
        }
    }
}
