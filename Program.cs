using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            do
            {
                try
                {
                    //użytkownik wpisuje dane w konsoli
                    Console.WriteLine("");
                    Console.WriteLine("Podaj nazwę miasta:");
                    string miasto = Console.ReadLine();
                    Console.WriteLine("Podaj imie, nazwisko i PESEL (oddzielone spacjami)");
                    string imie, nazwisko, pesel;
                    string[] input = Console.ReadLine().Split();
                    imie = input[0];
                    nazwisko = input[1];
                    pesel = input[2];

                    //jeżeli walidacja numeru pesel jest poprawna
                    if (PeselCheck.IsValid(pesel))
                    {
                        string fileName = pesel + ".txt";
                        string filePath = Path.Combine("dane", fileName);

                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                        string folderName = Path.Combine(desktopPath, "dane");
                        string folderPath = Path.Combine(desktopPath, filePath);                      

                        //jeżeli folder "dane" nie istnieje to go stwórz
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                            Console.WriteLine();
                            Console.WriteLine("Utworzono folder 'dane' na pulpicie!");
                        }
                        //jeżeli jest plik na pulpicie o nazwie *pesel* to wtedy go nadpisz
                        if (File.Exists(filePath))
                        {
                            Console.WriteLine("Plik z numerem PESEL: {0} już istnieje! Został on nadpisany nowymi danymi.", pesel);
                            File.WriteAllText(fileName, "");
                        }
                        //zapis do pliku
                        StreamWriter writer = new StreamWriter(new FileStream(folderPath, FileMode.OpenOrCreate, FileAccess.ReadWrite));
                        writer.WriteLine("{0}", miasto);
                        writer.WriteLine("{0} {1} {2}", imie, nazwisko, pesel);
                        writer.WriteLine("");
                        writer.Close();
                        loop = false; //pętla kończy się po wpisaniu poprwanie danych do pliku danych


                    }
                    else Console.WriteLine("Niepoprawny PESEL!");
                }
                catch (Exception e) 
                {
                    Console.WriteLine("Błąd wpisywania! Szczegóły: {0} ", e);
                }
            }
            while (loop); 
        }
    }
}
