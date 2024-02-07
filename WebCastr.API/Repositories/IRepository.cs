namespace WebCastr.API.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        public TEntity? Add(TEntity entity);
        public TEntity? GetById(int id);
        public List<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}