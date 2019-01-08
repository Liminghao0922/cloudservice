using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebRole1
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //this.PreSendRequestHeaders += Global_PreSendRequestHeaders;
            //EndRequest += Global_EndRequest;
        }
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            string instanceId = Environment.MachineName;
            if (Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.CurrentRoleInstance != null)
            {
                instanceId += "-" + Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.CurrentRoleInstance.Id;
            }
            HttpApplication app = sender as HttpApplication;
            app?.Context?.Response.Headers.Add("x-cloudservice-instance-v2", instanceId);
        }
        //private void Global_EndRequest(object sender, EventArgs e)
        //{
        //    string instanceId = Environment.MachineName;
        //    if (Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.CurrentRoleInstance != null)
        //    {
        //        instanceId += "-" + Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.CurrentRoleInstance.Id;
        //    }

        //    Response.Headers.Add("x-cloudservice-instance", instanceId);
        //}

        //private void Global_PreSendRequestHeaders(object sender, EventArgs e)
        //{
        //    string instanceId = Environment.MachineName;
        //    if (Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.CurrentRoleInstance != null)
        //    {
        //        instanceId += "-" + Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.CurrentRoleInstance.Id;
        //    }

        //    Response.Headers.Add("x-cloudservice-instance", instanceId);
        //}
    }
}