namespace CustomerProject.DAL.Repositories
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        public TEntity Read(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);

    }
}
