using BaseServices.Domain;
using BaseServices.Exceptions;
using BaseServices.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    internal class ExceptionBLL
    {
        ExceptionHandler _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
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
            _logger = ServiceContainer.Instance.GetService<Services.Logger>();
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
                    _logger.Log(ex.Message, LogLevel.Unknown, ex.StackTrace?.ToString());
                }              
            }
        }

        private void Handle(BLLException ex)
        {

            if (ex.InnerException is DALException)
            {
                _logger.Log(ex.Message, LogLevel.DebugInformation);
                return;
            }
            
            else
            {
                _logger.Log(ex.Message, LogLevel.LogicError);
                return;
            }
        }

        private void Handle(DALException ex)
        {
            _logger.Log(ex.Message, LogLevel.DataAccessError);
            throw new BLLException(ex.Message, ex);
        }
    }
}
