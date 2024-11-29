using OneGen.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OneGen.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class OneGenController : AbpControllerBase
{
    protected OneGenController()
    {
        LocalizationResource = typeof(OneGenResource);
    }
}
