namespace M2.Utils.Models
{
    public class QueryRequest
    {
        public int CurrentPage {get;set;}
        public object FilterCommand {get;set;}
        public object OrderCommand {get;set;}
    }
}