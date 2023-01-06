using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO.Enumeration;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace projekt1
{

    internal class Program
    {
        static void Main(string[] args)
        {

            bool isValidInput = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Podaj nazwę miasta:");
                string miasto = Console.ReadLine();
                Console.WriteLine("Podaj imie, nazwisko i PESEL");
                string imie, nazwisko, pesel;
                string[] input = Console.ReadLine().Split();
                imie = input[0];
                nazwisko = input[1];
                pesel = input[2];

                //poprawność PESELU
                if (PeselCheck.IsValid(pesel))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Niepoprawny PESEL!");
                }


                string fileName = pesel + ".txt";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine("pesel", fileName);
                string folderPath = Path.Combine(desktopPath, filePath);

                //jeżeli jest plik na pulpicie o nazwie *pesel* to wtedy go nadpisz
                if (File.Exists(filePath))
                {
                    Console.WriteLine("Plik o numerze PESEL: {0} już istnieje! Został on nadpisany.", pesel);
                    File.WriteAllText(fileName, "");

                }

                //wpisywanie danych do pliku pesel.txt
                StreamWriter writer = new StreamWriter(new FileStream(folderPath, FileMode.OpenOrCreate, FileAccess.ReadWrite));
                writer.WriteLine("{0}", miasto);
                writer.WriteLine("{0} {1} {2}", imie, nazwisko, pesel);
                writer.WriteLine("");
                writer.Close();
            }
            while (!isValidInput);


        }

    }
}