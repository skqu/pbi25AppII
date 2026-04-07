using Livecode.Dtos;

namespace Livecode.Services
{
    public class UserService
    {
        private readonly List<Post> _posts = new List<Post>();
        public Post[] AllPosts()
        {
            return _posts.ToArray();
        }

        public void AddPost(Post post)
        {
            _posts.Add(post);
        }
    }
}