using Microsoft.EntityFrameworkCore;
using PostOfficeBackend.Data;
using PostOfficeBackend.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostOfficeBackend.Repositories
{
    public class PostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAsync() =>
            await _context.Posts.OrderBy(p => p.Code).ToListAsync();


        public async Task<Post> GetByIdAsync(int id) =>
            await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);


        public async Task<int> CreateAsync(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public async Task RemoveAsync(Post post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
