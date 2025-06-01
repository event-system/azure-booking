using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace azure_bookings;

public class Bookings
{
    private readonly ILogger<Bookings> _logger;

    public Bookings(ILogger<Bookings> logger)
    {
        _logger = logger;
    }

    [Function("Bookings")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Bookings")] HttpRequestData req)
    {
        _logger.LogInformation("GET /Bookings called");

        var bookings = new[]
        {
            new {
                id = "INV10013",
                date = "2020/02/17 03:15 PM",
                name = "Natalie Johnson",
                @event = "Global Wellness Summit", // 'event' is a keyword in C#, prefix with @
                category = "Beauty & Wellness",
                tier = "CAT 1",
                price = "$80",
                qty = 3,
                amount = "$240",
                status = "Confirmed",
                voucher = "789101-WELLNESS"
            },
            new {
                id = "INV10014",
                date = "2020/03/22 11:00 AM",
                name = "John Doe",
                @event = "Tech Innovators Expo",
                category = "Technology",
                tier = "CAT 2",
                price = "$120",
                qty = 1,
                amount = "$120",
                status = "Pending",
                voucher = "123456-TECH"
            }
        };

        var response = req.CreateResponse();
        await response.WriteAsJsonAsync(bookings);

        return response;
    }
}
