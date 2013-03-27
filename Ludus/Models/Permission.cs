namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Permission")]
    public class Permission
    {
        public Permission()
        {
            this.RolePermissionLinks = new HashSet<RolePermissionLink>();
        }

        [Key]
        public int Id { get; set; }
        public string PermissionName { get; set; }
    
        public virtual ICollection<RolePermissionLink> RolePermissionLinks { get; set; }
    }
}
