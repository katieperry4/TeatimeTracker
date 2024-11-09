namespace TeaCapstone.Services
{
    public interface IDbService<T>
    {
        public List<T> GetAllEntities();
        public T GetById(int id);
    }
}
