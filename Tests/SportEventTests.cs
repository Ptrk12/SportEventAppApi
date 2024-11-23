using ApplicationCore.Models.req;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Managers.managers;
using Moq;
using System.Text.Json;

namespace Tests
{
    public class SportEventTests
    {
        private readonly Mock<IObjectRepository> _mockObjectRepository;
        private readonly Mock<ISportEventsRepository> _mockSportEventsRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly SportEventManager _sportEventManager;

        public SportEventTests()
        {
            _mockSportEventsRepository = new Mock<ISportEventsRepository>();
            _mockObjectRepository = new Mock<IObjectRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _sportEventManager = new SportEventManager(
                _mockSportEventsRepository.Object,
                _mockObjectRepository.Object,
                _mockUserRepository.Object
            );
        }

        [Fact]
        public async Task CreateSportEvent_ShouldReturnTrue_WhenSportEventIsCreatedSuccessfully()
        {
            // Arrange
            var sportEventReq = new CreateSportEventReq { ObjectId = 1, AmountOfPlayers = 2, Time = 1 };
            var mockObject = new ObjectEntity { Id = 1, PricePerHour = 100 };
            var sportEventEntity = new SportEventEntity { Id = 1, ObjectId = 1 };

            _mockObjectRepository.Setup(repo => repo.GetObjectById(It.IsAny<int>()))
                .ReturnsAsync(mockObject);

            _mockSportEventsRepository
                .Setup(repo => repo.CreateSportEvent(It.IsAny<SportEventEntity>()))
                .ReturnsAsync((true, new SportEventEntity { Id = 1, ObjectId = 1 }));

            _mockUserRepository.Setup(repo => repo.GetUserEmailFromToken())
                .Returns("testuser@test.com");

            _mockUserRepository.Setup(repo => repo.GetUserMone(It.IsAny<string>()))
                .ReturnsAsync(1000);

            _mockUserRepository.Setup(repo => repo.UpdateUserMoney(It.IsAny<string>(), It.IsAny<double>()))
                .ReturnsAsync(true);

            _mockSportEventsRepository.Setup(repo => repo.CreateAssignedPeopleRecord(It.IsAny<EventAssignersEntity>()))
                .ReturnsAsync(true);

            // Act
            var result = await _sportEventManager.CreateSportEvent(sportEventReq);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetCurrentLoggedUserEventsAssignedTo_ShouldReturnAssignedEvents()
        {
            var mockObject = new ObjectEntity { Id = 1, PricePerHour = 100 };
            var mockSportEvent = new SportEventEntity { Id = 1, ObjectId = 1, Object = mockObject, DateWhen = DateTime.MaxValue };
            var assigners = JsonSerializer.Serialize(new List<string> { "testuser@test.com" });

            _mockSportEventsRepository.Setup(repo => repo.GetAllSportEvents())
                .ReturnsAsync(new List<SportEventEntity> { mockSportEvent });

            _mockSportEventsRepository.Setup(repo => repo.GetAssignersInEvent(It.IsAny<int>()))
                .ReturnsAsync(assigners);

            _mockObjectRepository.Setup(repo => repo.GetObjectById(It.IsAny<int>()))
                .ReturnsAsync(mockObject);

            _mockUserRepository.Setup(repo => repo.GetUserEmailFromToken())
                .Returns("testuser@test.com");

            // Act
            var result = await _sportEventManager.GetCurrentLoggedUserEventsAssignedTo();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.True(result.First().CurrentUserAssignedToEvent);
        }

        [Fact]
        public async Task DeleteSportEvent_ShouldReturnTrue_WhenUserCanDeleteEvent()
        {
            // Arrange
            var mockSportEvent = new SportEventEntity { Id = 1, CreatedBy = "testuser@test.com" };

            _mockSportEventsRepository.Setup(repo => repo.GetSportEventById(It.IsAny<int>()))
                .ReturnsAsync(mockSportEvent);

            _mockUserRepository.Setup(repo => repo.GetUserEmailFromToken())
                .Returns("testuser@test.com");

            _mockSportEventsRepository.Setup(repo => repo.DeleteSportEvent(It.IsAny<int>()))
                .ReturnsAsync(true);

            // Act
            var result = await _sportEventManager.DeleteSportEvent(1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task UpdateSportEvent_ShouldReturnTrue_WhenUpdateIsSuccessful()
        {
            // Arrange
            var mockSportEvent = new SportEventEntity { Id = 1, ObjectId = 1, CreatedBy = "testuser@test.com" };
            var sportEventReq = new CreateSportEventReq { ObjectId = 1, AmountOfPlayers = 2, Time = 1 };
            var mockObject = new ObjectEntity { Id = 1, PricePerHour = 100 };

            _mockSportEventsRepository.Setup(repo => repo.GetSportEventById(It.IsAny<int>()))
                .ReturnsAsync(mockSportEvent);

            _mockObjectRepository.Setup(repo => repo.GetObjectById(It.IsAny<int>()))
                .ReturnsAsync(mockObject);

            _mockSportEventsRepository.Setup(repo => repo.UpdateSportEvent(It.IsAny<int>(), It.IsAny<SportEventEntity>()))
                .ReturnsAsync(true);

            _mockUserRepository.Setup(repo => repo.GetUserEmailFromToken())
                .Returns("testuser@test.com");

            // Act
            var result = await _sportEventManager.UpdateSportEvent(sportEventReq, 1);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetSportEventById_ShouldReturnSportEvent_WhenEventExists()
        {
            // Arrange
            var mockObject = new ObjectEntity { Id = 1, PricePerHour = 100 };
            var mockSportEvent = new SportEventEntity { Id = 1, ObjectId = 1, AmountOfPlayers = 2, Time = 2, Object = mockObject };

            _mockSportEventsRepository.Setup(repo => repo.GetSportEventById(It.IsAny<int>()))
                .ReturnsAsync(mockSportEvent);

            _mockObjectRepository.Setup(repo => repo.GetObjectById(It.IsAny<int>()))
                .ReturnsAsync(mockObject);

            // Act
            var result = await _sportEventManager.GetSportEventById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(100, result.Price);
        }






    }
}
