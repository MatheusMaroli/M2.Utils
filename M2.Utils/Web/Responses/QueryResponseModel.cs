using System.Collections.Generic;
using M2.Utils.Web.Models;

namespace M2.Utils.Web.Responses
{
    public class QueryResponseModel
    {
        public string CurrentUrl {get;set;}
        public string RegisterUrl {get;set;}
        public Pagination Pagination {get;set;}
        public IEnumerable<DataResponse> Data {get;set;}
        public ResponseState ResponseState {get;set;} = ResponseState.Success;
    }
}