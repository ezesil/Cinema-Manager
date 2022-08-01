using BaseServices.BLL;
using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BaseServices.Services
{
    /// <summary>
    /// Provee servicios de tipo Digito Verificador Horizontal y Vertical.
    /// </summary>
    public class IntegrityService
    {
        public IntegrityService()
        {

        }

        /// <summary>
        /// Calcula el digito verficador horizontal para la cadena de string especificada.
        /// </summary>
        /// <param name="cadena"></param>
        public decimal CalcularDVH(string cadena)
        {
            return CheckDigitBLL.Current.CalculateDVH(cadena);
        }

        public decimal CalcularDVH(object obj)
        {         
            return CheckDigitBLL.Current.CalcularDVH(obj);
        }

        /// <summary>
        /// Obtiene el digito verficiador vertical para la cadena de DVH especificada.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public decimal CalcularDVV(decimal[] cadena)
        {
            return CheckDigitBLL.Current.CalculateDVV(cadena.ToList());
        }

        /// <summary>
        /// Verifica la integridad de los datos. Retorna True si no hay errores, False si hubo errores.
        /// </summary>
        /// <returns></returns>
        public bool CheckIntegrity()
        {
            return CheckDigitBLL.Current.CheckIntegrity();
        }

        /// <summary>
        /// Metodo que permite actualizar el DVV de una entidad.
        /// </summary>
        public void UpdateDVV(int id)
        {
            CheckDigitBLL.Current.UpdateDVV(id);
        }

        /// <summary>
        /// Actualizar el valor DVH de un objeto Persona en la base de datos.
        /// </summary>
        /// <param name="id"></param>
        public void UpdateDVH(Guid id)
        {
            CheckDigitBLL.Current.UpdateDVH(id);
        }
    }
}
