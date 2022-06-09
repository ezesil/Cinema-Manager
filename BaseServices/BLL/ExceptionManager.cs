using BaseServices.Domain.Exceptions;
using BaseServices.Domain.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    internal class ExceptionManager
    {

        #region
        private readonly static ExceptionManager _instance = new ExceptionManager();

        public static ExceptionManager Current
        {
            get
            {
                return _instance;
            }
        }

        private ExceptionManager()
        {

        }
        #endregion


        public void Handle(Exception ex, Log? log = null)
        {

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
                if(ex == null)
                {
                    return;
                }

                else
                {
                    Services.Security.LogServices.LogService.LogEvent(new Log(ex.Message, Log.Severity.Unknown,ex.StackTrace.ToString()));
                }
                
            }


        }



        private void Handle(BLLException ex)
        {

            if (ex.InnerException is DALException)
            {
                Services.Security.LogServices.LogService.LogEvent(new Log(ex.Message, Log.Severity.DebugInformation));
                return;
            }
            
            else
            {
                Services.Security.LogServices.LogService.LogEvent(new Log(ex.Message, Log.Severity.LogicError));
                return;
            }
        }

        private void Handle(DALException ex)
        {
            Services.Security.LogServices.LogService.LogEvent(new Log(ex.Message, Log.Severity.DataAccessError));
            throw new BLLException(ex.Message, ex);
        }



    }
}
