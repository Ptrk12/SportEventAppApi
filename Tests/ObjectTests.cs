using ApplicationCore.Models.req;
using Infrastructure.Entities;
using Infrastructure.Enums;
using Infrastructure.Repositories;
using Managers.managers;
using Microsoft.Extensions.Logging;
using Moq;


namespace Tests
{
    public class ObjectTests
    {
        private readonly Mock<IObjectRepository> _mockObjectRepository;
        private readonly Mock<ISportEventsRepository> _mockSportEventsRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly ObjectManager _objectManager;
        private readonly Mock<ILogger<ObjectManager>> _mockLogger;

        public ObjectTests()
        {
            _mockObjectRepository = new Mock<IObjectRepository>();
            _mockSportEventsRepository = new Mock<ISportEventsRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockLogger = new Mock<ILogger<ObjectManager>>();


            _objectManager = new ObjectManager(
                _mockObjectRepository.Object,
                _mockSportEventsRepository.Object,
                _mockUserRepository.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task CreateObject_ShouldReturnTrue_WhenObjectCreatedSuccessfully()
        {
            // Arrange
            var req = new CreateObjectReq { Name = "Test Object",Description="test",Adress="test",City=Cities.Krakow,
            ObjectType=ObjectTypes.Hall,PricePerHour=12};
            _mockUserRepository.Setup(x => x.GetUserEmailFromToken()).Returns("test@example.com");
            _mockObjectRepository.Setup(x => x.CreateObject(It.IsAny<ObjectEntity>())).ReturnsAsync(true);

            // Act
            var result = await _objectManager.CreateObject(req);

            // Assert
            Assert.True(result);
            _mockObjectRepository.Verify(x => x.CreateObject(It.IsAny<ObjectEntity>()), Times.Once);
        }

        [Fact]
        public async Task GetObjectsCreatedByUser_ShouldReturnObjects_WhenCreatedByUser()
        {
            // Arrange
            var testUser = "test@example.com";
            var objects = new List<ObjectEntity>
            {
                new ObjectEntity { Id = 1, Name = "Object 1", CreatedBy = testUser },
                new ObjectEntity { Id = 2, Name = "Object 2", CreatedBy = "other@example.com" }
            };

            _mockUserRepository.Setup(x => x.GetUserEmailFromToken()).Returns(testUser);
            _mockObjectRepository.Setup(x => x.GetAllObjects()).ReturnsAsync(objects);

            // Act
            var result = await _objectManager.GetObjectsCreatedByUser();

            // Assert
            Assert.Single(result);
            Assert.Equal("Object 1", result.First().Name);
        }

        [Fact]
        public async Task DeleteObject_ShouldReturnFalse_WhenSportEventsExist()
        {
            // Arrange
            _mockSportEventsRepository
                .Setup(x => x.GetAllSportEventsInObject(It.IsAny<int>()))
                .ReturnsAsync(new List<SportEventEntity> 
                {
                    new SportEventEntity {  }
                });


            // Act
            var result = await _objectManager.DeleteObject(1);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task DeleteObject_ShouldReturnTrue_WhenNoSportEventsExist()
        {
            // Arrange
            _mockSportEventsRepository
               .Setup(x => x.GetAllSportEventsInObject(It.IsAny<int>()))
               .ReturnsAsync(new List<SportEventEntity>());

            _mockObjectRepository.Setup(x => x.DeleteObject(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _objectManager.DeleteObject(1);

            // Assert
            Assert.True(result);
            _mockObjectRepository.Verify(x => x.DeleteObject(1), Times.Once);
        }

        [Fact]
        public async Task GetAllObjects_ShouldReturnAllObjects()
        {
            // Arrange
            var objects = new List<ObjectEntity>
            {
                new ObjectEntity { Id = 1, Name = "Object 1" },
                new ObjectEntity { Id = 2, Name = "Object 2" }
            };

            _mockObjectRepository.Setup(x => x.GetAllObjects()).ReturnsAsync(objects);

            // Act
            var result = await _objectManager.GetAllObjects();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetObjectsBaseInfo_ShouldReturnBaseInfo()
        {
            // Arrange
            var objects = new List<ObjectEntity>
            {
                new ObjectEntity { Id = 1, Name = "Object 1" },
                new ObjectEntity { Id = 2, Name = "Object 2" }
            };

            _mockObjectRepository.Setup(x => x.GetAllObjects()).ReturnsAsync(objects);

            // Act
            var result = await _objectManager.GetObjectsBaseInfo();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, x => x.Name == "Object 1 Krakow");
        }

        [Fact]
        public async Task GetObjectById_ShouldReturnObject_WhenFound()
        {
            // Arrange
            var obj = new ObjectEntity { Id = 1, Name = "Object 1" };
            _mockObjectRepository.Setup(x => x.GetObjectById(1)).ReturnsAsync(obj);

            // Act
            var result = await _objectManager.GetObjectById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Object 1", result.Name);
        }

        [Fact]
        public async Task UpdateObject_ShouldReturnTrue_WhenObjectUpdated()
        {
            // Arrange
            var obj = new ObjectEntity { Id = 1, Name = "Old Object" };
            var req = new CreateObjectReq { Name = "Updated Object" };
            _mockObjectRepository.Setup(x => x.GetObjectById(1)).ReturnsAsync(obj);

            _mockSportEventsRepository
               .Setup(x => x.GetAllSportEventsInObject(1))
               .ReturnsAsync(new List<SportEventEntity>
               {
                    new SportEventEntity {  }
               });

            _mockObjectRepository.Setup(x => x.Updateobject(1, It.IsAny<ObjectEntity>())).ReturnsAsync(true);

            // Act
            var result = await _objectManager.UpdateObject(req, 1);

            // Assert
            Assert.True(result);
            _mockObjectRepository.Verify(x => x.Updateobject(1, It.IsAny<ObjectEntity>()), Times.Once);
        }

        [Fact]
        public async Task UpdateObject_ShouldReturnFalse_WhenObjectNotFound()
        {
            // Arrange
            var req = new CreateObjectReq { Name = "Updated Object" };
            _mockObjectRepository.Setup(x => x.GetObjectById(1)).ReturnsAsync((ObjectEntity)null);

            // Act
            var result = await _objectManager.UpdateObject(req, 1);

            // Assert
            Assert.False(result);
        }
    }
}