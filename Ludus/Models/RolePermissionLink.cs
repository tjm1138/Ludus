namespace Ludus.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;    
    [Table("RolePermissionLink")]
    public class RolePermissionLink
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> webpages_RolesId { get; set; }
        public Nullable<int> PermissionId { get; set; }
    
        public virtual Permission Permission { get; set; }
    }
}
