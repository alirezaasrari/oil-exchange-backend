//using oil_exchange_backend.Context;
//using oil_exchange_backend.Interfaces;
//using oil_exchange_backend.Models;
//using oil_exchange_backend.Models.ViewModels;

//namespace oil_exchange_backend.Services
//{
//    public class CustomerManegemantService : ICustomerManagement
//    {
//        private readonly DataContext _dataContext;
//        public CustomerManegemantService(DataContext context)
//        {
//            _dataContext = context;
//        }
       
//        public void AddCustomer(CustomerManagementVM customer)
//        {
//           CustomerManagement customerManegemant = new CustomerManagement();
//            customerManegemant.plaque = customer.plaque;
//            customerManegemant.userid = customer.userid;
//            customerManegemant.oilfilter = customer.oilfilter;  
//            customerManegemant.gearboxoil = customer.gearboxoil;
//            customerManegemant.airfilter = customer.airfilter;
//            customerManegemant.breakeoil = customer.breakeoil;  
//            customerManegemant.cabinfilter = customer.cabinfilter;
//            customerManegemant.engineoil = customer.engineoil;
//            customerManegemant.previouskilometer = customer.previouskilometer;
//            customerManegemant.nextkilometer = customer.nextkilometer;
//            customerManegemant.petrolfilter = customer.petrolfilter;
//            customerManegemant.untifreez = customer.untifreez;
//            customerManegemant.hydraulicoil = customer.hydraulicoil;
//            _dataContext.customermanagement.Add(customerManegemant);
//            _dataContext.SaveChanges();

//        }
//        public List<CustomerManagement> GetCustomers()
//        {
//            return _dataContext.customermanagement.ToList();
//        }
//}
//}
