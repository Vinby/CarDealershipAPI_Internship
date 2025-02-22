﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entity
{
    public class ClientEntity : BaseEntity
    {
        public int ClientEntityId { get; set; }



        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Surname { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid IDNumber")]
        public string IDNumber { get; set; }


        [Range(typeof(DateTime), "1 /1/1870", "1/1/2022" ,ErrorMessage = "Unsupported Date of birth")]
        public DateTime DateOfBirth { get; set; }


        public ClientContactInfoEntity ClientContactInfoEntity { get; set; }

        public ICollection<CarEntity> Cars { get; set; } = new List<CarEntity>();

    }
}
