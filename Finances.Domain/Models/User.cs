using Finances.Domain.DTOs;
using Finances.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Finances.Domain.Entities.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Income Income { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
