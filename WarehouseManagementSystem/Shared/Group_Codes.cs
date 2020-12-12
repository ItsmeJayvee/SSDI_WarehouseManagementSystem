using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Shared
{
    public class Group_Codes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string GroupType { get; set; }
        public string Locked { get; set; }
        public string DataSource { get; set; }
        public string UserSign { get; set; }
        public string PriceList { get; set; }
        public string DiscRel { get; set; }
    }
}
