using oil_exchange_backend.Models.ViewModels;

namespace oil_exchange_backend.Interfaces
{
    public interface ICustomerManagement
    {
        public void AddCustomer(CustomerManagementVM customer);
    }
}
