using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SistemaPrefeitura.Application.Services.Shared;
using SistemaPrefeitura.Domain.DataContracts.Shared;
using SistemaPrefeitura.Unit.Tests.TestModels;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Unit.Tests.ServicesTests
{
    public class BaseServiceTests
    {

        protected BaseService<TestEntity, IBaseRepository<TestEntity>> SUT;
        protected Mock<IBaseRepository<TestEntity>> _baseRepository;
        protected Fixture _fixture;

        public BaseServiceTests()
        {
            _baseRepository = new Mock<IBaseRepository<TestEntity>>();
            _fixture = new Fixture();
            SUT = new BaseService<TestEntity, IBaseRepository<TestEntity>>(_baseRepository.Object);
        }

        public class AddAsyncTests : BaseServiceTests
        {
            [Test]
            public async Task ShouldNotThrowOnSuccessfulAdd()
            {
                // Arrange
                var expectedResult = _fixture.Create<TestEntity>();
                _baseRepository.Setup(x => x.AddAsync(It.IsAny<TestEntity>())).Returns(Task.FromResult(expectedResult));

                // Act
                var actualResult = await SUT.AddAsync(expectedResult);

                // Assert
                Assert.AreEqual(expectedResult.Id, actualResult.Id);
                Assert.IsNotNull(actualResult);
            }
        }

        public class GetAllAsyncTests : BaseServiceTests
        {
            [Test]
            public async Task ShouldReturnExpectedOnSuccessfullGetAllAsync()
            {
                // Arrange
                var expectedResult = _fixture.CreateMany<TestEntity>();
                _baseRepository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(expectedResult));

                // Act
                var actualResult = await SUT.GetAllAsync();

                // Assert
                Assert.IsNotEmpty(actualResult);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        public class GetByIdAsyncTests : BaseServiceTests {

            [Test]
            public async Task ShouldReturnExpectedOnSuccessfullGetAllAsync()
            {
                // Arrange
                var expectedResult = _fixture.Create<TestEntity>();
                _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult(expectedResult));

                // Act
                var actualResult = await SUT.GetByIdAsync(Guid.NewGuid());

                // Assert
                Assert.IsNotNull(actualResult);
                Assert.AreEqual(expectedResult, actualResult);
            }


        }

        public class UpdateAsyncTests : BaseServiceTests
        {
            [Test]
            public async Task ShouldReturnUpdatedItemOnSuccessfulUpdate()
            {
                // Arrange
                var expectedResult = _fixture.Create<TestEntity>();
                _baseRepository.Setup(x => x.UpdateAsync(It.IsAny<TestEntity>())).Returns(Task.FromResult(expectedResult));

                // Act
                var actualResult = await SUT.UpdateAsync(expectedResult);

                // Assert
                Assert.IsNotNull(actualResult);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        public class DeleteAsyncTests : BaseServiceTests
        {
            [Test]
            public void ShouldNotThrowOnDelete()
            {
                // Arrange
                _baseRepository.Setup(x => x.RemoveByIdAsync(It.IsAny<Guid>())).Returns(Task.CompletedTask);

                // Act


                // Assert
                Assert.DoesNotThrowAsync(() => SUT.DeleteByIdAsync(Guid.NewGuid()));

            }
        }
    }
}
