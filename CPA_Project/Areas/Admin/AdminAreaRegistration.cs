using System.Web.Mvc;

namespace CPA_Project.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "_Login", id = UrlParameter.Optional },
                namespaces: new[] { "CPA_Project.Areas.Admin.Controllers" }
            );
        }
    }
}