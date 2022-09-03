public sealed class Parser1 
{
    public async Task<Request?> ParseAsync(Formula formula) 
    {
        var entities = await Data.LoadEntitiesAsync();
        var entitiesDic = entities
            .ToDictionary(k => k.Name, v => v, StringComparer.InvariantCultureIgnoreCase);

        var dataItems = await Data.LoadDataItemsAsync();
        var dataItemsDic = dataItems
            .ToDictionary(k => k.Name, v => v, StringComparer.InvariantCultureIgnoreCase);

        if (!entitiesDic.TryGetValue(formula.EntityName, out var entity))
            return null;

        if (!dataItemsDic.TryGetValue(formula.DataItemName, out var dataItem))
            return null;

        return new(entity, dataItem);
    }

}

public sealed class Parser2
{
    private Dictionary<string, Entity> _entitiesDic = new();
    private Dictionary<string, DataItem> _dataItemsDic = new();

    public static async Task<Parser2> CreateAsync()
    {
        var entities = await Data.LoadEntitiesAsync();
        var dataItems = await Data.LoadDataItemsAsync();
        
        return new Parser2 
        {
            _entitiesDic = entities
                .ToDictionary(k => k.Name, v => v, StringComparer.InvariantCultureIgnoreCase),
            _dataItemsDic = dataItems
                .ToDictionary(k => k.Name, v => v, StringComparer.InvariantCultureIgnoreCase)
        };
    }

    public Request? Parse(Formula formula) 
    {
        if (!_entitiesDic.TryGetValue(formula.EntityName, out var entity))
            return null;

        if (!_dataItemsDic.TryGetValue(formula.DataItemName, out var dataItem))
            return null;

        return new(entity, dataItem);
    }

}

public sealed class Parser3
{
    public async Task<Func<Formula, Request?>> GetParserAsync() 
    {
        var entities = await Data.LoadEntitiesAsync();
        var entitiesDic = entities
            .ToDictionary(k => k.Name, v => v, StringComparer.InvariantCultureIgnoreCase);

        var dataItems = await Data.LoadDataItemsAsync();
        var dataItemsDic = dataItems
            .ToDictionary(k => k.Name, v => v, StringComparer.InvariantCultureIgnoreCase);

        return formula => 
        {
            if (!entitiesDic.TryGetValue(formula.EntityName, out var entity))
                return null;

            if (!dataItemsDic.TryGetValue(formula.DataItemName, out var dataItem))
                return null;

            return new(entity, dataItem);
        };
    }
}