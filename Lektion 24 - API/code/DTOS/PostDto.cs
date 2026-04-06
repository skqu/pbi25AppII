using Microsoft.AspNetCore.Routing.Constraints;

namespace Code.Dtos
{
    public class Post
    {
        public string Content
        {
            get;
            set;
        } = string.Empty;

        public string Author
        {
            get;
            set;
        } = string.Empty;

        public string Id
        {
            get; 
            set;
        } = string.Empty;
    }
}