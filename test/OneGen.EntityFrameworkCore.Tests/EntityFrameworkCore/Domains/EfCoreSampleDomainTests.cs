using OneGen.Samples;
using Xunit;

namespace OneGen.EntityFrameworkCore.Domains;

[Collection(OneGenTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<OneGenEntityFrameworkCoreTestModule>
{

}
