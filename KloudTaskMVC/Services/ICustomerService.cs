using KloudTaskMVC.Models;

namespace KloudTaskMVC.Services
{
    public interface ICustomerService
    {
        public void saveCustomer(UsersDTO usersDTO);
        public List<OffersDTO> LoadAllOffers();
        public List<OrderTimeDTO> LoadATime();
    }
}
