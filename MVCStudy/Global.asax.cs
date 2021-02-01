using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVCStudy
{
    /// <summary>
    /// IIS监听请求-通过ISAPI解析动态还是静态文件--动态则转发网站到HttpRuntime.ProcessRequest()--HttpApplication处理
    /// ---通过观察者模式处理任意环节并添加事件对全部请求生效。
    ///
    ///
    /// UrlRoutingModule是MVC框架最核心的一个扩展--IHttpModule负责给event注册事件--注册的事件任何请求都需要处理一下--
    /// 给PostResolveRequestCache注册事件--这个事件去完成路由匹配，获取控制器action。
    ///
    /// 
    /// 
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
