using OneGen.Localization;
using Volo.Abp.Application.Services;

namespace OneGen;

/* Inherit your application services from this class.
 */
public abstract class OneGenAppService : ApplicationService
{
    protected OneGenAppService()
    {
        LocalizationResource = typeof(OneGenResource);
    }
}
