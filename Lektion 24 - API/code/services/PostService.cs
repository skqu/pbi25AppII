using Code.Dtos;
namespace Code.Services
{
    public class PostService
    {
        private Dictionary<string, Post> _posts = new Dictionary<string, Post>();

        public Dictionary<string, Post> GetPosts()
        {
            return _posts;
        }

        public void AddPost(Post post)
        {
            Console.WriteLine("New PostAdded");
            _posts[post.Id] = post;
        }

        public void UpdatePost(string id, Post post)
        {
            _posts[id] = post; 
        }

        public void DeletePost(string id)
        {
            _posts.Remove(id);
        }
    }
}