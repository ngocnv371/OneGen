using Microsoft.Extensions.Localization;
using OneGen.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace OneGen;

[Dependency(ReplaceServices = true)]
public class OneGenBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<OneGenResource> _localizer;

    public OneGenBrandingProvider(IStringLocalizer<OneGenResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
