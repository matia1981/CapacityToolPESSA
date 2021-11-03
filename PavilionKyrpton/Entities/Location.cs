﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public string AppLocation { get; set; }

        public string EurorunnerLocation { get; set; }

        public string EnagasLocation { get; set; }

        public string Network { get; set; }

        public string Location_Type { get; set; }

        public string Temperature { get; set; }

        public string Timezone { get; set; }       


    }
}
