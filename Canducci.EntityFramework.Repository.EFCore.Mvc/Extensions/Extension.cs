using Canducci.EntityFramework.Repository.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Canducci.EntityFramework.Repository.EFCore.Mvc.Extensions
{
    public static class Extension
    {
        public static SelectList ToSelectList<T>(this IRepository<T> repository) where T : class
        {
            return ToSelectList(repository.Query());
        }

        public static SelectList ToSelectList<T>(this IRepository<T> repository, object selectedValue) where T : class
        {
            return ToSelectList(repository.Query(), selectedValue);
        }

        public static SelectList ToSelectList<T>(this IRepository<T> repository, string dataValueField, string dataTextField) where T : class
        {
            return ToSelectList(repository.Query(), dataValueField, dataTextField);
        }

        public static SelectList ToSelectList<T>(this IRepository<T> repository, string dataValueField, string dataTextField, object selectedValue) where T: class
        {
            return ToSelectList(repository.Query(), dataValueField, dataTextField, selectedValue);
        }

        public static SelectList ToSelectList<T>(this IRepository<T> repository, string dataValueField, string dataTextField, object selectedValue, string dataGroupField) where T : class
        {
            return ToSelectList(repository.Query(), dataValueField, dataTextField, selectedValue, dataGroupField);
        }

        ////

        public static SelectList ToSelectList<T>(this IQueryable<T> query) where T : class
        {
            return new SelectList(query.ToList());
        }

        public static SelectList ToSelectList<T>(this IQueryable<T> query, object selectedValue) where T : class
        {
            return new SelectList(query.ToList(), selectedValue);
        }

        public static SelectList ToSelectList<T>(this IQueryable<T> query, string dataValueField, string dataTextField) where T : class
        {
            return new SelectList(query.ToList(), dataValueField, dataTextField);
        }

        public static SelectList ToSelectList<T>(this IQueryable<T> query, string dataValueField, string dataTextField, object selectedValue) where T : class
        {
            return new SelectList(query.ToList(), dataValueField, dataTextField, selectedValue);
        }

        public static SelectList ToSelectList<T>(this IQueryable<T> query, string dataValueField, string dataTextField, object selectedValue, string dataGroupField) where T : class
        {
            return new SelectList(query.ToList(), dataValueField, dataTextField, selectedValue, dataGroupField);
        }

    }
}
