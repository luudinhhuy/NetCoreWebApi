using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace coreApi.Domain.Models
{
    public class Member
    {

        [Key]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MiddleName { get; set; }
    }
}
