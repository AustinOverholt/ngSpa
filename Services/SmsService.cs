using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ngSpa.Services
{
    class SmsService
    {
        static void Main(string[] args)
        {
            // Set our Account SID and Auth Token
            const string accountSid = "AC233d60e273209cd21d362a3aee9d8988";
            const string authToken = "5ec7c936a3627db693526fcaf277ca87";

            // Initialize the Twilio client
            TwilioClient.Init(accountSid, authToken);

            // make an associative array of people we know, indexed by phone number
            var people = new Dictionary<string, string>() {
                {"+14158675309", "Curious George"},
                {"+14158675310", "Boots"},
                {"+14158675311", "Virgil"}
            };

            // Iterate over all our friends
            foreach (var person in people)
            {
                // Send a new outgoing SMS by POSTing to the Messages resource
                MessageResource.Create(
                    from: new PhoneNumber("555-555-5555"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber(person.Key), // To number, if using Sandbox see note above
                                                     // Message content
                    body: $"Hey {person.Value} Monkey Party at 6PM. Bring Bananas!");
            }
        }
    }
}
