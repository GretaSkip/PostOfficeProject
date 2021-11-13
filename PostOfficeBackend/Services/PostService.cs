using PostOfficeBackend.Entities;
using PostOfficeBackend.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostOfficeBackend.Services
{
    public class PostService
    {
        private PostRepository _postRepository;
        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetAllAsync() =>
            await _postRepository.GetAsync();


        public async Task<int> CreateAsync(Post post) =>
            await _postRepository.CreateAsync(post);


        public async Task<Post> GetByIdAsync(int id) =>
            await _postRepository.GetByIdAsync(id);


        public async Task RemoveAsync(int id)
        {
            var post = await GetByIdAsync(id);
            await _postRepository.RemoveAsync(post);
        }

        public async Task UpdateAsync(Post post)
        {
            var existingPost = await _postRepository.GetByIdAsync(post.Id);
            if (existingPost != null)
            {
                existingPost.Name = post.Name;
                existingPost.Town = post.Town;
                existingPost.Capacity = post.Capacity;
                existingPost.Code = post.Code;
            }
            await _postRepository.UpdateAsync(existingPost);
        }
    }
}
