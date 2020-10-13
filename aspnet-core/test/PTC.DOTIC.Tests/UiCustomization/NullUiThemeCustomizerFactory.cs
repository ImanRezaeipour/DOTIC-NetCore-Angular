using System.Threading.Tasks;
using PTC.DOTIC.UiCustomization;

namespace PTC.DOTIC.Tests.UiCustomization
{
    public class NullUiThemeCustomizerFactory : IUiThemeCustomizerFactory
    {
        public async Task<IUiCustomizer> GetCurrentUiCustomizer()
        {
            return new NullThemeUiCustomizer();
        }

        public IUiCustomizer GetUiCustomizer(string theme)
        {
            return new NullThemeUiCustomizer();
        }
    }
}
