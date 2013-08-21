using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace Balanced
{
    public class NoResultsFound : Exception
    { 
    }

    public class MultipleResultsFound : Exception
    { 
    }

    public class Error : Exception
    {
        public string id;
        public string category_type;
        public string category_code;
        public string description;
        public Dictionary<String, object> extras = new Dictionary<string, object>();

        public static Error Create(IDictionary<string, object> data)
        {
            string key = (string)data["category_code"];

            Type type;
            switch (key)
            {
                case "funding-destination-declined":
                case "authorization-failed":
                    type = typeof(Declined);
                    break;

                case "bank-account-authentication-not-pending":
                case "bank-account-authentication-failed":
                case "bank-account-authentication-already-exists":
                    type = typeof(BankAccountVerificationFailure);
                    break;

                default:
                    type = typeof(Error);
                    break;
            }

            Error error = (Error)Activator.CreateInstance(type);
            error.Deserialize(data);
            return error;
        }

        public virtual void Deserialize(IDictionary<string, object> data)
        {
            id = (string)data["request_id"];
            category_type = (string)data["category_type"];
            category_code = (string)data["category_code"];
            description = (string)data["description"];
            if (data.ContainsKey("extras"))
                extras = new Dictionary<string, object>((IDictionary<string, object>)data["extras"]);
            else
                extras = new Dictionary<string, object>();
        }
    }

    public class Declined : Error
    {
    }

    public class BankAccountVerificationFailure: Error
    {
    }
}
