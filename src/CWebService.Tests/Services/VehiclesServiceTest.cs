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
    public class VehicleServiceTest {

        private readonly VehicleService vehicleService;

        public VehicleServiceTest() {
            var vehicleRepository = new Mock<IVehicleRepository>();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new VehicleProfile()));
            var mapperMock = new Mapper(configuration);
            
            var vehicle = new Vehicle {
                Plate = "ABC1111"
            };

            vehicleRepository.Setup(mock => mock.Get()).Returns(async () => {
                return await Task.Run(() => {
                    return new Vehicle[] { vehicle }.ToList();
                });
            });

            vehicleRepository.Setup(mock => mock.GetSingle(It.Is<long>((i) => i == 1))).Returns(async () => {
                return await Task.Run(() => {
                    return vehicle;
                });
            });

            vehicleRepository.Setup(mock => mock.InsertIntoDatabase(It.IsAny<Vehicle>())).Returns(async () => {
                return await Task.Run(() => {
                    return true;
                });
            });

            vehicleRepository.Setup(mock => mock.UpdateIntoDatabase(It.IsAny<Vehicle>())).Returns(async () => {
                return await Task.Run(() => {
                    return true;
                });
            });

            vehicleRepository.Setup(mock => mock.InsertIntoDatabase(It.Is<Vehicle>(vehicle => vehicle.Plate == "ABC1234"))).Throws(new FileNotFoundException());
            vehicleRepository.Setup(mock => mock.UpdateIntoDatabase(It.Is<Vehicle>(vehicle => vehicle.Plate == "ABC1234"))).Throws(new FileNotFoundException());

            this.vehicleService = new VehicleService(vehicleRepository.Object, mapperMock);   
        }

        [Fact]
        async public void Should_GetAll_Vehicles() {
            var records = await this.vehicleService.GetAll();
            Assert.Equal(1, records.Count);
        }

        [Fact]
        async public void Should_GetASingle_Vehicle() {
            var record = await this.vehicleService.GetSingle(1);
            Assert.Equal("ABC1111", record.Plate);
        }

        [Fact]
        async public void Should_Create_Vehicle() {
            var vehicle = new VehicleModel {
                Plate = "ABC1111",
                BrandId = 1,
                ModelId = 1,
                Year = 2020,
                CostPerHour = 9.99,
                FuelType = Domain.Enums.FuelType.Flex,
                TrunkCapacity = 1.99,
                Category = Domain.Enums.Category.Basic
            };

            var create = await this.vehicleService.Create(vehicle);

            Assert.True(create);
        }

        [Fact]
        public void Should_FailCreate_Vehicle() {
            var vehicle = new VehicleModel {
                Plate = "ABC1234"
            };

            Assert.ThrowsAsync<FileNotFoundException>(() => this.vehicleService.Create(vehicle));
        }

        [Fact]
        async public void Should_Update_Vehicle() {
            var vehicle = new VehicleModel {
                Plate = "ABC1111",
                BrandId = 1,
                ModelId = 1,
                Year = 2020,
                CostPerHour = 9.99,
                FuelType = Domain.Enums.FuelType.Flex,
                TrunkCapacity = 1.99,
                Category = Domain.Enums.Category.Basic
            };

            var create = await this.vehicleService.Update(vehicle);

            Assert.True(create);
        }

        [Fact]
        public void Should_FailUpdate_Model() {
            var vehicle = new VehicleModel {
                Plate = "ABC1234"
            };

            Assert.ThrowsAsync<FileNotFoundException>(() => this.vehicleService.Update(vehicle));
        }
    }

}