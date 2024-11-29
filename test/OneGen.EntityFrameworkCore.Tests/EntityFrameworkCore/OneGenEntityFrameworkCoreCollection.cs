using Xunit;

namespace OneGen.EntityFrameworkCore;

[CollectionDefinition(OneGenTestConsts.CollectionDefinitionName)]
public class OneGenEntityFrameworkCoreCollection : ICollectionFixture<OneGenEntityFrameworkCoreFixture>
{

}
