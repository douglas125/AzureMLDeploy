#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

using System.Net;
using System.Net.Http.Headers;

public static async Task<HttpResponseMessage> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;

    string page = System.IO.File.ReadAllText(@"d:\home\site\wwwroot\showTestPage\testpage.html");
    MemoryStream ms = new MemoryStream(System.Text.Encoding.Default.GetBytes(page));

    HttpResponseMessage a = new HttpResponseMessage(HttpStatusCode.OK);
    a.Content = new StreamContent(ms);
    a.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

    return a;
}
