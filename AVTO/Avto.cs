using System;

class Avto
{
    private string number;
    private float fuelVolume;
    protected float fuelConsumption;
    private float mileage;
    private float speed;
    private float totalDistance;
    private int finalDistance = new Random().Next(300, 1001);// Генерация случайного конечного расстояния
    public float TotalDistance => totalDistance;

    public Avto(string nom, float bak, float ras)
    {
        number = nom;
        fuelVolume = bak;
        fuelConsumption = ras;
        mileage = 0;
        speed = 0;
    }

    // Метод заполнения информации о машине
    public void Info(string nom, float bak, float ras)
    {
        number = nom;
        fuelVolume = bak;
        fuelConsumption = ras;
        mileage = 0;
        speed = 0;
    }

    // Метод вывода информации
    public void Out()
    {
        Console.WriteLine($"Номер автомобиля: {number}");
        Console.WriteLine($"Количество бензина в баке: {fuelVolume} л");
        Console.WriteLine($"Расход топлива на 100 км: {fuelConsumption} л");
        Console.WriteLine($"Пробег: {mileage} км");
        Console.WriteLine($"Текущая скорость: {speed} км/ч");
        Console.WriteLine($"Осталось проехать: {finalDistance - mileage} км");
    }

    // Метод заправки топливом
    public void Zapravka(float top)
    {
        fuelVolume += top;
        Console.WriteLine($"Машина заправлена. Текущий объем топлива: {fuelVolume} л");
    }

    // Метод езды
    public void Move(int km)
    {
        if (mileage + km <= finalDistance)
        {
            mileage += km;
            totalDistance += km;
            fuelVolume -= fuelConsumption * km / 100;

            Console.WriteLine($"Проехали {km} км. Остаток топлива: {fuelVolume} л");

            if (mileage == finalDistance)
            {
                Console.WriteLine($"Достигнуто конечное расстояние: {finalDistance} км. Машина остановлена.");
            }
            else
            {
                Console.WriteLine($"Осталось проехать: {finalDistance - mileage} км");
            }
        }
        else
        {
            Console.WriteLine("Достигнуто конечное расстояние. Машина остановлена.");
        }
    }

    // Метод расчета общего пробега
    public float CalculateTotalMileage()
    {
        return mileage;
    }

    // Свойство для получения остатка топлива (private)
    private int Ostatok()
    {
        return (int)fuelVolume;
    }
    public void Razgon(float acceleration)
    {
        speed += acceleration;
        UpdateFuelConsumption(); // Обновляем расход топлива при изменении скорости
        Console.WriteLine($"Машина разогналась. Текущая скорость: {speed} км/ч");
    }
    public void Tormozhenie(float deceleration)
    {
        speed = Math.Max(0, speed - deceleration);
        UpdateFuelConsumption(); // Обновляем расход топлива при изменении скорости
        Console.WriteLine($"Машина затормозила. Текущая скорость: {speed} км/ч");
    }

    protected virtual void UpdateFuelConsumption()
    {
        // Увеличиваем расход топлива в зависимости от скорости
        fuelConsumption += 0.1f * speed; // явное преобразование 0.1 в тип float
    }
}