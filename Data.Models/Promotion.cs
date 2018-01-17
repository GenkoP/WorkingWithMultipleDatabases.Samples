using System;

namespace Data.Models
{
    public class Promotion : IEntityKey<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }
    }
}
