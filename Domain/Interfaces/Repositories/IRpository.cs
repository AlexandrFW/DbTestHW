namespace DbTestHW.Domain.Interfaces.Repositories;

public interface IRpository<T> where T : class
{
    public List<T> GetCollection();

    public T AddItem(T item);

    public T GetById(int id);

    public T EditItem(T item, int id);

    public void DeleteItem(int id);
}