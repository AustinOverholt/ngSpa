using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ngSpa.Services
{
    public class SmsService
    {
        static void Main(string[] args)
        {
            SendSms().Wait();
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }

        static async Task SendSms()
        {
            // Your Account SID from twilio.com/console
            string accountSid = WebConfigurationManager.AppSettings["TwilioAccountSid"];

            // Your Auth Token from twilio.com/console
            string authToken = WebConfigurationManager.AppSettings["TwilioAuthToken"];

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber("+7146238049"),
                from: new PhoneNumber("+15625218828"),
                body: "Hello from C#");
        }
    }
}
