using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models {
    public class MusicGenre {

        [Key]
        public int MusicGenreID { get; set; }
        public string Name { get; set; }

    }
}
