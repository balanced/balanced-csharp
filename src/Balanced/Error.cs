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
        public string Id;
        public string CategoryType;
        public string CategoryCode;
        public string Description;
        public Dictionary<String, object> Extras = new Dictionary<string, object>();

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
            Id = (string)data["request_id"];
            CategoryType = (string)data["category_type"];
            CategoryCode = (string)data["category_code"];
            Description = (string)data["description"];
            if (data.ContainsKey("extras"))
                Extras = new Dictionary<string, object>((IDictionary<string, object>)data["extras"]);
            else
                Extras = new Dictionary<string, object>();
        }
    }

    public class Declined : Error
    {
    }

    public class BankAccountVerificationFailure: Error
    {
    }
}
