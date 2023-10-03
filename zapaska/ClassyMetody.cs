using System;

namespace ClassyMetody
{
    internal class CarAuto
    {
        private string number;
        private float fuel;
        private float flow;
        private float currentDistance = 0; //для текущего пройденного пути

        public void info(string number, float fuel, float flow)
        {
            this.number = number;
            this.fuel = fuel;
            this.flow = flow;
        }

        public void outinfo()
        {
            Console.WriteLine($"Номер: {this.number}\nТопливо: {this.fuel}\nРасход: {this.flow}");
        }

        private void zaprawka(float top)
        {
            this.fuel += top;
        }

        public void Probeg(float probeg)
        {
            this.currentDistance += probeg; // Увеличиваем текущий  путь
        }

        public void OutProbeg()
        {
            Console.WriteLine($"Текущий пробег: {this.currentDistance} км");
        }

        public void move(int km)
        {
            float TempFlow = this.flow;
            float distance = km;

            float ostatok = this.fuel - (distance * (this.flow) / 100);
            if (ostatok >= 0)
            {
                Console.WriteLine("Осталось в баке: " + ostatok + " л");
                Console.WriteLine("Ты доехал!");
                this.currentDistance += distance; // Увеличиваем текущий пройденный путь
            }
            else
            {
                Console.WriteLine("А ты хрен доедешь, давай зальём?");
                zaprawka(float.Parse(Console.ReadLine()));
                ostatok = this.fuel - (distance * (this.flow) / 100);

                if (ostatok >= 0)
                {
                    Console.WriteLine("Мы смогли доехать до рая и в баке осталось: " + ostatok);
                    this.currentDistance += distance; // Увеличиваем текущий путь
                }
                else
                {
                    float for_ostatok = (ostatok * -1);
                    Console.WriteLine($"Вам не хватило топлива до рая. Нужно было залить ещё {for_ostatok:F1} литра(ов)");
                }
            }
        }

        public float GetTotalDistance()
        {
            return this.currentDistance; //возврат общего пути
        }
    }
}
