class Bus : Avto
{
    private int passengers; // количество пассажиров
    private const float PassengerWeight = 80.0f; // средний вес пассажира в кг
    private int stopsCount; // количество остановок

    public Bus(string nom, float bak, float ras, int stops) : base(nom, bak, ras)
    {
        passengers = 0;
        stopsCount = stops;
    }

    public void BoardPassengers(int count)
    {
        passengers += count;
        UpdateFuelConsumption(); // Обновляем расход топлива при посадке пассажиров
        Console.WriteLine($"Автобус загружен. Текущее количество пассажиров: {passengers}");
    }

    public void DisembarkPassengers(int count)
    {
        passengers = Math.Max(0, passengers - count);
        UpdateFuelConsumption(); // Обновляем расход топлива при высадке пассажиров
        Console.WriteLine($"Пассажиры высажены. Текущее количество пассажиров: {passengers}");
    }
    public void BoardDisembarkPassengers(int count)
    {
        if (count > 0)
        {
            Console.WriteLine($"Посадка {count} пассажиров.");
            BoardPassengers(count);
        }
        else if (count < 0)
        {
            Console.WriteLine($"Высадка {-count} пассажиров.");
            DisembarkPassengers(-count);
        }
        else
        {
            Console.WriteLine("Некорректное количество пассажиров.");
        }
    }
    // Переопределение метода для расчета расхода топлива с учетом пассажиров
    protected override void UpdateFuelConsumption()
    {
        fuelConsumption = base.fuelConsumption + passengers * PassengerWeight / 1000;
    }
    public int StopsCount
    {
        get { return stopsCount; }
        set { stopsCount = value; }
    }
}
