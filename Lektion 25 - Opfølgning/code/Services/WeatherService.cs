using System.Net.Http.Headers;
using System.Text.Json;
namespace Code.Services
{
    /* 
        This class implements from: https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient
        Usages DMI WebAPI found: https://www.dmi.dk/friedata/dokumentation/meteorological-observation-api
        Feel free to select another observation from their sides. 

        Also play around with: https://opendataapi.dmi.dk/v2/metObs/swagger-ui/index.html
    */ 

    class WeatherService
    {

        public WeatherService()
        {   
        }

        async public void Init()
        {

            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            await ProcessRepositoriesAsync(client);
            
        }


        static async Task ProcessRepositoriesAsync(HttpClient client)
        {
            var json = await client.GetStringAsync(
                 "https://opendataapi.dmi.dk/v2/metObs/collections/observation/items");

            using JsonDocument doc = JsonDocument.Parse(json);

            var root = doc.RootElement;

            var firstFeature = root
                .GetProperty("features")[0];

            Console.WriteLine(firstFeature);
        }
    }
    
}