using Volo.Abp.Modularity;

namespace CA.BackendTest;

[DependsOn(
    typeof(BackendTestApplicationModule),
    typeof(BackendTestDomainTestModule)
)]
public class BackendTestApplicationTestModule : AbpModule
{

}
