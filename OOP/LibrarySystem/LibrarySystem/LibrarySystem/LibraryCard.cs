using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    internal class LibraryCard
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }

        public LibraryCard(int id, int ownerId)
        {
            Id = id;
            OwnerId = ownerId;
        }

        public string GetInfo()
        {
            return $"Card ID: {Id}, Owner ID: {OwnerId}";
        }
    }
}
