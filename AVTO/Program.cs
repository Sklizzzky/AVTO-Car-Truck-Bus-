class Program
{
    static void Main()
    {
        Avto myCar = null;

        Console.WriteLine("Выберите тип машины:");
        Console.WriteLine("1. Автомобиль");
        Console.WriteLine("2. Грузовик");
        Console.WriteLine("3. Автобус");

        int carTypeChoice = int.Parse(Console.ReadLine());

        switch (carTypeChoice)
        {
            case 1:
                myCar = CreateCar();
                break;
            case 2:
                myCar = CreateTruck();
                break;
            case 3:
                myCar = CreateBus();
                break;
            default:
                Console.WriteLine("Некорректный выбор. Завершение программы.");
                return;
        }

        // Выводим информацию о машине
        myCar.Out();

        // Запускаем цикл управления машиной
        while (true)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Ехать");
                Console.WriteLine("2. Заправиться");
                Console.WriteLine("3. Разогнаться");
                Console.WriteLine("4. Тормозить");
                Console.WriteLine("5. Посадка/высадка пассажиров");
                Console.WriteLine("6. Погрузка/разгрузка груза");
                Console.WriteLine("7. Вывести информацию о машине");
                Console.WriteLine("8. Выйти");


                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите расстояние к следующей точке: ");
                        int distance = int.Parse(Console.ReadLine());
                        myCar.Move(distance);
                        break;
                    case 2:
                        Console.Write("Введите количество топлива для заправки: ");
                        float fuelToAdd = float.Parse(Console.ReadLine());
                        myCar.Zapravka(fuelToAdd);
                        break;
                    case 3:
                        Console.Write("Введите ускорение: ");
                        float acceleration = float.Parse(Console.ReadLine());
                        myCar.Razgon(acceleration);
                        break;
                    case 4:
                        Console.Write("Введите замедление: ");
                        float deceleration = float.Parse(Console.ReadLine());
                        myCar.Tormozhenie(deceleration);
                        break;
                    case 5:
                        Console.Write("Введите количество пассажиров для посадки (положительное число) или высадки (отрицательное число): ");
                        int passengersChange = int.Parse(Console.ReadLine());

                        // Проверка, что myCar является объектом класса Bus
                        if (myCar is Bus bus)
                        {
                            bus.BoardDisembarkPassengers(passengersChange);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный выбор транспорта для данной операции.");
                        }
                        break;
                    case 6:
                        Console.Write("Введите вес груза для погрузки (положительное число) или разгрузки (отрицательное число): ");
                        float cargoChange = float.Parse(Console.ReadLine());

                        // Проверка, что myCar является объектом класса Truck
                        if (myCar is Truck truck)
                        {
                            truck.LoadUnloadCargo(cargoChange);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный выбор транспорта для данной операции.");
                        }
                        break;
                    case 7:
                        myCar.Out();
                        break;

                    case 8:
                        // Выход из цикла
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                        break;

                }
            }
        }

        static Avto CreateCar()
        {
            Console.Write("Введите номер автомобиля: ");
            string number = Console.ReadLine();

            Console.Write("Введите объем бака: ");
            float fuelVolume = float.Parse(Console.ReadLine());

            Console.Write("Введите расход топлива на 100 км: ");
            float fuelConsumption = float.Parse(Console.ReadLine());

            return new Avto(number, fuelVolume, fuelConsumption);
        }

        static Truck CreateTruck()
        {
            Console.Write("Введите номер грузовика: ");
            string number = Console.ReadLine();

            Console.Write("Введите объем бака: ");
            float fuelVolume = float.Parse(Console.ReadLine());

            Console.Write("Введите расход топлива на 100 км: ");
            float fuelConsumption = float.Parse(Console.ReadLine());

            return new Truck(number, fuelVolume, fuelConsumption);
        }

        static Bus CreateBus()
        {
            Console.Write("Введите номер автобуса: ");
            string number = Console.ReadLine();

            Console.Write("Введите объем бака: ");
            float fuelVolume = float.Parse(Console.ReadLine());

            Console.Write("Введите расход топлива на 100 км: ");
            float fuelConsumption = float.Parse(Console.ReadLine());

            Console.Write("Введите количество остановок: ");
            int stopsCount = int.Parse(Console.ReadLine());

            return new Bus(number, fuelVolume, fuelConsumption, stopsCount);
        }
    }
}
