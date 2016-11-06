using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using _3.MVC_EF.Models;
using System.Data.Entity.Migrations;
using System.Web.Routing;

namespace _3.MVC_EF.Controllers
{
    public class UserInfoCRUDController : Controller
    {
        private DbContext context = new EntityTestEntities3();

        // GET: UserInfoCRUD
        public ActionResult Index()
        {
            var list = context.Set<UserInfoP>();

            return View(list);
        }

        // 加入
        public ActionResult Add()
        {
            return View();
        }

        // 加入操作
        [HttpPost]
        public ActionResult Add(UserInfoP userInfo)
        {
            context.Set<UserInfoP>().Add(userInfo);
            // 將記憶體中資料的的變化儲存到資料庫中
            int affectRow = context.SaveChanges();

            if (affectRow > 0)
            {
                return Redirect(Url.Action("Index", "UserInfoCRUD"));
            }

            return View();
        }

        // 更改
        public ActionResult Edit(int id)
        {
            ViewData.Model = context.Set<UserInfoP>().Where(u => u.Uid == id).FirstOrDefault();
            return View();
        }

        // 更改操作
        [HttpPost]
        public ActionResult Edit(UserInfoP userInfo)
        {
            context.Set<UserInfoP>().AddOrUpdate(userInfo);
            int affectRow = context.SaveChanges();

            if (affectRow > 0)
            {
               return Redirect(Url.Action("Index"));
            }

            string url = Url.Action("Edit", new RouteValueDictionary(new
            {
                id = userInfo.Uid
            }
            ));
            return Redirect(url);
        }


        // 移除
        public ActionResult Remove(int id)
        {
            var userInfo = context.Set<UserInfoP>().
                Where(u => u.Uid == id).
                FirstOrDefault();

            context.Set<UserInfoP>().Remove(userInfo);

            int affectRow = context.SaveChanges();

            if(affectRow > 0)
            {
                return Redirect(Url.Action("Index"));
            }

            return Content("刪除失敗");
        }
    }
}