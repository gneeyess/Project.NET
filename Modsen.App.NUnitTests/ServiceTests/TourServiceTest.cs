using AutoMapper;
using Modsen.App.API.Services;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Repositories;
using Moq;

namespace Modsen.App.NUnitTests.ServiceTests;

public class TourServiceTest
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mock<ITourRepository> _tourRepositoryMock;
    private readonly Mock<ITourTypeRepository> _tourTypeRepositoryMock;
    private readonly Mock<ITransportRepository> _transportRepositoryMock;
    private readonly Mock<IBookingRepository> _bookingRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    public TourServiceTest()
    {
        _tourRepositoryMock = new Mock<ITourRepository>();
        _tourTypeRepositoryMock = new Mock<ITourTypeRepository>();
        //_tourRepositoryMock.Setup(x=>x.AddAsync()).Returns();
        _transportRepositoryMock = new Mock<ITransportRepository>();
        _bookingRepositoryMock = new Mock<IBookingRepository>();

        _unitOfWork = new UnitOfWork(_bookingRepositoryMock.Object,
            _tourRepositoryMock.Object,
            _tourTypeRepositoryMock.Object,
            _transportRepositoryMock.Object);
        _mapperMock = new Mock<IMapper>();
    }
    //[Test]
    //[Theory]
    //public async Task GetAsyncTest()
    //{
    //    var service = new TourService(_unitOfWork, _mapperMock.Object);

    //    var actual = await service.GetAsync(1);

    //    Assert.That(actual, Is.Null);
    //}
}