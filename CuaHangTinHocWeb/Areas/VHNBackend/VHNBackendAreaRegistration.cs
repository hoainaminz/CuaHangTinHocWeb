using System.Web.Mvc;

namespace CuaHangTinHocWeb.Areas.VHNBackend
{
    public class VHNBackendAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "VHNBackend";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "VHNBackend_default",
                "VHNBackend/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}