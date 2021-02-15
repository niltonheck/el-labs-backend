
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CWebService.Application.Models;
using CWebService.Application.Profiles;
using CWebService.Application.Services;
using CWebService.Domain.Entities;
using CWebService.Domain.Repositories;
using Moq;
using Xunit;

namespace CWebService.Tests {
    public class BrandServiceTest
    {
        public readonly BrandService brandService;

        public BrandServiceTest() {
            var brandRepository = new Mock<IBrandRepository>();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new BrandProfile()));
            var mapperMock = new Mapper(configuration);

            var brand = new Brand {
                Name = "Generic Brand",
            };

            var brandCommited = new Brand {
                Id = 1,
                Name = "Generic Brand",
            };

            brandRepository.Setup(mock => mock.Get()).Returns(async () => {
                return await Task.Run(() => {
                    return new Brand[] { brand }.ToList();
                });
            });

            brandRepository.Setup(mock => mock.InsertIntoDatabase(It.IsAny<Brand>())).Returns(async () => {
                return await Task.Run(() => {
                    return brandCommited;
                });
            });

            brandRepository.Setup(mock => mock.UpdateIntoDatabase(It.IsAny<Brand>())).Returns(async () => {
                return await Task.Run(() => {
                    return brandCommited;
                });
            });

            brandRepository.Setup(mock => mock.InsertIntoDatabase(It.Is<Brand>((brand) => brand.Name == "GM"))).Throws(new FileNotFoundException());
            brandRepository.Setup(mock => mock.UpdateIntoDatabase(It.Is<Brand>((brand) => brand.Name == "GM"))).Throws(new FileNotFoundException());

            this.brandService = new BrandService(brandRepository.Object, mapperMock);
        }

        [Fact]
        async public void Should_Create_Brand() {
            var newBrand = new BrandModel {
                Name = "Generic Brand"
            };

            var create = await this.brandService.Create(newBrand);

            Assert.Equal(1, create.Id);
            Assert.Equal("Generic Brand", create.Name);
        }

        [Fact]
        public void Should_ThrownErrorCreating_Brand() {
            var newBrand = new BrandModel {
                Name = "GM"
            };

            Assert.ThrowsAsync<FileNotFoundException>(async () => await this.brandService.Create(newBrand));
        }

        [Fact]
        async public void Should_Update_Brand() {
            var brand = new BrandModel {
                Name = "Generic Brand"
            };

            var edited = await this.brandService.Update(brand);

            Assert.Equal(1, edited.Id);
            Assert.Equal("Generic Brand", edited.Name);
        }

        [Fact]
        public void Should_ThrownErrorUpdateding_Brand() {
            var brand = new BrandModel {
                Name = "GM"
            };

            Assert.ThrowsAsync<FileNotFoundException>(async () => await this.brandService.Update(brand));
        }

        [Fact]
        async public void Should_GetListOf_Brands()
        {
            var actual = await this.brandService.GetAll();

            Assert.Equal(1, actual.Count);
            Assert.Equal("Generic Brand", actual.First().Name);
        }
    }

}