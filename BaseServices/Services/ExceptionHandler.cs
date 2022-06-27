﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.BLL;
using BaseServices.Domain;

namespace BaseServices.Services
{
    /// <summary>
    /// Gestiona la recepcion de excepciones para su posterior manejo.
    /// </summary>
    public class ExceptionHandler
    {
        /// <summary>
        /// Maneja y registra una excepcion.
        /// </summary>
        /// <param name="ex">Excepcion.</param>
        public void Handle(Exception ex)
        {
            return;
            ExceptionBLL.Current.Handle(ex);
        }

        /// <summary>
        /// Maneja y registra una excepcion.
        /// </summary>
        /// <param name="ex">Excepcion.</param>
        public void Handle(Exception ex, Log log)
        {
            return;
            ExceptionBLL.Current.Handle(ex, log);
        }

        /// <summary>
        /// Maneja y registra una excepcion.
        /// </summary>
        /// <param name="ex">Excepcion.</param>
        public void Handle(Exception ex, string message, Log.Severity severity)
        {
            return;
            var log = new Log(message, severity, ex.StackTrace);
            ExceptionBLL.Current.Handle(ex, log);
        }
    }
}
