using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _createAt;
        public DateTime?  CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.Now : value) ;}
        }
        public DateTime? UpdateAt { get; set; }

    }
}