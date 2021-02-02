using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCStudy
{
    public class RouteConfig
    {

        /// <summary>
        /// Route是按着添加顺序匹配的，匹配到第一个就直接返回。
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //自定义路由规则
            routes.Add("RouteDemo", new RouteDemo());

            #region MapRoute源码

            ///// <summary>映射指定的 URL 路由并设置默认的路由值、约束和命名空间。</summary>
            ///// <returns>对映射路由的引用。</returns>
            ///// <param name="routes">应用程序的路由的集合。</param>
            ///// <param name="name">要映射的路由的名称。</param>
            ///// <param name="url">路由的 URL 模式。</param>
            ///// <param name="defaults">一个包含默认路由值的对象。</param>
            ///// <param name="constraints">一组表达式，用于指定 <paramref name="url" /> 参数的值。</param>
            ///// <param name="namespaces">应用程序的一组命名空间。</param>
            ///// <exception cref="T:System.ArgumentNullException">
            ///// <paramref name="routes" /> 或 <paramref name="url" /> 参数为 null。</exception>
            //public static Route MapRoute(
            //    this RouteCollection routes,
            //    string name,
            //    string url,
            //    object defaults,
            //    object constraints,
            //    string[] namespaces)
            //{
            //    if (routes == null)
            //        throw new ArgumentNullException(nameof(routes));
            //    if (url == null)
            //        throw new ArgumentNullException(nameof(url));
            //    Route route = new Route(url, (IRouteHandler)new MvcRouteHandler())
            //    {
            //        Defaults = RouteCollectionExtensions.CreateRouteValueDictionaryUncached(defaults),
            //        Constraints = RouteCollectionExtensions.CreateRouteValueDictionaryUncached(constraints),
            //        DataTokens = new RouteValueDictionary()
            //    };
            //    ConstraintValidation.Validate(route);
            //    if (namespaces != null && namespaces.Length != 0)
            //        route.DataTokens["Namespaces"] = (object)namespaces;
            //    routes.Add(name, (RouteBase)route);
            //    return route;
            //}

            #endregion
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public class RouteDemo : RouteBase
    {

        #region GetRouteData源码
        ///// <summary>返回有关集合中与指定值匹配的路由的信息。</summary>
        ///// <param name="httpContext">一个对象，该对象封装有关 HTTP 请求的信息。</param>
        ///// <returns>一个对象，其中包含路由定义中的值。</returns>
        ///// <exception cref="T:System.ArgumentNullException">
        /////   <paramref name="context" /> 为 <see langword="null" />。
        ///// </exception>
        ///// <exception cref="T:System.ArgumentException">
        /////   <paramref name="context" /> 参数中对象的 <see cref="P:System.Web.HttpContextBase.Request" /> 属性为 <see langword="null" />。
        ///// </exception>
        //public RouteData GetRouteData(HttpContextBase httpContext)
        //{
        //    if (httpContext == null)
        //        throw new ArgumentNullException(nameof(httpContext));
        //    if (httpContext.Request == null)
        //        throw new ArgumentException(System.Web.SR.GetString("RouteTable_ContextMissingRequest"), nameof(httpContext));
        //    if (this.Count == 0)
        //        return (RouteData)null;
        //    bool flag1 = false;
        //    bool flag2 = false;
        //    if (!this.RouteExistingFiles)
        //    {
        //        flag1 = this.IsRouteToExistingFile(httpContext);
        //        flag2 = true;
        //        if (flag1)
        //            return (RouteData)null;
        //    }
        //    using (this.GetReadLock())
        //    {
        //        foreach (RouteBase routeBase in (Collection<RouteBase>)this)
        //        {
        //            RouteData routeData = routeBase.GetRouteData(httpContext);
        //            if (routeData != null)
        //            {
        //                if (!routeBase.RouteExistingFiles)
        //                {
        //                    if (!flag2)
        //                        flag1 = this.IsRouteToExistingFile(httpContext);
        //                    if (flag1)
        //                        return (RouteData)null;
        //                }
        //                return routeData;
        //            }
        //        }
        //    }
        //    return (RouteData)null;
        //} 
        #endregion

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            if (httpContext.Request.UserAgent.Contains("Chrome"))
            {
                return null;
            }
            else
            {

                var routeData = new RouteData(this, new MvcRouteHandler());
                //var routeData = new RouteData(this, new CustomRouteHandler());
                routeData.Values["controller"] = "Home";
                routeData.Values["action"] = "Error";
                return routeData;
            }


        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }

    public class CustomRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new CustomHttpHandler();
        }
    }

    public class CustomHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("自定义HttpHandler程序响应");
            context.Response.ContentType = "text/html";
        }

        public bool IsReusable => true;
    }
}
