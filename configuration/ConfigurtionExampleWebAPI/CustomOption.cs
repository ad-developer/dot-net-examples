namespace ConfigurtionExampleWebAPI;

public class CustomOption
{
    public required string Name { get; set; }
    public required string Value { get; set; }
    public  List<string> Items { get; set; } = [];
}
