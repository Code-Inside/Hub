using Newtonsoft.Json;

namespace CodeInside.Hub.Domain
{
    public static class Constants
    {
        public static JsonSerializerSettings CrawlerJsonSerializerSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                };    
            }
        }
        
    }
}
