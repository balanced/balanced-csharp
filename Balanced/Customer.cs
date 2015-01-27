﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Customer : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/customers"; }
        }

        // field
        [ResourceField]
        public Dictionary<string, string> address { get; set; }
        [ResourceField]
        public string business_name { get; set; }
        [ResourceField]
        public int? dob_month { get; set; }
        [ResourceField]
        public int? dob_year { get; set; }
        [ResourceField]
        public string ein { get; set; }
        [ResourceField]
        public string email { get; set; }
        [ResourceField]
        public string name { get; set; }
        [ResourceField]
        public string phone { get; set; }
        [ResourceField]
        public string ssn_last4 { get; set; }

        // attributes
        [ResourceField(serialize = false)]
        public string merchant_status { get; set; }

        [ResourceField(field = "customers.bank_accounts", link = true, serialize = false)]
        public BankAccount.Collection bank_accounts { get; set; }

        [ResourceField(field = "customers.card_holds", link = true, serialize = false)]
        public CardHold.Collection card_holds { get; set; }

        [ResourceField(field = "customers.cards", link = true, serialize = false)]
        public Card.Collection cards { get; set; }

        [ResourceField(field = "customers.credits", link = true, serialize = false)]
        public Credit.Collection credits { get; set; }

        [ResourceField(field = "customers.debits", link = true, serialize = false)]
        public Debit.Collection debits { get; set; }

        [ResourceField(field = "customers.orders", link = true, serialize = false)]
        public Order.Collection orders { get; set; }

        [ResourceField(field = "customers.refunds", link = true, serialize = false)]
        public Refund.Collection refunds { get; set; }

        [ResourceField(field = "customers.reversals", link = true, serialize = false)]
        public Reversal.Collection reversals { get; set; }

        [ResourceField(field = "customers.accounts", link = true, serialize = false)]
        public Account.Collection accounts { get; set; }

        public Account PayableAccount()
        {
            Account payableAccount = this.accounts.Query().Filter("type", "contains", "payable").First();
            if (payableAccount == null)
                throw new SystemException("A payable account was not found");
            return payableAccount;
        }


        public Customer() { }

        public Customer(Dictionary<string, object> payload) { }

        public static Customer Fetch(string href)
        {
            return Resource.Fetch<Customer>(href);
        }

        public static Task<Customer> FetchAsync(string href)
        {
            return Resource.FetchAsync<Customer>(href);
        }

        public void Save()
        {
            this.Save<Customer>();
        }

        public Task SaveAsync()
        {
            return this.SaveAsync<Customer>();
        }

        public void Reload()
        {
            this.Reload<Customer>();
        }

        public Task ReloadAsync()
        {
            return this.ReloadAsync<Customer>();
        }

        public Order CreateOrder(Dictionary<string, Object> payload)
        {
            return CreateOrderAsync(payload).GetAwaiter().GetResult();
        }

        public Task<Order> CreateOrderAsync(Dictionary<string, Object> payload)
        {
            return orders.CreateAsync(payload);
        }

        public class Collection : ResourceCollection<Customer>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Customer> Query()
        {
            return new ResourceQuery<Customer>(resource_href);
        }
    }
}
