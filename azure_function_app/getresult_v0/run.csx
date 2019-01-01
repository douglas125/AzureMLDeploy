#r "Newtonsoft.Json"
#r "Microsoft.WindowsAzure.Storage"

using Microsoft.WindowsAzure.Storage.Blob;

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log, CloudBlockBlob outputBlob)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];
    string task_id = req.Query["task_id"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;
    task_id = task_id ?? data?.task_id;
    
    if (task_id==null) return new BadRequestObjectResult("Please pass a task_id on the query string or in the request body");

    //fetch directory
    CloudBlobDirectory d = outputBlob.Parent;
    //fetch blob
    CloudBlockBlob b = d.GetBlockBlobReference(task_id);

    bool exists = await b.ExistsAsync();
    if (!exists) return (ActionResult)new OkObjectResult("dGFza19pZCBub3QgZm91bmQh");

    await b.FetchAttributesAsync();

    //download contents
    byte[] payload_bytes = new byte[b.Properties.Length];
    await b.DownloadToByteArrayAsync(payload_bytes, 0);

    string payload = System.Convert.ToBase64String(payload_bytes);

    return (ActionResult)new OkObjectResult(payload);
}
