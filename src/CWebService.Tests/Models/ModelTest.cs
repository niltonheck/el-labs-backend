using CWebService.Domain.Entities;
using Xunit;

namespace CWebService.Tests
{
    public class ModelTest
    {
        [Fact]
        public void Should_CreateValid_Model()
        {
            var model = new Model{
                Name = "Generic Model",
                BrandId = 1
            };

            Assert.NotNull(model);
            Assert.NotNull(model.Name);
            Assert.NotNull(model.BrandId);
        }
    }
}
