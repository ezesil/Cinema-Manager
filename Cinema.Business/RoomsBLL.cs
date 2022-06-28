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


        public List<Room> GetAllRooms()
        {
            return _repo.GetAll().ToList();
        }

        public Room GetRoom(Guid id)
        {
            return _repo.GetOne(id);
        }

        public void CreateRoom(Room room)
        {
            _repo.Insert(room);
        }

        public void UpdateRoom(Room room)
        {
            _repo.Update(room);
        }

        public void DeleteRoom(Guid? roomid)
        {
            _repo.Delete(roomid);
        }

    }
}
