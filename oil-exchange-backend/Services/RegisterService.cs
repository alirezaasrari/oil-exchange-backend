using oil_exchange_backend.Context;
using oil_exchange_backend.Interfaces;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;

namespace oil_exchange_backend.Services
{
    public class RegisterService: IRegisterservice
    {
        private DataContext _Context { get; set; }
        public RegisterService(DataContext Context)
        {
            _Context = Context;
        }
        public void Addusers(UsersVM user)
        {
            users _users = new users();
            
                _users.storename = user.storename;
                _users.registereddate = DateTime.Now;
                _users.pass = user.pass;
                _users.phonenumber = user.phonenumber;
                _Context.users.Add(_users);
                _Context.SaveChanges();
        }
    }
}
