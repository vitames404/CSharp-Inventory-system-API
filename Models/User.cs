using System;
using Dapper.Contrib.Extensions;

namespace InventoryAPI.Models
{
    public class User
    { 
      public int userid { get; set; }
      public string Name { get; set; }
      public string Login { get; set; }
      public string Email { get; set; }
      public DateTime BirthDate { get; set; }
      public string Password { get; set; }
    }
}