using Sinara_task.Data;
using Sinara_task.Models;
using Sinara_task.Repositories.Interfaces;

namespace Sinara_task.Repositories
{
    public class UserRecordsRepository : ICRUDDbRepository<Post>
    {
        private readonly GuideBook_DbContext _context;
        public UserRecordsRepository(GuideBook_DbContext context)
        {
            _context = context;
        }

        public void Add(Post data, string ActiveDirectory)
        {
            Post result = new Post() 
            { 
                Id = GetNextPostId(),
                Title = data.Title, 
                Number = data.Number, 
                UserId = GetUserIdByAD(ActiveDirectory), 
                IsVisible = true 
            };
            _context.Posts.Add(result);
            _context.SaveChanges();
        }

        public List<Post> Get(string ActiveDirectory)
        {
            List<Post> result = new List<Post>();

            result = _context.Posts.Where(item => item.UserId == GetUserIdByAD(ActiveDirectory) && item.IsVisible == true).ToList();

            return result;
        }

        public void Delete(int id)
        {
            Post? postToDelete = _context.Posts.FirstOrDefault(post => post.Id == id);

            if(postToDelete != null)
            {
                postToDelete.IsVisible = false;

                _context.SaveChanges();
            }
        }

        public void Edit(Post data)
        {
            Post? postToEdit = _context.Posts.FirstOrDefault(post => post.Id == data.Id);

            if (postToEdit != null)
            {
                postToEdit.Title = data.Title;
                postToEdit.Number = data.Number;

                _context.SaveChanges();
            }
        }

        private int GetUserIdByAD(string activeDirectory)
        {
            if(activeDirectory == null) { return -1; }

            int? id = _context.Users.FirstOrDefault(item => item.ActiveDirectory == activeDirectory)?.Id;
            if(id < 1 || id == null)
            {
                return -1;
            }

            return (int)id;
        }

        private int GetNextPostId()
        {
            return _context.Posts.Count() == 0 ? 1 : _context.Posts.Max(x => x.Id) + 1;
        }
    }
}
