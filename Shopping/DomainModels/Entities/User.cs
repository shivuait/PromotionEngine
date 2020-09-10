using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
