using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using CA.BackendTest.DTO.Billings;
using CA.BackendTest.DTO.Customers;

namespace CA.BackendTest.BillingService
{
    public class BillingServiceTests
    {
        [Fact]
        public async Task GetBillingDataAsync_ReturnsCorrectData()
        {
            // Preparando o ambiente de teste
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var responseContent = new StringContent(JsonConvert.SerializeObject(new List<BillingDto>
    {
        new BillingDto
        {
            InvoiceNumber = "INV-001",
            Customer = new CustomerDto
            {
                Id = Guid.Parse("12081264-5645-407a-ae37-78d5da96fe59"),
                Name = "Cliente Exemplo 1",
                Email = "cliente1@example.com",
                Address = "Rua Exemplo 1, 123"
            },
            Date = new DateTime(2024, 2, 1),
            DueDate = new DateTime(2024, 2, 8),
            TotalAmount = 100,
            Currency = "BRL",
            Lines = new List<BillingLineDto>
            {
                new BillingLineDto
                {
                    ProductId = Guid.Parse("48c6dc20-a943-4f8f-83ca-1e1cf094a683"),
                    Description = "Produto 1",
                    Quantity = 2,
                    UnitPrice = 25,
                    Subtotal = 50
                },
                new BillingLineDto
                {
                    ProductId = Guid.Parse("48c6dc20-a943-4f8f-83ca-1e1cf094a612"),
                    Description = "Produto 2",
                    Quantity = 1,
                    UnitPrice = 50,
                    Subtotal = 50
                }
            }
        }
            }), Encoding.UTF8, "application/json");

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = responseContent
                });

            var clientFactoryMock = new Mock<IHttpClientFactory>();
            var httpClient = new HttpClient(mockHttpMessageHandler.Object);

            clientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var billingService = new Services.BillingService(clientFactoryMock.Object);

            // Ação
            var result = await billingService.GetBillingDataAsync();

            // Assertiva
            Assert.NotNull(result);
            var content = await result.Content.ReadAsStringAsync();
            var billingData = JsonConvert.DeserializeObject<List<BillingDto>>(content);
            Assert.Single(billingData);
            Assert.Equal("INV-001", billingData.First().InvoiceNumber);
            Assert.Equal(100, billingData.First().TotalAmount);
            Assert.Equal("Cliente Exemplo 1", billingData.First().Customer.Name);
        }
    }
}