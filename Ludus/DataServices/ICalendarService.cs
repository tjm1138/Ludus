using System;
namespace Ludus.DataServices
{
    interface ICalendarService
    {
        Ludus.Models.Calendar Find(int userId);
        Ludus.Models.Calendar Find(int userId, DateTime month);
    }
}
