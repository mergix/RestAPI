using Hotel.DatabaseContext;
using HotelApp.Models;
using HotelApp.Models.Enums;

using Microsoft.EntityFrameworkCore;

namespace HotelApp.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext context) 
    { 
        _db = context;
    }
    
    public void Add(User user)
    {
        _db.User.Add(user);
        _db.SaveChanges();
    }

    public void Update(User user)
    {
        _db.Entry(user).State = EntityState.Modified;
        _db.SaveChangesAsync();
    }

    public IEnumerable<User> GetAllUsersByDateModified()
    {
        return _db.User.OrderByDescending(u => u.lastModified).ToList();
    }

    public User FindByUserId(Guid id)
    {
        var userById = _db.User.Find(id);
        return userById ;
    }
    
    public User checkEmail(string email)
    {
        return _db.User.FirstOrDefault(m => m.UserEmail == email);
    }
    
    public User LoginUser(string email,string password)
    {
        // Convert password to hash
        
        // _passwordHasher.Verify()
        
        return _db.User.FirstOrDefault(m => m.UserEmail == email && m.UserPasswordHash == password && m.roleType == Role.user);
    }
    
    public User LoginAdmin(string email,string password)
    {
        return _db.User.FirstOrDefault(m => m.UserEmail == email && m.UserPasswordHash == password && m.roleType == Role.admin);
    }

    

    public void Delete(Guid id)
    {
        var deleteUser =  _db.User.Find(id);
        _db.User.Remove(deleteUser);
         _db.SaveChangesAsync();
    }
}