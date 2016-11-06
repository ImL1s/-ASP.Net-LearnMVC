using _3.MVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3.MVC_EF.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Index()
        {
            //return SelectByLinQ();
            //return SelectByDBContext();
            return SelectBySubDBContext();
        }


        public ActionResult SelectByCondition()
        {
            //return SelectBySelect();
            return SelectByMultipleCondition();
        }

        public ActionResult SelectByColumn()
        {
            return SelectSingleColumn();
        }

        #region private operation metohd

        // 使用LinQ方式查詢
        private ActionResult SelectByLinQ()
        {
            EntityTestEntities3 context = new EntityTestEntities3();

            var list = from user in context.UserInfoP
                       select user;

            return View(list);
        }

        // 使用方法查詢
        private ActionResult SelectByDBContext()
        {
            DbContext context = new EntityTestEntities3();

            var list = context.Set<UserInfoP>();

            return View(list);
        }

        // 使用指定的DBContext子類查詢
        private ActionResult SelectBySubDBContext()
        {
            EntityTestEntities3 context = new EntityTestEntities3();

            var list = context.UserInfoP;

            return View(list);
        }

        // 指定查詢出的列名
        private ActionResult SelectBySelect()
        {
            DbContext context = new EntityTestEntities3();

            var list = context.Set<UserInfoP>().Select(userInfo => userInfo);

            return View(list);
        }

        // 單條件查詢
        private ActionResult SelectBySimpleCondition()
        {
            DbContext context = new EntityTestEntities3();

            // 方法查詢
            //var list = context.Set<UserInfoP>().Where(userinfo => userinfo.Uid > 2).Select(u => u);

            // linQ查詢語句
            var list = from userinfo in context.Set<UserInfoP>()
                       where userinfo.Uid > 2
                       select userinfo;

            return View(list);
        }

        // 多條件查詢
        private ActionResult SelectByMultipleCondition()
        {
            DbContext context = new EntityTestEntities3();

            // 方法查詢
            //var list = context.Set<UserInfoP>().Where(u => u.Uid >= 2).Where(u => u.UName.Length > 3).Select(u => u);

            // linQ查詢
            var list = from userinfo in context.Set<UserInfoP>()
                       where userinfo.Uid >= 2 && userinfo.UName.Length > 3
                       select userinfo;

            return View(list);
        }

        // 查詢指定的列
        private ActionResult SelectSingleColumn()
        {
            DbContext context = new EntityTestEntities3();

            var list = from userInfo in context.Set<UserInfoP>()
                       select new UserInfoPViewModel
                       {
                           UID = userInfo.Uid
                       };

            return View(list);
        }

        #endregion
    }
}