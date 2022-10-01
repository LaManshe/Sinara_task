using Sinara_task.Repositories.Interfaces;

namespace Sinara_task.Repositories
{
    public class UserActiveDirectoryChecker : ICheckActiveDirectory
    {
        public bool Check(string ActiveDirectory)
        {
            // is Check and proof token or something
            Random random = new Random();
            int randomNum = random.Next(0, 100);
            return randomNum > 50 ? false : true ;
        }
    }
}
