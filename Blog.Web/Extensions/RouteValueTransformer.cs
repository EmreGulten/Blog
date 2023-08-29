using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Blog.Web.Extensions
{
    public class RouteValueTransformer : DynamicRouteValueTransformer
    {
        private readonly IActionDescriptorCollectionProvider _Provider;
        private readonly TranslationDatabase _translationDatabase;

        public RouteValueTransformer(IActionDescriptorCollectionProvider provider, TranslationDatabase translationDatabase)
        {
            _Provider = provider;
            _translationDatabase = translationDatabase;
        }

        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            //var model = _Provider.ActionDescriptors.Items;

            string url = null;
            string[] split;

            if (values["url"] == null) { return Home(values); }
            url = values["url"].ToString().ToLower();

            var customResultStatus = await _translationDatabase.Resolve(url);
            if (customResultStatus)
            {
                values["controller"] = "Home";
                values["action"] = "Blog";
                values["data"] = url;
                values.Remove("url");
                return values;
            }
            else
            {

                values.Remove("url");
                return values;
            }

        }

        protected RouteValueDictionary Home(RouteValueDictionary values)
        {
            values["controller"] = "Home";
            values["action"] = "Index";
            values.Remove("url");
            return values;
        }
        protected RouteValueDictionary Auth(RouteValueDictionary values)
        {
            values["controller"] = "Auth";
            values["action"] = "Login";
            values.Remove("url");
            return values;
        }
    }
}
