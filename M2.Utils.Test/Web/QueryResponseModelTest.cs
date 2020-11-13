using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace M2.Utils.Test.Web
{
    public  class QueryResponseModelTest
    {
        private class DataCollection
        {
            public int Id { get; set; }
        }

        [Fact]
        public void Should_Set_Collection_Data()
        {

            try
            {
                var collection = new List<DataCollection>();
                collection.Add(new DataCollection() { Id = 1 });
                collection.Add(new DataCollection() { Id = 2 });
                collection.Add(new DataCollection() { Id = 3 });
                collection.Add(new DataCollection() { Id = 4 });
                collection.Add(new DataCollection() { Id = 5 });
                collection.Add(new DataCollection() { Id = 6 });
                collection.Add(new DataCollection() { Id = 7 });
                collection.Add(new DataCollection() { Id = 8 });
                collection.Add(new DataCollection() { Id = 9 });
                collection.Add(new DataCollection() { Id = 10 });


                var queryResponse = new Utils.Web.Responses.QueryResponseModel();
                queryResponse.Data = collection.Select(c => new { Id = c.Id });
                Assert.True(queryResponse.Data.Count() == 10);
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Fail Test Should_Set_Collection_Data. Fail ===> " + e.ToString());
                Assert.True(false);
            }

        }
    }
}
