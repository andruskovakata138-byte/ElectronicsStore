namespace ElectronicsStore.Services;

/// <summary>Расчет стоимости одной строки заказа без обращения к базе.</summary>
public static class PriceRules
{
    public static decimal Total(decimal price, int quantity, decimal discount)
    {
        if (price <= 0)
            throw new ArgumentException("Цена должна быть положительной.");
        if (quantity <= 0)
            throw new ArgumentException("Количество должно быть целым и больше нуля.");
        if (decimal.Round(discount, 2) != discount)
            throw new ArgumentException("Скидка — не более двух знаков после запятой.");
        if (discount < 0 || discount > 30)
            throw new ArgumentException("Скидка допускается от 0 до 30%.");

        return decimal.Round(
            checked(price * quantity * (1 - discount / 100m)),
            2, MidpointRounding.AwayFromZero);
    }
}
