using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ngSpa.Services
{
    class SmsService
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
            const string accountSid = "AC233d60e273209cd21d362a3aee9d8988";

            // Your Auth Token from twilio.com/console
            const string authToken = "5ec7c936a3627db693526fcaf277ca87";

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber("+7146238049"),
                from: new PhoneNumber("+15625218828"),
                body: "Hello from C#");
        }
    }
}
