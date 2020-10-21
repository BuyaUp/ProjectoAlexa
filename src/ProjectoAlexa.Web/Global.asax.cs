using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;


namespace ProjectoAlexa.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Init();
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                var cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null && cookie.Value != string.Empty)
                {
                    FormsAuthenticationTicket ticket;
                    try
                    {
                        ticket = FormsAuthentication.Decrypt(cookie.Value);
                    }
                    catch
                    {
                        return;
                    }

                    var roles = ticket.UserData.Split(';');
                    //var id = Convert.ToInt32(roles[0]);
                    //var perfis = roles[1].Split(';');

                    if (Context.User != null)
                    {
                        Context.User = new GenericPrincipal(Context.User.Identity, roles);
                        //Context.User = new AplicacaoPrincipal(Context.User.Identity, perfis, id);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        var cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

                        FormsAuthenticationTicket ticket;
                        try
                        {
                            ticket = FormsAuthentication.Decrypt(cookie.Value);
                        }
                        catch
                        {
                            return;
                        }

                        var roles = ticket.UserData.Split(';');

                        if (Context.User != null)
                        {
                            Context.User = new GenericPrincipal(Context.User.Identity, roles);
                        }
                        e.User = new GenericPrincipal(new GenericIdentity(ticket.Name, "Forms"), ticket.UserData.Split(';'));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        var cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

                        FormsAuthenticationTicket ticket;
                        try
                        {
                            ticket = FormsAuthentication.Decrypt(cookie.Value);
                        }
                        catch
                        {
                            return;
                        }

                        var roles = ticket.UserData.Split(';');

                        if (Context.User != null)
                            Context.User = new GenericPrincipal(Context.User.Identity, roles);

                        HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(ticket.Name, "Forms"), ticket.UserData.Split(';'));
                    }
                    catch (Exception)
                    {

                    }
                }
            }

        }

    }
}
