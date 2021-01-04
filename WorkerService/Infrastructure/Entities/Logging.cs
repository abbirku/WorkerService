using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class Logging : IEntity<int>
    {
        public int Id { get; set; }
        public string LogMessage { get; set; }
        public DateTime LogTime { get; set; }
    }
}
