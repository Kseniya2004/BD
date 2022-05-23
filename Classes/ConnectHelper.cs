using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace BD.Classes
{
    class ConnectHelper
    {
        public static List<Man> dbase = new List<Man>();

        public static void ReadListFromFile(string filename)
        {
            dbase.Clear();
            try
            {
                StreamReader sr = new StreamReader(@"dbase.txt", Encoding.UTF8);                
                while (!sr.EndOfStream)
                {                   
                    string line = sr.ReadLine();
                    string[] items = line.Split(';');
                    Man many = new Man()
                    {
                        Name = items[0].Trim(),
                        Birth_year = int.Parse(items[1].Trim()),
                        Pay = double.Parse(items[2].Trim()),
                    };
                    dbase.Add(many);                   
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Проверить правильность имени файла!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Слишком большой файл!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            catch (FormatException)
            {
                MessageBox.Show("Недопустимая дата рождения или оклад!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка:{ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        public static void SaveListToFile(string filename)
        {
            StreamWriter streamWriter = new StreamWriter(@"dbase.txt", false, Encoding.UTF8);
            foreach (Man pr in dbase)
            {
                streamWriter.WriteLine($"{pr.Name};{pr.Birth_year};{pr.Pay}");
            }
            streamWriter.Close();
        }
    }
}
