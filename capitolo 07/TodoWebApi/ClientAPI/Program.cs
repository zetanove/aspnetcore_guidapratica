// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Http.Headers;

Console.WriteLine("Test Todo API, premi invio per proseguire");
Console.ReadLine();

using HttpClient client= new HttpClient();

client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
client.DefaultRequestHeaders.Add("User-Agent", "Console App");

var response = await client.GetAsync("https://localhost:7223/api/Todo");
Console.WriteLine("Status Code: "+response.StatusCode);
if (response.StatusCode == HttpStatusCode.OK)
{
    var json = await response.Content.ReadAsStringAsync();
    Console.Write(json);
}

