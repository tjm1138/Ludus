using System;
namespace Ludus.DataServices
{
    interface IPersonalItemService
    {
        void Create(Ludus.Models.PersonalItem item);
        Ludus.Models.PersonalItem Find(int id);
        System.Collections.Generic.ICollection<Ludus.Models.PersonalItem> Get(int userId);
        void Remove(int id);
        void Update(Ludus.Models.PersonalItem item);
    }
}
