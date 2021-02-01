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
    /// IIS��������-ͨ��ISAPI������̬���Ǿ�̬�ļ�--��̬��ת����վ��HttpRuntime.ProcessRequest()--HttpApplication����
    /// ---ͨ���۲���ģʽ�������⻷�ڲ�����¼���ȫ��������Ч��
    ///
    ///
    /// UrlRoutingModule��MVC�������ĵ�һ����չ--IHttpModule�����eventע���¼�--ע����¼��κ�������Ҫ����һ��--
    /// ��PostResolveRequestCacheע���¼�--����¼�ȥ���·��ƥ�䣬��ȡ������action��
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
