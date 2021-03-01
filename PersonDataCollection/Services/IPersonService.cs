using PersonDataCollection.Models;
using System.Threading.Tasks;

namespace PersonDataCollection.Services
{
    public interface IPersonService
    {
        Task<bool> CreateStaff(Staff staff);

        Task<bool> CreateClient(Client client);
    }
}