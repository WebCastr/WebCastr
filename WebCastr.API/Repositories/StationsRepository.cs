using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using WebCastr.API.Data;
using WebCastr.API.Models;

namespace WebCastr.API.Repositories
{
    public class StationsRepository : IRepository<Station>
    {
        #region ATTRIBUTES

        private readonly ApplicationDbContext _db;
        private readonly DbSet<Station> _stations;
        private bool disposed = false;

        #endregion

        #region CONSTRUCTORS

        public StationsRepository(ApplicationDbContext db)
        {
            _db = db;
            _stations = _db.Set<Station>();
        }

        #endregion

        #region METHODS

        public Station? Add(Station station)
        {
            EntityEntry<Station> newEntry = _stations.Add(station);
            _db.SaveChanges();
            
            if (newEntry.Entity.Id > 0)
                return newEntry.Entity;

            return null;
        }

        public List<Station> GetAll()
        {
            return _stations.ToList<Station>();
        }

        public Station? GetById(int id)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
