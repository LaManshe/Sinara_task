namespace Sinara_task.Repositories.Interfaces
{
    public interface ICRUDDbRepository<T>
        where T : class
    {
        void Add(T data, string ActiveDirectory);
        List<T> Get(string ActiveDirectory);
        void Delete(int id);
        void Edit(T data);
        bool IsUserExist(string ActiveDirectory);
    }
}
