using HotelApp.Models;

namespace HotelApp.Data.Repositories;

public interface IBookingRepository
{
    void Add(Booking book);
    void Update(Booking book);
    Booking GetById(Guid id);
    
    IEnumerable<Booking> GetAllCurrentByUserId(Guid id);
    
    IEnumerable<Booking> GetAllPastByUserId(Guid id);

    IEnumerable<Booking> GetAllCurrent();
    
    IEnumerable<Booking> GetAllPast();
    void Delete(Guid id);
    
    void UnBook(Guid id);
    
    void UnBookDate();
}