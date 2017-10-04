using System;

namespace WebApi.ControllerSuffixRemover
{
    public class CustomHttpControllerTypeResolver : DefaultHttpControllerTypeResolver
    {
        public CustomHttpControllerTypeResolver()
            : base(IsHttpEndpoint)
        { }

        internal static bool IsHttpEndpoint(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");

            return type.IsClass 
                  && type.IsVisible 
                  && !type.IsAbstract
                  && typeof(ApiController).IsAssignableFrom(type) 
                  && typeof(IHttpController).IsAssignableFrom(type);
        }
    }
}