using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositories.Impl
{
    public class BaseRepository : IRepository
    {
        protected IBlogEntities _db;
        protected bool _disposed;
        private readonly SafeHandle _handle;

        public BaseRepository()
        {
            _handle = new SafeFileHandle(IntPtr.Zero, true);
        }

        /// <summary>
        /// Saves any changes made to the database.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var error in e.EntityValidationErrors)
                {
                    // Log stuff
                    //var logger = Logger.Logger.GetLogger("EntityValidationErrorLog");

                    //logger.LogInfo(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    //    error.Entry.Entity.GetType().Name, error.Entry.State));
                    //foreach (var validerror in error.ValidationErrors)
                    //{
                    //    logger.LogError(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                    //        validerror.PropertyName, validerror.ErrorMessage));
                    //}
                }
                throw;
            }
        }
        
        /// <summary>
        /// Public implementation of Dispose pattern callable by consumers. 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern. 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                _handle.Dispose();
            }
            _disposed = true;
        }
    }
}
