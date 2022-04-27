using FlightBooking.Models;

namespace FlightBooking.Interfaces
{
    public interface IAdminAuthenticate
    {
        Tokens Authenticate(Admin admin);
    }
}
