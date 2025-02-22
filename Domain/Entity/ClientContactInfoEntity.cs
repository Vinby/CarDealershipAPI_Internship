﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Entity
{
    public class ClientContactInfoEntity : BaseEntity
    {
        public int ClientContactInfoEntityId { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}$")]
        public string PhoneNumber { get; set; }
        [RegularExpression(@"^.+@.+(\.).+$")]
        public string Email { get; set; }
        [MaxLength(1024)]
        public string Address { get; set; }

        public ClientEntity ClientEntity { get; set; }
        public int ClientEntityId { get; set; }
    }
}
