using Microsoft.AspNetCore.Builder;
using CA.BackendTest;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<BackendTestWebTestModule>();

public partial class Program
{
}
