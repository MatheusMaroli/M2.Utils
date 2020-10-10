using System.Collections.Generic;
using M2.Utils.Web.Models;

namespace M2.Utils.Web.Responses
{
    public class QueryResponseModel<TModelResponse> where TModelResponse : class 
    {
        public string CurrentUrl {get;set;}
        public Pagination Pagination {get;set;}
        public IEnumerable<TModelResponse> Data {get;set;}
    }
}