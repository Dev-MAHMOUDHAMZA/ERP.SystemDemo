using Microsoft.Extensions.Localization;
using System.Reflection;

namespace ERP.Web.Languages
{
    public class ResourceWeb { }
    public class ServicesLanguage
    {
        private readonly IStringLocalizer _localizer;

        public ServicesLanguage(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(ResourceWeb).GetTypeInfo().Assembly.FullName!);
            _localizer = factory.Create(nameof(ResourceWeb), assemblyName.Name!);
        }

        public LocalizedString this[string name]
        {
            get
            {
                return new LocalizedString(name, _localizer[name] ?? name, _localizer[name] == null);
            }
        }
    }
}
