using ApplicationCore;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookingRepository: EfRepository<Bookings>, IBookingRepository
    {
        public BookingRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
