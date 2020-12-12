using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Shared
{
    public class Uploads
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Card_Code { get; set; }
        public string Document_Type { get; set; }
        public string Document { get; set; }
        public string Remarks { get; set; }
    }
}
