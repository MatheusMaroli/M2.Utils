using System.Collections.Generic;
using Xunit;
using System.Linq;
using M2.Utils.Models;

namespace M2.Utils.Test.Models
{
    public class PaginationTest
    {
        private class TestPalidation
        {
            public int Id {get;set;}
        }

        [Fact]
        public void Should_Be_5_Page_And_2_Itens_Per_Page()
        {
            var testValid = true;
            var items = new List<TestPalidation>();
            items.Add(new TestPalidation() { Id = 1 });
            items.Add(new TestPalidation() { Id = 2 });
            items.Add(new TestPalidation() { Id = 3 });
            items.Add(new TestPalidation() { Id = 4 });
            items.Add(new TestPalidation() { Id = 5 });
            items.Add(new TestPalidation() { Id = 6 });
            items.Add(new TestPalidation() { Id = 7 });
            items.Add(new TestPalidation() { Id = 8 });
            items.Add(new TestPalidation() { Id = 9 });
            items.Add(new TestPalidation() { Id = 10 });

            IEnumerable<TestPalidation> listPaginated;
            var pagination = new Pagination();
            pagination.ItemsForPage = 2;

            for (var currentPage = 1; currentPage <= 5; currentPage++)
            {
                pagination.CurrentPage = currentPage;
                listPaginated = pagination.ExecutePagination<TestPalidation>(items);
                var resultExpectItem2 = pagination.CurrentPage * 2;
                var resultExpectItem1 = resultExpectItem2 - 1;

                System.Console.WriteLine($"Result 1 {resultExpectItem1}");
                System.Console.WriteLine($"Result 2 {resultExpectItem2}");

                System.Console.WriteLine($"Count {listPaginated.Count()}");
                if (listPaginated.Count() > 2)
                {
                    testValid = false;
                    break;
                }

                if (listPaginated.Count() <= 0)
                {

                    testValid = false;
                    break;
                }

                if (listPaginated.Any(f => f.Id != resultExpectItem1 && f.Id != resultExpectItem2))
                {
                    foreach (var prop in listPaginated)
                        System.Console.WriteLine($"valid {prop.Id} ");

                    testValid = false;
                    break;
                }
            }

            Assert.True(testValid);
        }

        [Fact]
        public void Should_Be_Valid_Pagination()
        {
            var pagination = new Pagination();
            pagination.CurrentPage = 1;
            pagination.ItemsForPage = 20;

            Assert.True(pagination.IsValid());

        }

        [Fact]
        public void Should_Be_Invalid_Pagination()
        {
            var pagination = new Pagination();
            pagination.CurrentPage = 0;
            pagination.ItemsForPage = 0;

            Assert.True(! pagination.IsValid());

        }
    }
}