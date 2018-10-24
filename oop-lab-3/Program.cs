using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_3
{
    /*
     Создать класс Car: id, Марка, Модель, Год выпуска, Цвет, Цена, Регистрационный номер. 
     Свойства и конструкторы должны обеспечивать проверку корректности.  
     Добавить метод вывода возраста машины. Создать массив объектов.
     Вывести: a)  список автомобилей заданной марки; 
     b)  список автомобилей заданной модели, которые эксплуатируются больше n лет;*/
    class Car
    {
        private readonly int id;
        private string make;
        private string model;
        private short year;
        private string color;
        private decimal price;
        private short registNumber;
        static private int counter;
        private bool status;
        private const int constForCash = 259;


        /*свойства (get, set) – для всех поле класса (поля класса должны быть закрытыми);
         * Для одного из свойств ограните доступ по set */

        public int Id => id;

        public string Model { get => model; set => model = value; }
        public string Make { get => make; set => make = value; }
        public short Year { get => year; private set => year = value; }
        public string Color { get => color; set => color = value; }
        public short RegistNumber { get => registNumber; private set => registNumber = value; }
        public decimal Price { get => price; set => price = value; }
        public bool Status { get => status; set => status = value; }
        public static int Counter { get => counter; set => counter = value; }

        //Не менее трех конструкторов (с параметрами  и без, а также с параметрами по умолчанию );

        public Car(string make, string model, string color, decimal price)
        {
            this.Make = make;
            this.Model = model;
            Year = (short)DateTime.Now.Year;
            this.Color = color;
            this.Price = price;
            RegistNumber = 1111;
            id = GetHashCode();
            counter++;
        }

        //с пареметрами (всеми)
        public Car(string make, string model, short year, string color, decimal price, short registNumber)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Color = color;
            this.Price = price;
            this.RegistNumber = registNumber;
            id = GetHashCode();
            counter++;
        }

        //c параметрами по умолчанию
        public Car(string make = "non")
        {
            this.Make = make;
            Model = "non";
            Year = 2000;
            Color = "white";
            Price = 103232;
            RegistNumber = 1111;
            id = GetHashCode();
            counter++;
        }

        //статический конструктор (конструктор типа);
        static Car()
        {
            //не должен иметь параметров
            Console.WriteLine("Вызван статический конструктор, так как cоздан первый объект\n");
            counter = 0;
        }

        //определите закрытый конструктор; предложите варианты его вызова

        private Car() { }

        /*в одном из методов класса для работы с аргументами используйте ref - и out-параметры*/

        public void GetdisplayAgeOfMachine(ref int quality)
        {
            int age;
            string ageStr;
            DateTime date = DateTime.Now;//изменить в ref


            if (year == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нельза высчитать возраст машины\n");

                return;
            }

            age = (int)(date.Year - year);
            if (age <= 1)
            {
                if (age == 1)
                {
                    ageStr = "год";
                }
                else
                {
                    ageStr = "лет";
                }
            }
            else
            {
                if (age < 5)
                {
                    ageStr = "года";
                }
                else
                {
                    ageStr = "лет";
                }
            }

            if (age > quality)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"Возраст машины: {age} {ageStr}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            if (age <= quality)
            {
                status = true;
            }
            else
            {
                status = false;
            }

        }

        /*создайте в классе статическое поле, 
         * хранящее количество созданных объектов (инкрементируется в конструкторе) 
         * и статический метод вывода информации о классе. */

        static public void PrintInformation()
        {
            Console.WriteLine("Кол-во созданых элементов: {0}", counter);
        }

        public override int GetHashCode()
        {
            int hash;
            if (Price == 0)
            {
                Price = 10000;
            }
            hash = (int)(RegistNumber / constForCash + Year / 11 + Price / constForCash / constForCash);
            return hash;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            string str;
            str = "id=" + Id + " make=" + Make + " model=" + Model + " year=" + Year + "\n color=" + Color + " price=" + Price + " registNumber=" + RegistNumber;
            return str;
        }

        //-------класс partial 
        public partial class Part
        {
            int a;
        }
        public partial class Part
        {
            //public string name; 
            public string Name { get; set; }

            public Part(int a)
            {
                this.a = a = 10;
            }

            public void PartMethod()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n\nИспользование класса partial: \n{a}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //-----------------
    }


    class Program
    {
        static void Main(string[] args)
        {
            int ageForQuality = 0;
            string make;
            string model;
            short year;
            string color;
            decimal price;
            short registNumber;
            int counter;
            //Console.WriteLine("Введите возраст машины для определения ее качества: ");
            //ageForQuality = int.Parse(Console.ReadLine());

            Car[] mas = new Car[100];

            mas[0] = new Car("Pejout", "223-123", "red", 100_000555);
            Console.WriteLine(mas[0].ToString());
            mas[0].GetdisplayAgeOfMachine(ref ageForQuality);

            mas[1] = new Car("Car", "231-23D", 2010, "grean", 1000_444, 4582);
            Console.WriteLine(mas[1].ToString());

            mas[1].GetdisplayAgeOfMachine(ref ageForQuality);

            mas[2] = new Car("Pejout");
            Console.WriteLine(mas[2].ToString());
            mas[2].GetdisplayAgeOfMachine(ref ageForQuality);
            //Car car = new Car();//не доступен из-за уровня защиты
            Car.PrintInformation();

            var anonimanonymousType = new
            {
                Make = "Pejout",
                Model = "223-123",
                Year = 2000,
                Color = "red",
                Price = 103232,
                RegistNumber = 1111
            };

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n" + anonimanonymousType.GetType());
            Console.WriteLine(anonimanonymousType.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ReadKey();

            while (true)
            {
                switch (menu())
                {
                    case '1':
                        {
                            if (Car.Counter <= 100)
                            {
                                Console.Write("make: ");
                                make = Console.ReadLine();
                                Console.Write("model: ");
                                model = Console.ReadLine();
                                Console.Write("year: ");
                                year = short.Parse(Console.ReadLine());
                                Console.Write("color: ");
                                color = Console.ReadLine();
                                Console.Write("prise: ");
                                price = decimal.Parse(Console.ReadLine());
                                Console.Write("registNumber: ");
                                registNumber = short.Parse(Console.ReadLine());

                                mas[Car.Counter - 1] = new Car(make, model, year, color, price, registNumber);
                            }
                            else
                            {
                                Console.WriteLine("Нельзя добавить элемент, т.к. массив переполнен");
                            }
                        }
                        break;
                    case '2':
                        {
                            PrintCarByMake(mas);
                        }
                        break;
                    case '3':
                        {
                            PrintCarByMakeAndAge(mas);
                        }
                        break;
                    case '4':
                        {
                            Car.PrintInformation();
                        }
                        break;
                    case '5':
                        {
                            counter = 1;
                            foreach (var i in mas)
                            {
                                if (counter <= Car.Counter)
                                {
                                    Console.WriteLine("Элемент номер: " + counter + '\n' + i.ToString() + '\n');
                                    i.GetdisplayAgeOfMachine(ref ageForQuality);
                                    counter++;
                                }
                            }
                        }
                        break;

                }
            }
        }

        static char menu()
        {
            Console.ReadKey();
            Console.Clear();
            char choice;
            string str;
            Console.WriteLine("1-Ввод нового элемента\n2-список автомобилей заданной марке\n 3- список автомобилей заданной модели, которые эксплуатируются больше n лет;\n 4-сведенья об массиве\n5-вывод всех элементов");
            do
            {
                str = Console.ReadLine();
                choice = str[0];
            } while (choice > '5' && choice < '1');
            return choice;
        }

        void MethodForOut(out int car)
        {
            car = 5;
        }
        //Вывести: a)  список автомобилей заданной марки
        static void PrintCarByMake(Car[] mas)
        {
            string strMake;
            int counter = 0;
            Console.WriteLine("Введите марку автомобилей: ");
            strMake = Console.ReadLine();
            for (int i = 0; i < Car.Counter; i++)
            {
                if (mas[i].Make == strMake)
                {
                    Console.WriteLine(mas[i].ToString() + '\n');
                    counter++;
                }

            }
            if (counter == 0)
            {
                Console.WriteLine("Таких автомобилей нет");
            }
        }
        //список автомобилей заданной модели, которые эксплуатируются больше n лет;
        static void PrintCarByMakeAndAge(Car[] mas)
        {
            int counter = 0;
            string strMake;
            int ageForQuality = 0;

            Console.WriteLine("Введите марку автомобилей: ");
            strMake = Console.ReadLine();

            Console.WriteLine("Введите max возраст автомобилей : ");
            ageForQuality = int.Parse(Console.ReadLine());


            for (int i = 0; i < Car.Counter; i++)
            {


                if (mas[i].Make == strMake)
                {
                    mas[i].GetdisplayAgeOfMachine(ref ageForQuality);

                    if (mas[i].Status)
                    {
                        Console.WriteLine(mas[i].ToString());
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Таких автомобилей нет");
            }
        }
    }
}
