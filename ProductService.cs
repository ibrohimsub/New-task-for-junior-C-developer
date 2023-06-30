public class ProductService
{
    public decimal CalculateTotalPayment(string product, decimal amount, string phoneNumber, int installmentRange)
    {
        // Проверка входных параметров, например, на валидность номера телефона, положительность суммы и т.д.

        decimal totalPayment = amount;

        // Проверяем категорию продукта и применяем диапазон рассрочки с соответствующими процентами
        switch (product.ToLower())
        {
            case "смартфон":
                if (installmentRange < 3 || installmentRange > 9)
                    throw new ArgumentException("Недопустимый диапазон рассрочки для смартфона.");
                totalPayment = amount * (1 + installmentRange * 0.03m);
                break;
            case "компьютер":
                if (installmentRange < 3 || installmentRange > 12)
                    throw new ArgumentException("Недопустимый диапазон рассрочки для компьютера.");
                totalPayment = amount * (1 + installmentRange * 0.04m);
                break;
            case "телевизор":
                if (installmentRange < 3 || installmentRange > 18)
                    throw new ArgumentException("Недопустимый диапазон рассрочки для телевизора.");
                totalPayment = amount * (1 + installmentRange * 0.05m);
                break;
            default:
                throw new ArgumentException("Неизвестная категория продукта.");
        }

        // Отправляем СМС с деталями покупки на номер телефона клиента
        SendSMS(phoneNumber, $"Вы приобрели {product} на сумму {totalPayment} сомони в рассрочку на {installmentRange} месяцев.");

        return totalPayment;
    }

    private void SendSMS(string phoneNumber, string message)
    {
        // Код для отправки СМС на указанный номер телефона
        // Например, можно использовать сторонний сервис для отправки СМС через API
    }
}
