using Hotel.DatabaseContext;
using HotelApp.Models;
using HotelApp.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _db;
    
    public BookingRepository(ApplicationDbContext context) 
    { 
        _db = context;
    }
    public void Add(Booking book)
    {
        _db.Booking.Add(book);
        _db.SaveChanges();
    }

    public void Update(Booking book)
    {
        _db.Entry(book).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }
    
    public Booking GetById(Guid id)
    {
        var bookingById = _db.Booking.Include(c => c.room).Include(c => c.room).FirstOrDefault(b => b.Id == id);
        return bookingById ;
    }

    public IEnumerable<Booking> GetAllCurrentByUserId(Guid id)
    {
        var bookingByuserId = _db.Booking
            .Include(c => c.room)
            .Include(c => c.user)
            .Where(b => b.user.Id == id)
            .Where(b => b.dateOut > DateTime.UtcNow)
            .ToList();
        
        return bookingByuserId ;
    }
    
    public IEnumerable<Booking> GetAllPastByUserId(Guid id)
    {
        var bookingByuserId = _db.Booking.Include(c => c.room).Include(c => c.user).Where(b => b.user.Id == id).Where(b => b.dateOut < DateTime.UtcNow).ToList();
        return bookingByuserId ;
    }
    
    public IEnumerable<Booking> GetAllCurrent()
    {
        var bookingByDate = _db.Booking
            .Include(c => c.room)
            .Include(c => c.user)
            .Where(b => b.dateOut > DateTime.UtcNow)
            .OrderByDescending(b => b.lastModified)
            .ToList();
        return bookingByDate ;
    }
    
    public IEnumerable<Booking> GetAllPast()
    {
        return _db.Booking
            .Include(b => b.room)
            .Include(b => b.user)
            .Where(b => b.dateOut < DateTime.UtcNow)
            .OrderByDescending(b => b.lastModified)
            .ToList();
    }

    public void Delete(Guid id)
    {
        var deleteBooking =  _db.Booking.Find(id);
        _db.Booking.Remove(deleteBooking);
         _db.SaveChangesAsync();
    }
    
    public void UnBook(Guid id)
    {
        var deleteBooking =  _db.Booking.Find(id);
        var gg =_db.Room.FirstOrDefault(x => x.Id == deleteBooking.room.Id);
        gg.status = roomState.Available;
        _db.Booking.Remove(deleteBooking);
        _db.SaveChanges();
    }
    
    public void UnBookDate()
    {
   
         var tt =GetAllPast();
         foreach (var p in tt)
         {
             if ( DateTime.UtcNow > p.dateOut && p.room.status != roomState.Booked)
             {
                 p.room.status = roomState.Available;
                 _db.SaveChanges();
             }

         }

  

    }
}