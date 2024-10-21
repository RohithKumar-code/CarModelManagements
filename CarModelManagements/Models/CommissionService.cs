public class CommissionService : ICommissionService
{
    public double CalculateCommission(Salesman salesman)
    {
        double totalCommission = 0;

        foreach (var record in salesman.SalesRecords)
        {
            double baseCommission = GetBaseCommission(record.Brand, record.NumberOfCarsSold);
            double classCommission = GetClassCommission(record.CarClass, record.NumberOfCarsSold);

            totalCommission += baseCommission + classCommission;

            if (salesman.LastYearSales > 500000 && record.CarClass == "A-Class")
            {
                totalCommission += 0.02 * baseCommission;
            }
        }

        return totalCommission;
    }

    private double GetBaseCommission(string brand, int numberOfCarsSold)
    {
        // Mock logic for base commission
        if (brand == "Audi")
            return 800 * numberOfCarsSold;
        if (brand == "Jaguar")
            return 750 * numberOfCarsSold;
        return 0;
    }

    private double GetClassCommission(string carClass, int numberOfCarsSold)
    {
        // Mock logic for class commission
        if (carClass == "A-Class")
            return 0.08 * numberOfCarsSold;
        if (carClass == "B-Class")
            return 0.06 * numberOfCarsSold;
        return 0.04 * numberOfCarsSold;
    }
}
