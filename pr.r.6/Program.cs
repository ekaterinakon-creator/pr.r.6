//***********************************************************************
//* Практическая работа № 6                                             *
//* Выполнила: Кондратюк Е.С., группа 2ИСП                              *
//* Задание: Составление программ разветвляющейся усложненной структуры *
//***********************************************************************
using System;
namespace _24342
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try // блок обработки исключений
            {
                Console.Title = "Практическая работа №6"; // Заголовок
                double a = 0, b = 0, c = 0, d = 0, e = 0, f = 0;
                double s1 = 0, s2 = 0, p1 = 0, p2 = 0;
                int choice = 0;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine("Здравствуйте!");
                Console.Write("Выберите, с какого треугольника хотите начать: 1 или 2\n");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) // выбор порядка ввода сторон треугольников
                {
                    case 1: // если пользователь сделал выбор 1
                        Console.WriteLine("вы выбрали начать с 1-го треугольника"); // вывод выбора пользователя
                        Console.Write("Введите 1-ю сторону 1-го треугольника: "); // вывод просьбы для ввода стороны треугольника
                        a = Convert.ToDouble(Console.ReadLine()); // ввод стороны a и преобразование в вещественный тип
                        Console.Write("Введите 2-ю сторону 1-го треугольника: ");
                        b = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите 3-ю сторону 1-го треугольника: ");
                        c = Convert.ToDouble(Console.ReadLine());
                        Console.Write("\nВведите 1-ю сторону 2-го треугольника: ");
                        d = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите 2-ю сторону 2-го треугольника: ");
                        e = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите 3-ю сторону 2-го треугольника: ");
                        f = Convert.ToDouble(Console.ReadLine()); break; // выход из switch
                    case 2: // если пользователь сделал выбор 2
                        Console.WriteLine("вы выбрали начать с 2-го треугольника");
                        Console.Write("Введите 1-ю сторону 2-го треугольника: ");
                        d = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите 2-ю сторону 2-го треугольника: ");
                        e = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите 3-ю сторону 2-го треугольника: ");
                        f = Convert.ToDouble(Console.ReadLine());
                        Console.Write("\nВведите 1-ю сторону 1-го треугольника: ");
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите 2-ю сторону 1-го треугольника: ");
                        b = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите 3-ю сторону 1-го треугольника: ");
                        c = Convert.ToDouble(Console.ReadLine()); break;
                    default:
                        throw new ArgumentException("Вы ввели неправильный номер!"); // исключительное условие для передачи информации об ошибке
                }

                string acheck = (a <= 0).ToString(), bcheck = (b <= 0).ToString(), ccheck = (c <= 0).ToString(), dcheck = (d <= 0).ToString(), echeck = (e <= 0).ToString(), fcheck = (f <= 0).ToString();   // результат проверки сторон треугольников в виде строки
                string zerocheck = acheck + bcheck + ccheck + dcheck + echeck + fcheck; // обьединение результатов в 1 строку
                string sumc = (a + b <= c).ToString(), sumb = (a + c <= b).ToString(), suma = (b + c <= a).ToString(), sumf = (d + e <= f).ToString(), sumd = (e + f <= d).ToString(), sume = (f + d <= e).ToString(); // Результат проверки суммы сторон треугольников
                string sumcheck = sumc + sumb + suma + sumf + sumd + sume;
                switch (zerocheck) // проверка: все стороны должны быть > 0
                {
                    case "FalseFalseFalseFalseFalseFalse": break; // все шесть проверок дали false при проверке условия (>0)
                    default:
                        throw new Exception("Сторона не может быть <= 0"); // исключительное условие для передачи информации об ошибке
                }
                switch (sumcheck) // проверка суммы сторон треугольников: <= большей
                {
                    case "FalseFalseFalseFalseFalseFalse": // если у пользователя все шесть проверок дали false (треугольники сущ)
                        p1 = (a + b + c) / 2; // Вычисление полупериметра 1-го треугольника
                        p2 = (d + e + f) / 2; // 2-го треугольника
                        s1 = Math.Sqrt(p1 * (p1 - a) * (p1 - b) * (p1 - c)); // вычисление площади по формуле Герона для 1-го треугольника
                        s2 = Math.Sqrt(p2 * (p2 - d) * (p2 - e) * (p2 - f)); // для 2-го треугольника
                        string omparisons1 = (s1 > s2).ToString(), omparisons2 = (s1 < s2).ToString(); // проверка: s1 < s2 и s1 > s2
                        string omparisons12 = omparisons1 + omparisons2;
                        switch (omparisons12) // проверка площадей
                        {
                            case "FalseFalse":  // если у пользователя все проверки дали false (=)
                                Console.WriteLine("Треугольники имеют равные площади");
                                break; // выход из switch
                            default:
                                Console.WriteLine("Треугольники имеют разные площади");
                                break;
                        }
                        break;
                    default:
                        throw new Exception("Такой треугольник не существует."); // исключительное условие для передачи инфомации об ошибке
                }
            }
            catch (OverflowException ofex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Возникла ошибка: " + ofex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            }
            catch (FormatException fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Возникла ошибка: " + fex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            }
            catch (Exception ex) // обработка исключений
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Возникла ошибка: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.ReadKey();
        }

    }
}