using Core;
using System;

namespace Infrastructure.Entities
{
    public class Logging : IEntity<int>
    {
        public int Id { get; set; }
        public string LogMessage { get; set; }
        public DateTime LogTime { get; set; }
        public bool IsActive { get; set; }
    }
}
