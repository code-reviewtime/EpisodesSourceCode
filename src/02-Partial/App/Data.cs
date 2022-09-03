public static class Data 
{
    public static async Task<IEnumerable<Entity>> LoadEntitiesAsync()
    {
        var lines = await File.ReadAllLinesAsync("./Entities.csv");
        
        return lines
            .Select(x => x.Split(","))
            .Select(x => new Entity(int.Parse(x[0]), x[1]));
    }

    public static async Task<IEnumerable<DataItem>> LoadDataItemsAsync()
    {
        var lines = await File.ReadAllLinesAsync("./DataItems.csv");
        
        return lines
            .Select(x => x.Split(","))
            .Select(x => new DataItem(int.Parse(x[0]), x[1]));
    }
}