using BaseServices.BLL;
using BaseServices.Domain.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BaseServices.Services
{
    /// <summary>
    /// Provee servicios de tipo Digito Verificador Horizontal y Vertical.
    /// </summary>
    public class CheckerDigitService
    {
        public CheckerDigitService()
        {

        }

        /// <summary>
        /// Calcula el digito verficiador horizontal para la cadena de bytes especificada.
        /// </summary>
        /// <param name="cadena"></param>
        public decimal CalcularDVH(string cadena)
        {
            return CheckDigitManager.Current.CalculateDVH(cadena);
        }


        /// <summary>
        /// Obtiene el digito verficiador vertical para la cadena de DVH especificada.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public decimal CalcularDVV(decimal[] cadena)
        {
            return CheckDigitManager.Current.CalculateDVV(cadena.ToList());
        }


        /// <summary>
        /// Verifica la integridad de los datos. Retorna True si no hay errores, False si hubo errores.
        /// </summary>
        /// <returns></returns>
        public bool CheckIntegrity()
        {
            return CheckDigitManager.Current.CheckIntegrity();
        }

        /// <summary>
        /// Metodo que permite actualizar el DVV de una entidad.
        /// </summary>
        public void UpdateDVV(int id)
        {
            CheckDigitManager.Current.UpdateDVV(id);
        }

        /// <summary>
        /// Actualizar el valor DVH de un objeto Persona en la base de datos.
        /// </summary>
        /// <param name="p"></param>
        public void UpdateDVH(Persona p)
        {
            CheckDigitManager.Current.UpdateDVH(p);
        }



    }
}
