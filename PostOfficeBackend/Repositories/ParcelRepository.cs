using Microsoft.EntityFrameworkCore;
using PostOfficeBackend.Data;
using PostOfficeBackend.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostOfficeBackend.Repositories
{
    public class ParcelRepository
    {
        private readonly DataContext _context;

        public ParcelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Parcel>> GetAsync() =>
            await _context.Parcels.Include(p => p.Post).OrderBy(r => r.Weight).ToListAsync();


        public async Task<Parcel> GetByIdAsync(int id) =>
            await _context.Parcels.FirstOrDefaultAsync(p => p.Id == id);


        public async Task<List<Parcel>> GetByPostIdAsync(int postId) =>
            await _context.Parcels.Include(r => r.Post).Where(p => p.PostId == postId).ToListAsync();


        public async Task<int> CreateAsync(Parcel parcel)
        {
            _context.Add(parcel);
            await _context.SaveChangesAsync();
            return parcel.Id;
        }

        public async Task RemoveAsync(Parcel parcel)
        {
            _context.Remove(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            _context.Parcels.Update(parcel);
            await _context.SaveChangesAsync();
        }
    }
}

