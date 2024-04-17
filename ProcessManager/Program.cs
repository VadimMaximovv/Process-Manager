using System;
using System.Diagnostics;

namespace ProcessManager
{
    internal class Program
    {
        // Этот метод выводит в консольное окно все имена и индефекаторы процесов, запущенных на компьютере
        public static void PrintAllProcess()
        {
            // Создание массива, в который записываются все процессы
            Process[] localAll = Process.GetProcesses();
            // Перечисление всех элементов массива
            for (int i = 0; i < localAll.Length; i++)
            {
                // Вывод Id и имени массива
                Console.WriteLine(localAll[i].Id + "\t" + localAll[i].ProcessName);
            }
            Console.WriteLine("");
        }

        // Метод завершения процесса по его Id
        public static void KillProcess(int id)
        {
            // Создание локальной переменной, которой будет присвоино значение процесса
            Process process;
            // Запуск обработки исключений
            try
            {
                // Запись процесса в переменную
                process = Process.GetProcessById(id);
            }
            // Если исключение найдено, то выполняется следующий блок
            catch (ArgumentException) 
            {
                // Вывод сообщения о том, что процесс по данному Id не был найден
                Console.WriteLine("The process with this id was not found");
                // Завершение выполнения метода
                return;
            }
            // Если исключение не было найдено, вывод в консоль сообщения, содержащую информацию об завершенном процессе
            Console.WriteLine("Process " + process.Id + " " + process.ProcessName + " forcibly terminated");
            // Завершение процесса
            process.Kill();
        }

        static void Main(string[] args)
        {

        }
    }
}
