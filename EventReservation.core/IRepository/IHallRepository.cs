using EventReservation.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventReservation.core.IRepository
{
    public interface IHallRepository
    {
        Task<List<Hall>> GetAllHalls();
        Task<Hall> GetHallById(int id);
        Task CreateHall(Hall hall);
        Task UpdateHall(Hall hall);
        Task DeleteHall(int id);
    }
}
