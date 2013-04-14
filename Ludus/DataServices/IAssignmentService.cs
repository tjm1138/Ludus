using System;
namespace Ludus.DataServices
{
    interface IAssignmentService
    {
        void Create(Ludus.Models.Assignment assignment);
        System.Collections.Generic.ICollection<Ludus.Models.Assignment> DisplayAssignments();
        Ludus.Models.Assignment Find(int id);
        System.Collections.Generic.ICollection<Ludus.Models.Assignment> Get(int userId);
        void Remove(int id);
        void Update(Ludus.Models.Assignment assignment);
    }
}
