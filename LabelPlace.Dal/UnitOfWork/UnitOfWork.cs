using LabelPlace.Dal.GenericRepository;
using LabelPlace.Domain.Entities;
using System;

namespace LabelPlace.Dal.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly LabelPlaceContext _context;

        public UnitOfWork(LabelPlaceContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
