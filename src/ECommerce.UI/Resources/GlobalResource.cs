using Microsoft.Extensions.Localization;
using System.Reflection;

namespace ECommerce.UI.Resources
{
    public class GlobalResource
    {
        private readonly IStringLocalizer localizer;
        public GlobalResource(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(GlobalResource).GetTypeInfo().Assembly.FullName);
            localizer = factory.Create(nameof(GlobalResource), assemblyName.Name);
        }

        public string Get(string key)
        {
            return localizer[key];
        }
    }
}
