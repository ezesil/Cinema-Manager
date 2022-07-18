using BaseServices.Domain;
using BaseServices.Exceptions;
using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    internal class ExceptionBLL
    {
        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        Services.Logger _logger;
        #region
        private readonly static ExceptionBLL _instance = new ExceptionBLL();

        public static ExceptionBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private ExceptionBLL()
        {
            _logger = ServiceContainer.Get<Services.Logger>();
        }
        #endregion

        public void Handle(Exception ex, Log? log = null)
        {
            if (ex == null)
                return;
            
            if (ex is BLLException)
            {
                Handle(ex as BLLException);
            }

            else if (ex is DALException)
            {
                Handle(ex as DALException);
            }

            else
            {
                if (ex == null)
                    return;

                else
                {
                    _logger.Log(ex.Message, Log.Severity.Unknown, ex.StackTrace?.ToString());
                }              
            }
        }

        private void Handle(BLLException ex)
        {

            if (ex.InnerException is DALException)
            {
                _logger.Log(ex.Message, Log.Severity.DebugInformation);
                return;
            }
            
            else
            {
                _logger.Log(ex.Message, Log.Severity.LogicError);
                return;
            }
        }

        private void Handle(DALException ex)
        {
            _logger.Log(ex.Message, Log.Severity.DataAccessError);
            throw new BLLException(ex.Message, ex);
        }
    }
}
