public class Salesman
{
    public string Name { get; set; }
    public double LastYearSales { get; set; }
    public List<SalesRecord> SalesRecords { get; set; }
}

public class SalesRecord
{
    public string Brand { get; set; }
    public string CarClass { get; set; }
    public int NumberOfCarsSold { get; set; }
}