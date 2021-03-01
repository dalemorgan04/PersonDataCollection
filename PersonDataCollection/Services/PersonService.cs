using PersonDataCollection.DAL;
using PersonDataCollection.Models;
using System.Threading.Tasks;

namespace PersonDataCollection.Services
{
    public class PersonService : IPersonService
    {
        private readonly IContext _context;

        public PersonService(IContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateStaff(Staff staff)
        {
            try
            {
                _context.Staff.Add(staff);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}