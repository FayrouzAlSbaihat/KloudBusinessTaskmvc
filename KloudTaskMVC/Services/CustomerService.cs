using KloudTaskMVC.data;
using KloudTaskMVC.Models;

namespace KloudTaskMVC.Services
{
    public class CustomerService: ICustomerService
    {
        SystemContext context;
        public CustomerService(SystemContext _context)
        {
            context = _context;
        }

        public void saveCustomer(UsersDTO usersDTO)
        {
            Users users = new Users()
            {
                Name = usersDTO.Name,
                Phone = usersDTO.Phone,
                Email = usersDTO.Email,
            };
            context.users.Add(users);
            context.SaveChanges();
        }

        public List<OffersDTO> LoadAllOffers()
        {
            List<Offers> offers = context.offers.ToList();
            List<OffersDTO> offersDTO = new List<OffersDTO>();
            foreach (Offers offer in offers)
            {
                offersDTO.Add(new OffersDTO()
                {
                    Id = offer.Id,
                    offers = offer.offers
                });
            }

            return offersDTO;

        }

        public List<OrderTimeDTO> LoadATime()
        {
            List<OrderTime> time = context.orderTime.ToList();
            List<OrderTimeDTO> TimeDTO = new List<OrderTimeDTO>();
            foreach (OrderTime OTime in time)
            {
                TimeDTO.Add(new OrderTimeDTO()
                {
                    Id = OTime.Id,
                    Time = OTime.Time
                });
            }

            return TimeDTO;

        }

    }


    }
