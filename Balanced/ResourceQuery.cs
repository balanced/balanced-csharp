using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class ResourceQuery<T> : ResourcePagination<T>
    {
        public static class SortOrder
        {
            public const string ASCENDING = "asc";
            public const string DESCENDING = "desc";
        }

        string dateFormat = "{yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'}";

        public ResourceQuery(string href) : base(href) { }

        // Filtering

        public ResourceQuery<T> Filter(String field, String op, String value)
        {
            String name = String.Format("{0}[{1}]", field, op);
            uri_builder.SetQueryParam(name, value);
            return this;
        }

        public ResourceQuery<T> Filter(String field, String op, String[] values)
        {
            String name = String.Format("{0}[{1}]", field, op);
            String value = String.Join(",", values);
            uri_builder.SetQueryParam(name, value);
            return this;
        }

        public ResourceQuery<T> Filter(String field, String value)
        {
            uri_builder.SetQueryParam(field, value);
            return this;
        }

        public ResourceQuery<T> Filter(String field, String[] values)
        {
            String value = String.Join(",", values);
            uri_builder.SetQueryParam(field, value);
            return this;
        }

        public ResourceQuery<T> Filter(String field, String op, DateTime value)
        {
            return this.Filter(field, op, String.Format(dateFormat, value));
        }

        public ResourceQuery<T> Filter(String field, String op, DateTime[] values)
        {
            String[] transformed = new String[values.Length];
            for (int i = 0; i != values.Length; i++)
                transformed[i] = String.Format(dateFormat, values[i]);
            return this.Filter(field, op, transformed);
        }

        public ResourceQuery<T> Filter(String field, DateTime value)
        {
            return this.Filter(field, String.Format(dateFormat, value));
        }

        public ResourceQuery<T> Filter(String field, DateTime[] values)
        {
            String[] transformed = new String[values.Length];
            for (int i = 0; i != values.Length; i++)
                transformed[i] = String.Format(dateFormat, values[i]);
            return this.Filter(field, transformed);
        }

        public ResourceQuery<T> Filter(String field, String op, Object value)
        {
            return this.Filter(field, op, value.ToString());
        }

        public ResourceQuery<T> Filter(String field, String op, Object[] values)
        {
            String[] transformed = new String[values.Length];
            for (int i = 0; i != values.Length; i++)
                transformed[i] = values[i].ToString();
            return this.Filter(field, op, transformed);
        }

        public ResourceQuery<T> Filter(String field, Object value)
        {
            return this.Filter(field, value.ToString());
        }

        public ResourceQuery<T> Filter(String field, Object[] values)
        {
            String[] transformed = new String[values.Length];
            for (int i = 0; i != values.Length; i++)
                transformed[i] = values[i].ToString();
            return this.Filter(field, transformed);
        }

        // sorting

        public ResourceQuery<T> OrderBy(String field)
        {
            uri_builder.SetQueryParam("sort", field);
            return this;
        }

        public ResourceQuery<T> OrderBy(String field, String order)
        {
            String value = String.Format("{0},{1}", field, order);
            uri_builder.SetQueryParam("sort", value);
            return this;
        }
    }
}
