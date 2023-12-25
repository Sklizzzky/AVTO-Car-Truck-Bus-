class Truck : Avto
{
    private float cargoWeight; // вес груза в кг
    private const float FuelConsumptionPerTon = 0.2f; // расход топлива за каждую тонну груза

    public Truck(string nom, float bak, float ras) : base(nom, bak, ras)
    {
        cargoWeight = 0;
    }

    public void LoadCargo(float weight)
    {
        cargoWeight += weight;
        UpdateFuelConsumption(); // Обновляем расход топлива при загрузке груза
        Console.WriteLine($"Грузовик загружен. Текущий вес груза: {cargoWeight} кг");
    }

    public void UnloadCargo(float weight)
    {
        cargoWeight = Math.Max(0, cargoWeight - weight);
        UpdateFuelConsumption(); // Обновляем расход топлива при разгрузке груза
        Console.WriteLine($"Грузовик разгружен. Текущий вес груза: {cargoWeight} кг");
    }

    // Переопределение метода для расчета расхода топлива с учетом груза
    protected override void UpdateFuelConsumption()
    {
        fuelConsumption = base.fuelConsumption + FuelConsumptionPerTon * cargoWeight / 1000;
    }
    public void LoadUnloadCargo(float weight)
    {
        if (weight > 0)
        {
            Console.WriteLine($"Погрузка груза в грузовик. Вес груза: {weight} кг.");
            LoadCargo(weight);
        }
        else if (weight < 0)
        {
            Console.WriteLine($"Разгрузка груза из грузовика. Вес груза: {-weight} кг.");
            UnloadCargo(-weight);
        }
        else
        {
            Console.WriteLine("Некорректный вес груза.");
        }
    }
}
