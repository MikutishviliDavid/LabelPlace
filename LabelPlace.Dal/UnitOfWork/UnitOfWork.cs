using LabelPlace.Dal.GenericRepository;
using LabelPlace.Domain.Entities;
using System;

namespace LabelPlace.Dal.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly LabelPlaceContext _context = new LabelPlaceContext();
        //private readonly GenericRepository<BaseEntity> _baseEntityRepository; 
        private GenericRepository<Company> _companyRepository;
        private GenericRepository<Project> _projectRepository;
        private GenericRepository<Role> _roleRepository;
        private GenericRepository<TextAnnotation> _textAnnotationRepository;
        private GenericRepository<User> _userRepository;

        public GenericRepository<Company> CompanyRepositiry
        { 
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new GenericRepository<Company>(_context);
                }

                return _companyRepository;
            } 
        }

        public GenericRepository<Project> ProjectRepositiry
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new GenericRepository<Project>(_context);
                }

                return _projectRepository;
            }
        }

        public GenericRepository<Role> RoleRepositiry
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new GenericRepository<Role>(_context);
                }

                return _roleRepository;
            }
        }  

        public GenericRepository<TextAnnotation> TextAnnotationRepository
        {
            get
            {
                if (_textAnnotationRepository == null)
                {
                    _textAnnotationRepository = new GenericRepository<TextAnnotation>(_context);
                }
                return _textAnnotationRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new GenericRepository<User>(_context);
                }
                return _userRepository;
            }
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
