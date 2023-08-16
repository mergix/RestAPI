using HotelApp.Models;

namespace HotelApp.Data.Repositories;

public interface IUserRepository
{
    void Add(User user);
    void Update(User user);
    IEnumerable<User> GetAllUsersByDateModified();
    User FindByUserId(Guid id);
    User checkEmail(string email);
    
    User LoginUser(string email,string password);

    User LoginAdmin(string email, string password);

    void Delete(Guid id);
}