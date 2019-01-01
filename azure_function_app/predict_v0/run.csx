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
    string payload = req.Query["payload"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;
    payload = payload ?? data?.payload;

    if (payload == null) return new BadRequestObjectResult("Please send the payload!");

    byte[] payload_bytes = System.Convert.FromBase64String(payload);
    await outputBlob.UploadFromByteArrayAsync(payload_bytes, 0, payload_bytes.Length); //, null);

    name=outputBlob.Name;

    return (ActionResult)new OkObjectResult(outputBlob.Name);
}

public static byte[] Base64Decode(string base64EncodedData) {
  byte[] base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
  return base64EncodedBytes;
}

public static string Base64Encode(string plainText) {
  var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
  return System.Convert.ToBase64String(plainTextBytes);
}