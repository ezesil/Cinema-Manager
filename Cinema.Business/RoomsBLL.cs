using Cinema.DAL.Factory;
using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business
{
    /// <summary>
    /// Clase singleton para logica de salas.
    /// </summary>
    public class RoomsBLL
    {
        private readonly IGenericRepository<Room> _repo = FactoryDAL.RoomRepository;

        #region Singleton
        private static RoomsBLL _instance = new RoomsBLL();

        /// <summary>
        /// Instancia actual de la clase.
        /// </summary>
        public static RoomsBLL Current
        {
            get
            {
                if (_instance == null)
                    _instance = new RoomsBLL();

                return _instance;
            }
        }

        private RoomsBLL()
        {

        }
        #endregion

        /// <summary>
        /// Obtiene todas las salas.
        /// </summary>
        /// <returns></returns>
        public List<Room> GetAllRooms()
        {
            return _repo.GetAll().ToList();
        }

        /// <summary>
        /// Obtiene una sala.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Room GetRoom(Guid? id)
        {
            return _repo.GetOne(id);
        }

        /// <summary>
        /// Crea una sala.
        /// </summary>
        /// <param name="room"></param>
        public void CreateRoom(Room room)
        {
            _repo.Insert(room);
        }

        /// <summary>
        /// Actualiza una sala.
        /// </summary>
        /// <param name="room"></param>
        public void UpdateRoom(Room room)
        {
            _repo.Update(room);
        }

        /// <summary>
        /// Borra una sala.
        /// </summary>
        /// <param name="roomid"></param>
        public void DeleteRoom(Guid? roomid)
        {
            _repo.Delete(roomid);
        }

    }
}
