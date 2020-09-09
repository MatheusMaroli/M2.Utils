using M2.Utils.Web.Models;

namespace M2.Utils.Web.ResponseModels
{
    public class QueryResponseModel
    {
        public string RegisterRoute {get;set;}
        public string EditRoute {get;set;}
        public Pagination Pagination {get;set;}
        public object Data {get;set;}
    }
}