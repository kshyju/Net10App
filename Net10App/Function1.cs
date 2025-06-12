using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Net10App;

public class Function1(ILogger<Function1> logger)
{
    private readonly ILogger<Function1> _logger = logger;

    [Function("Env")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var response = new
        {
            System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
            System.Runtime.InteropServices.RuntimeInformation.OSDescription,
            ProcessArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString(),
            HostVersion = Environment.GetEnvironmentVariable("HOST_VERSION"),
        };
        return new OkObjectResult(response);
    }
}