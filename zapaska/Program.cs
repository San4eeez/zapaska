using ClassyMetody;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество топлива в баке: ");
        float topliv = float.Parse(Console.ReadLine());
        while (true)
        {


            Console.WriteLine("При начальной скорости 60 км/ч - расход 10 л/100 км.");
            Console.WriteLine("Разгонимся или притормозим? (для разгона положительное число, для торможения - отрицательное.)");
            float speedChange = float.Parse(Console.ReadLine());//разгон


            float speed = 60;//эталон
            float rashod = 10;

            if (speedChange > 0)
            {
                // Увеличиваем скорость
                while (speed < (60 + speedChange))
                {
                    speed += 1;
                    rashod += 0.1F;
                    Console.Clear();
                    Console.WriteLine($"Скорость: {speed}");
                    System.Threading.Thread.Sleep(180);
                }
            }
            else if (speedChange < 0)
            {
                // Уменьшаем скорость
                while (speed > (60 + speedChange))
                {
                    if (speed <= 1)
                    {
                        Console.WriteLine("Дружок - пирожок, ты что-то напутал в торможении. Нельзя ехать меньше 1. Считай что ты это и ввёл");
                        speed = 0.1F;
                        rashod = 4;
                        break;
                    }
                    else
                    {
                        speed -= 1;
                        rashod -= 0.1F;
                        Console.Clear();
                        Console.WriteLine($"Скорость: {speed}");
                        System.Threading.Thread.Sleep(10);
                    }
                }
            }

            CarAuto carAuto = new CarAuto();
            carAuto.info("п248он", topliv, rashod);
            carAuto.outinfo();

            Random random = new Random();
            int a = random.Next(1, 200);
            Console.WriteLine($"Наш путь до кабинета 1.11: {a} км (ДАЛЬШЕ БОГА НЕТ)");
            carAuto.move(km: a);
            Console.WriteLine("Приехали. Едем дальше? (да нет)");
            string edem = Console.ReadLine();
            carAuto.Probeg(a);
            carAuto.OutProbeg();
            if (edem == "нет")
            {
                Console.WriteLine($"Общий пробег: {carAuto.GetTotalDistance()} км");
                break;
            }
        }
    }
}
