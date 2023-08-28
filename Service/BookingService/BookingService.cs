using HotelApp.Data.Repositories;
using HotelApp.Models;


namespace Hotel.Services.BookingService;

public class BookingService :IBookingService
{

    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IUserRepository _userRepository;

    
    public BookingService(IBookingRepository bookingRepository,IRoomRepository roomRepository,IUserRepository userRepository) 
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
        _userRepository = userRepository;
    }
    // public async Task<BookingListViewModel> GetBookingById(Guid id)
    // {
    //     var getBooking = _bookingRepository.GetById(id);
    //     
    //     if (getBooking == null)
    //     {
    //         return null;
    //     }
    //     
    //     var viewModel = new BookingListViewModel()
    //     {
    //         // BookingId = getBooking.BookingId,
    //         // DateIn = getBooking.DateIn,
    //         // DateOut = getBooking.DateOut,
    //         // LastModified = getBooking.LastModified,
    //         // Userid = getBooking.User.UserId,
    //         // FirstName = getBooking.User.FirstName,
    //         // LastName = getBooking.User.LastName,
    //         // UserEmail = getBooking.User.UserEmail,
    //         // RoleType = getBooking.User.RoleType,
    //         // Roomid = getBooking.Room.RoomId,
    //         // RoomName = getBooking.Room.RoomName,
    //         // RoomPicture = getBooking.Room.RoomPicture,
    //         // Status = getBooking.Room.Status,
    //         // CategoryType = getBooking.Room.CategoryType,
    //         // Cost = getBooking.Room.Cost,
    //     };
    //
    //     return viewModel;
    // }
    //
    //
    // public async Task<IEnumerable<Booking>> GetCurrentBookingList()
    // {
    //     var bookings = _bookingRepository.GetAllCurrent();
    //
    //     return bookings;
    // }
    //
    // public async Task<IEnumerable<Booking>> GetPastBookingList()
    // {
    //     return _bookingRepository.GetAllPast();
    // }
    // public async Task<IEnumerable<Booking>> GetCurrentBookingListByUserId(Guid id)
    // {
    //     
    //     return _bookingRepository.GetAllCurrentByUserId(id);
    // }
    //
    // public async Task<IEnumerable<Booking>> GetPastBookingListByUserId(Guid id)
    // {
    //     return _bookingRepository.GetAllPastByUserId(id);
    // }
    //
    //
    // public async Task<Booking> GetBookingByUserId(Guid id)
    // {
    //     
    //     return _bookingRepository.GetById(id);
    // }
    //
    //
    // public async Task<BookingViewModel> CreateBooking(BookingDto model)
    // {
    //     var newBooking = new Booking
    //     {
    //         // BookingId = Guid.NewGuid(),
    //         // DateIn = model.DateIn,
    //         // DateOut = model.DateOut,
    //         // User = _userRepository.GetById(model.UserId),
    //         // Room = _roomRepository.GetById(model.RoomId),
    //         // LastModified = DateTime.UtcNow
    //     };
    //             
    //
    //     
    //     _bookingRepository.Add(newBooking);
    //
    //
    //     var viewModel = new BookingViewModel
    //     {
    //         // BookingId = newBooking.BookingId,
    //         // DateIn = newBooking.DateIn,
    //         // DateOut = newBooking.DateOut,
    //         // Userid = newBooking.User.UserId,
    //         // Roomid = newBooking.Room.RoomId
    //     };
    //     
    //     var tt = _roomRepository.getRoomById(model.RoomId);
    //     _bookingRepository.UnBookDate();
    //     _roomRepository.UpdateNoSave(tt);
    //     return viewModel;
    // }
    //
    // public void UpdateBooking(EditBookingRequestModel model)
    // {
    //     
    //     var editBooking = new Booking()
    //     {
    //         // BookingId = model.BookingId,
    //         // DateIn = model.DateIn,
    //         // DateOut = model.DateOut,
    //         // User = _userRepository.GetById(model.UserId),
    //         // Room = _roomRepository.GetById(model.RoomId),
    //         // LastModified = DateTime.UtcNow
    //     };
    //     
    //     _bookingRepository.Update(editBooking);
    // }
    //
    // public void DeleteBooking(Guid id)
    // {
    //     _bookingRepository.UnBook(id);
    // }
}