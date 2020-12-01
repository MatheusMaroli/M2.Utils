using System.Collections.Generic;
using M2.Utils.Models;

namespace M2.Utils.Models
{
    public class QueryResponseModel
    {
        public string CurrentUrl {get;set;}
        public Pagination Pagination {get;private set;}
        public IEnumerable<object> Data {get;set;}

        public void SetPagination(Pagination page)
        {
            Pagination = new Pagination();
            if (! page.IsValid())
            {
                Pagination.CurrentPage = 1;
                Pagination.ItemsForPage = 20;
            }
            else
            {
                Pagination.CurrentPage = page.CurrentPage;
                Pagination.ItemsForPage = page.ItemsForPage;
            }
        }
        
    }
}