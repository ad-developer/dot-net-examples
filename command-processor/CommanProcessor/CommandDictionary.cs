namespace CommanProcessor;

public static class CommandDictionary
{
    public static Dictionary<string, Type> Items { get; }
    static CommandDictionary()
    {
        Items = [];
        
        var commanHandlerType = typeof(ICommandHandler);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => commanHandlerType.IsAssignableFrom(p));
        
        types.ToList().ForEach(type =>{
            var prop = type.GetProperty("Name");
            if(prop is not null){
                var val = prop.GetValue(type, null) as string;
                if(!string.IsNullOrEmpty(val))
                    Items.Add(val, type);
            }
        });
    }
}