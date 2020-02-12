using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.ServiceModel;
using Microsoft.Xrm.Sdk.Query;
//using Microsoft.Xrm.Tooling.Connector;

namespace Myplugin
{
    public class MyPlugin:IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Extract the tracing service for use in debugging sandboxed plug-ins.  
            // If you are not registering the plug-in in the sandbox, then you do  
            // not have to add any tracing service related code.  
            ITracingService tracingService =
                (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.  
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));

            // Obtain the organization service reference which you will need for  
            // web service calls.  
            IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);



            // The InputParameters collection contains all the data passed in the message request.  
            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parameters.  
                Entity entity = (Entity)context.InputParameters["Target"];

                try
                {
                    // Plug-in business logic goes here.  
                    string CustName = entity.Attributes["new_customer"].ToString();
                    if(entity.Attributes.Contains("new_basestyle"))
                    {
                        string BaseStyle = entity.Attributes["new_basestyle"].ToString();

                        string fetchquery = "<?xml version='1.0'?>" +

                                            "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>" +


                                                "<entity name='new_fabdev'>" +

                                                    "<attribute name='new_rollsize'/>" +

                                                    "<order descending='false' attribute='new_name'/>" +

                                                    "<filter type='and'>" +

                                                        "<condition attribute='statecode' value='0' operator='eq'/>" +

                                                        "<condition attribute='new_customername' value='" + CustName + "' operator='eq'/>" +

                                                        "<condition attribute='new_srno' value='" + BaseStyle + "' operator='eq'/>" +

                                                    "</filter>" +

                                                "</entity>" +

                                            "</fetch>";

                        EntityCollection result = service.RetrieveMultiple(new FetchExpression(fetchquery));
                        if(result.Entities.Count<=0)
                        {
                            throw new InvalidPluginExecutionException("NO SUCH RECORD PREDENT IN FABDEV ");
                        }
                        else
                        {
                            
                            int rollsize = Int32.Parse(result.Entities[0].ToString());
                            entity.Attributes.Add("new_tierprodprice", rollsize);
                        }
                    }
                    else
                    {
                        throw new InvalidPluginExecutionException("No base style is provided");
                    }

                }

                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in MyPlug-in.", ex);
                }

                catch (Exception ex)
                {
                    tracingService.Trace("MyPlugin: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }
}
