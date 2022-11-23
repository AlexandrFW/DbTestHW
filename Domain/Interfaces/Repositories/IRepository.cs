namespace DbTestHW.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    public List<T?> GetCollection();

    public T? AddItem(T item);

    public T? GetById(int id);

    public T? EditItem(T item);

    public void DeleteItem(int id);
}