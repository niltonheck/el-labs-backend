using CWebService.Domain.Entities;
using Xunit;

namespace CWebService.Tests
{
    public class BrandTest
    {
        [Fact]
        public void Should_CreateValid_Brand()
        {
            var brand = new Brand{
                Name = "Generic Brand"
            };

            Assert.NotNull(brand);
            Assert.NotNull(brand.Name);
        }
    }
}
