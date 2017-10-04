using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace WebApi.ControllerSuffixRemover
{
    public static class WebConfigExtensions
    {
        public static void AllowControllersToNotNeedControllerSuffix(this HttpConfiguration config)
        {
            config.Services.Replace(typeof(IHttpControllerTypeResolver), new CustomHttpControllerTypeResolver());
            OverrideControllerConstant();
        }

        private static void OverrideControllerConstant()
        {
            var suffix =
                typeof(DefaultHttpControllerSelector).GetField("ControllerSuffix", BindingFlags.Static | BindingFlags.Public);
            if (suffix != null) suffix.SetValue(null, string.Empty);
        }
    }
}
