using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ludus.Filters;
using Ludus.Models;
using WebMatrix.WebData;

namespace Ludus.Controllers
{
    [InitializeSimpleMembership]
    public class ProfileController : Controller
    {
        private DataServices.UserProfileService ds = new DataServices.UserProfileService();

        // GET: /Profile/
        public ActionResult Index()
        {
            UserProfile user = ds.Find(WebSecurity.CurrentUserId);
            ViewBag.gravatar = ds.Gravatar(user.EmailAddress);
            return View(user);
        }
    }
}
