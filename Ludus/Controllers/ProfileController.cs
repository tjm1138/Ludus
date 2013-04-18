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
        private DataServices.UserProfileService ups = new DataServices.UserProfileService();
        private DataServices.ProfileService ps = new DataServices.ProfileService();

        // GET: /Profile/
        public ActionResult Index()
        {
            Profile user = ps.Find(WebSecurity.CurrentUserId);
            return View(user);
        }

        //Edit an existing profile page submission
        public ActionResult Edit(int id)
        {
            UserProfile profile = ups.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //Edit an existing profile
        [HttpPost]
        public ActionResult Edit(UserProfile profile)
        {
            if (ModelState.IsValid)
            {
                ups.Update(profile);
                return RedirectToAction("index");
            }
            return View(profile);
        }
    }
}
