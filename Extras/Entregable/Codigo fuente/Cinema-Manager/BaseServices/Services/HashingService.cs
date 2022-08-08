using BaseServices.BLL;

namespace BaseServices.Services
{
    /// <summary>
    /// Provee servicios de hashing y comparacion de contraseñas.
    /// </summary>
    public class HashingService
    {

        private readonly static HashingService _instance = new HashingService();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static HashingService Current
        {
            get
            {
                return _instance;
            }
        }

        private HashingService()
        {

        }

        /// <summary>
        /// Obtiene el valor hash de la contraseña.
        /// </summary>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>Retorna un objeto string que contiene el valor de hash de la contraseña.</returns>
        public string HashPassword(string password)
        {
            return HashingBLL.Current.CreatePasswordHash(password);
        }

        /// <summary>
        /// Indica si la contraseña ingresada y la almacenada son iguales.
        /// </summary>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <param name="storedhash">Hash almacenado de la contraseña.</param>
        /// <returns></returns>
        public bool VerificarContraseña(string password, string storedhash)
        {
            return HashingBLL.VerifyPassword(password, storedhash);
        }










    }
}
