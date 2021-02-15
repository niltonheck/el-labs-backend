using CWebService.Application.Services;
using CWebService.Domain;
using CWebService.Domain.Repositories;
using Moq;
using Xunit;
using System.IO;
using AutoMapper;
using CWebService.Application.Models;
using CWebService.Domain.Entities;
using CWebService.Application.Profiles;
using System.Threading.Tasks;
using System.Linq;

namespace CWebService.Tests {
    public class ModelServiceTest
    {
        public readonly ModelService modelService;

        public ModelServiceTest() {
            var modelRepository = new Mock<IModelRepository>();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new ModelProfile()));
            var mapperMock = new Mapper(configuration);

            var model = new Model {
                Name = "Generic Model",
            };

            var modelQuery = new Model {
                Id = 1,
                Name = "Generic Model",
            };

            modelRepository.Setup(mock => mock.Get()).Returns(async () => {
                return await Task.Run(() => {
                    return new Model[] { model }.ToList();
                });
            });

            modelRepository.Setup(mock => mock.InsertIntoDatabase(It.IsAny<Model>())).Returns(async () => {
                return await Task.Run(() => {
                    return modelQuery;
                });
            });

            modelRepository.Setup(mock => mock.UpdateIntoDatabase(It.IsAny<Model>())).Returns(async () => {
                return await Task.Run(() => {
                    return modelQuery;
                });
            });

            modelRepository.Setup(mock => mock.InsertIntoDatabase(It.Is<Model>(model => model.Name == "KA Sedan 1.6"))).Throws(new FileNotFoundException());
            modelRepository.Setup(mock => mock.UpdateIntoDatabase(It.Is<Model>(model => model.Name == "KA Sedan 1.6"))).Throws(new FileNotFoundException());

            this.modelService = new ModelService(modelRepository.Object, mapperMock);
        }

        [Fact]
        async public void Should_GetListOf_Models()
        {
            var actual = await this.modelService.GetAll();

            Assert.Equal(1, actual.Count);
            Assert.Equal("Generic Model", actual[0].Name);
        }

        [Fact]
        async public void Should_Create_Model() {
            var newModel = new ModelModel {
                Name = "Onix LTE",
                BrandID = 1
            };

            var create = await this.modelService.Create(newModel);

            Assert.Equal(1, create.Id);
            Assert.Equal("Generic Model", create.Name);
        }

        [Fact]
        public void Should_FailCreate_Model() {
            var model = new ModelModel {
                Name = "KA Sedan 1.6",
                BrandID = 1
            };

            Assert.ThrowsAsync<FileNotFoundException>(() => this.modelService.Create(model));
        }
    
        [Fact]
        async public void Should_Update_Model() {
            var newModel = new ModelModel {
                Name = "Onix LTE",
                BrandID = 1
            };

            var create = await this.modelService.Update(newModel);

            Assert.Equal(1, create.Id);
            Assert.Equal("Generic Model", create.Name);
        }

        [Fact]
        public void Should_FailUpdate_Model() {
            var model = new ModelModel {
                Name = "KA Sedan 1.6",
                BrandID = 1
            };

            Assert.ThrowsAsync<FileNotFoundException>(() => this.modelService.Update(model));
        }
    }

}