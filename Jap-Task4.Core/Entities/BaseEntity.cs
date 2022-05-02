using System;
using System.ComponentModel.DataAnnotations;

namespace Jap_Task4.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
}