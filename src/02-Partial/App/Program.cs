var formulas = new Formula[]
{
    new("Entity1", "Item2"),
    new("xyz", "Item2"),
    new("entity2", "item2")
};

await Version1(formulas);
await Version2(formulas);
await Version3(formulas);

static async Task Version1(IEnumerable<Formula> formulas)
{
    Console.WriteLine("Version1");
    var parser = new Parser1();

    foreach (var formula in formulas)
    {
        var request = await parser.ParseAsync(formula);
        Console.WriteLine(request);
    }
}

static async Task Version2(IEnumerable<Formula> formulas)
{
    Console.WriteLine("Version2");
    var parser = await Parser2.CreateAsync();

    foreach (var formula in formulas)
    {
        var request = parser.Parse(formula);
        Console.WriteLine(request);
    }
}

static async Task Version3(IEnumerable<Formula> formulas)
{
    Console.WriteLine("Version3");
    var parser = new Parser3();
    var parse = await parser.GetParserAsync();
   
    foreach (var formula in formulas)
    {
        var request = parse(formula);
        Console.WriteLine(request);
    }
}
