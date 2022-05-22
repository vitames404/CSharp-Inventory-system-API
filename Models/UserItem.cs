using System;

namespace InventoryAPI.Models{
    public class UserItem{
        public int IdInv { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
    }
}