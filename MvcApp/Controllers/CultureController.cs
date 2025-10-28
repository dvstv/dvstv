using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class CultureController : Controller
    {
        [HttpPost]
        public IActionResult Set(string culture, string returnUrl = "/")
        {
            var requestCulture = new RequestCulture(culture);

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(requestCulture),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            if (!Url.IsLocalUrl(returnUrl)) return Redirect("/");
            return Redirect(returnUrl);
        }
    }
}
