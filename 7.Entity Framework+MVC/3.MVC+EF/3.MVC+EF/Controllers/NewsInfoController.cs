using _3.MVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3.MVC_EF.Controllers
{
    public class NewsInfoController : Controller
    {
        // GET: NewsInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectByJoin()
        {
            return SelectByInnerJoin();
        }



        private ActionResult SelectByInnerJoin()
        {
            DbContext context = new EntityTestEntities3();

            DbSet<NewsInfo> newsInfoSet = context.Set<NewsInfo>();
            DbSet<NewsType> newsTypeSet = context.Set<NewsType>();

            // 1. 第一種查詢，將資料直接丟到cshtml中，藉由導航屬性選出相對應的資料
            var list = from newsInfo in newsInfoSet
                       select newsInfo;


            // 2. 第二種查詢，在cs代碼中將資料拿出來，構建一個新模型

            // 這種查詢方式會導致無法查詢，因為newsInfo.NewsType只有一個，並不可以枚舉
            //var list2 = from newsInfo in newsInfoSet
            //            from nType in newsInfo.NewsType
            //            select new
            //            {
            //                nid = newsInfo.nid,
            //                nTitle = newsInfo.nTitle,
            //                nType = nType
            //            };

            var list2 = from newsType in newsTypeSet
                         from newsInfo in newsType.NewsInfo
                         select new NewsInfoViewModel
                         {
                             nid = newsInfo.nid,
                             nTitle = newsInfo.nTitle,
                             newsType = newsType.tTitle
                         };

            // 3. 直接利用newsInfo的導航屬性
            var list3 = from newsInfo in newsInfoSet
                        select new NewsInfoViewModel
                        {
                            nid = newsInfo.nid,
                            nTitle = newsInfo.nTitle,
                            newsType = newsInfo.NewsType.tTitle
                        };
                         

            return View(list3);
        }
    }
}