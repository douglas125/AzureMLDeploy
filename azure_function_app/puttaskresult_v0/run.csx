#r "Newtonsoft.Json"
#r "Microsoft.WindowsAzure.Storage"

using Microsoft.WindowsAzure.Storage.Blob;

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log, CloudBlockBlob outputBlob, CloudBlockBlob resultBlob)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];
    string task_id = req.Query["task_id"];
    string result = req.Query["result"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;
    task_id = task_id ?? data?.task_id;
    result = result ?? data?.result;
    
    if (task_id==null || result==null) return new BadRequestObjectResult("Please pass a task_id and result on the query string or in the request body");

    //fetch directory
    CloudBlobDirectory dd = resultBlob.Parent;
    CloudBlockBlob bb = dd.GetBlockBlobReference(task_id);

    byte[] result_bytes = System.Convert.FromBase64String(result);
    await bb.UploadFromByteArrayAsync(result_bytes, 0, result_bytes.Length);

    //fetch directory
    CloudBlobDirectory d = outputBlob.Parent;
    //fetch blob
    CloudBlockBlob b = d.GetBlockBlobReference(task_id);
    await b.DeleteIfExistsAsync();

    return (ActionResult)new OkObjectResult(task_id);
}
