using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.ServiceModel;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace SamplePlugin
{
    public class EmailDuplicateCheck:IPlugin
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

                    //string connectionString = "AuthType=Office365;Username=Aman@kantkashyap.onmicrosoft.com;Password=Sl140006;Url=https://kantkashyap.crm8.dynamics.com/";

                    string currentemail = string.Empty;

                    if(entity.Attributes.Contains("emailaddress1"))
                    {
                        currentemail = entity.Attributes["emailaddress1"].ToString();

                        string fetchquery = "<?xml version='1.0'?>"+

                                        "<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>"+

	                                        "<entity name='contact'>"+

		                                        "<attribute name='emailaddress1'/>"+

		                                        "<order descending='false' attribute='fullname'/>"+

		                                        "<filter type='and'>"+

			                                        "<condition attribute='statecode' value='0' operator='eq'/>"+

			                                        "<condition attribute='emailaddress1' value='"+currentemail+"' operator='eq'/>"+

		                                        "</filter>"+

	                                        "</entity>"+

                                        "</fetch>";


                        //CrmServiceClient crmservice = new CrmServiceClient(connectionString);

                        EntityCollection resultset = service.RetrieveMultiple(new FetchExpression(fetchquery));

                        if (resultset.Entities.Count>0)
                        {
                            throw new InvalidPluginExecutionException("Email exists already");
                        }

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
