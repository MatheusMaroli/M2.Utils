using System;
using System.Collections.Generic;
using System.Linq;

namespace M2.Utils.Models
{
    public class Pagination
    {
        public int CurrentPage {get;set;}
        public int ItemsForPage {get;set;}
        public int TotalItems {get; private set;}
        public int TotalPage {get; private set;}
       
      
        private int IgnoreXItems(int pagina) {
            return ((pagina - 1) * ItemsForPage);
        }

        public bool IsValid() => ((CurrentPage > 0) && (ItemsForPage > 0));

        
        public IEnumerable<T> ExecutePagination<T>(IEnumerable<T> data) where T: class
        {
            TotalItems = data.Count();
            TotalPage = (int)Math.Ceiling((decimal)TotalItems / ItemsForPage);     
            return data.Skip(IgnoreXItems(CurrentPage)).Take(ItemsForPage).ToList();
        }
    }
}