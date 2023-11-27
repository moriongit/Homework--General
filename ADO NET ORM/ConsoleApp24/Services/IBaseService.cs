

namespace ADO.NET.Services;
public interface IBaseService<T>
{
    List<T> GetAll();
    T GetById(int id);
    int Create(T data);
    
}