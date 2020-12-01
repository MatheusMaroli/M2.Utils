using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using M2.Utils.ClassExtensions;
using System.Linq.Expressions;
using System.Linq;

namespace M2.Utils.Test.ClassExtensions
{
    public class TypeObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FilterExpressionExtensionTest
    {
        private IQueryable<TypeObject> data;
        public FilterExpressionExtensionTest()
        {
            var list = new List<TypeObject>();
            for (var i = 1; i <= 10; i++)
                list.Add(new TypeObject() { Id = i, Name = $"Name-{i}" });
            data = list.AsQueryable();
        }

        [Fact]
        public void Should_Be_Return_Filter_With_Id_1()
        {
            var filter = FilterExpressionExtension.InitializeFilter<TypeObject>();
            Expression<Func<TypeObject, bool>> idFilter = f => f.Id == 1;
            filter = filter.And(idFilter);
            var filtedData = data.Where(filter).FirstOrDefault();
            Assert.True(filtedData.Id == 1);
        }

        [Fact]
        public void Should_Be_Return_Filter_With_Id_1_Or_Name_2()
        {
            var filter = FilterExpressionExtension.InitializeFilter<TypeObject>();
            filter = filter.And(f => f.Id == 1);
            filter = filter.Or(f => f.Name.Equals("Name-2"));
            var filtedData = data.Where(filter);
            Assert.True(filtedData.Any(f => f.Id  == 1) && filtedData.Any(f => f.Name.Equals("Name-2")));
        }
    }
}
