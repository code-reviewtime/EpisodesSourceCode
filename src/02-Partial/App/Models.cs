public sealed record Entity(int Id, string Name);
public sealed record DataItem(int Id, string Name);
public sealed record Formula(string EntityName, string DataItemName);
public sealed record Request(Entity Entity, DataItem DataItem);