using OneGen.Samples;
using Xunit;

namespace OneGen.EntityFrameworkCore.Applications;

[Collection(OneGenTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<OneGenEntityFrameworkCoreTestModule>
{

}
