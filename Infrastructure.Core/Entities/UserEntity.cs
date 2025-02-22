using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Entities
{
    [Table("UserLogin", Schema = "dbo")]
    public class UserEntity
    {
        [Key]
        [Column("UserId", TypeName = "int")]
        public int UserId { get; set; }

        [Column("ID", TypeName = "varchar(500)")]
        public string ID { get; set; }

        [Column("Name", TypeName = "varchar(500)")]
        public string Name { get; set; }

        [Column("Email", TypeName = "varchar(500)")]
        public string Email { get; set; }

        [Column("Password", TypeName = "varchar(500)")]
        public string Password { get; set; }
    }
}
