using Microsoft.EntityFrameworkCore;
using System;
using WebCaster.API.Data;
using WebCaster.API.Models;

namespace WebCaster.API.Repositories
{
    public class StationsRepository : IRepository<Station>
    {
        #region ATTRIBUTES

        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Station> _stations;
        private bool disposed = false;

        #endregion

        #region CONSTRUCTORS

        public StationsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _stations = _dbContext.Set<Station>();
        }

        #endregion

        #region METHODS

        public Station? Add(Station station)
        {
            _stations.Add(station);
            
            if (_dbContext.SaveChanges() > 0)
                return station;

            return null;
        }

        public List<Station> GetAll()
        {
            return _stations.ToList<Station>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Station? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Station entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Station entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
