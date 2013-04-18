using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SamStock.Web._Interfaces;

namespace SamStock.Web._Util
{
    public static class IListExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IList<T> list, bool addEmptyItem = false)
            where T : IHasAName, IHasAnId
        {
            var result = list.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString("0") }).ToList();

            if (addEmptyItem)
                result.Insert(0, new SelectListItem { Text = "", Value = "-1" });

            return result;
        }
    }
}