namespace CustomerProject.DAL.Repositories
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(int entity);
        void Update(TEntity entity);
        void Delete(int entityId);
        void DeleteAll();
        List<TEntity> GetAll();

    }
}
