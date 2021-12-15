using Esky.OpenApiClientTests.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Esky.OpenApiClientTests;

public class SimpleTests
{
    private readonly PetClient _petClient = new(new HttpClient()
    {
        BaseAddress = new Uri("https://petstore.swagger.io/v2/")
    });

    [Fact]
    public async Task Should_Return_Pets()
    {
        var pets = await _petClient.FindByStatusAsync(new[] { Anonymous.Available }, CancellationToken.None);

        Assert.NotEmpty(pets);
    }
}