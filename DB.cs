namespace ProductionReporting.DB;

public record ProductionRecord
{
    public int Id { get; set; }
    public string? Name { get; set; }
    // public Date Date { get; set; }
}

public class ProductionDB
{
    private static List<ProductionRecord> _records = new List<ProductionRecord>()
   {
     new ProductionRecord{ Id=1, Name="Montemagno, ProductionRecord shaped like a great mountain" },
     new ProductionRecord{ Id=2, Name="The Galloway, ProductionRecord shaped like a submarine, silent but deadly"},
     new ProductionRecord{ Id=3, Name="The Noring, ProductionRecord shaped like a Viking helmet, where's the mead"}
   };

    public static List<ProductionRecord> GetProductionRecords()
    {
        return _records;
    }

    public static ProductionRecord? GetProductionRecord(int id)
    {
        return _records.SingleOrDefault(ProductionRecord => ProductionRecord.Id == id);
    }

    public static ProductionRecord CreateProductionRecord(ProductionRecord ProductionRecord)
    {
        _records.Add(ProductionRecord);
        return ProductionRecord;
    }

    public static ProductionRecord UpdateProductionRecord(ProductionRecord update)
    {
        _records = _records.Select(ProductionRecord =>
        {
            if (ProductionRecord.Id == update.Id)
            {
                ProductionRecord.Name = update.Name;
            }
            return ProductionRecord;
        }).ToList();
        return update;
    }

    public static void RemoveProductionRecord(int id)
    {
        _records = _records.FindAll(ProductionRecord => ProductionRecord.Id != id).ToList();
    }
}