using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Shared
{
    public class Payment_Terms
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string GroupNum { get; set; }
        public string PymntGroup { get; set; }
        public string PayDuMonth { get; set; }
        public string ExtraMonth { get; set; }
        public string ExtraDays { get; set; }
        public decimal PaymntsNum { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal CredLimit { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal VolumDscnt { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LatePyChrg { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal ObligLimit { get; set; }
        public string ListNum { get; set; }
        public string Payments { get; set; }
        public string NumOfPmnts { get; set; }
        public string Payment1 { get; set; }
        public string DataSource { get; set; }
        public string UserSign { get; set; }
        public string OpenRcpt { get; set; }
        public string DiscCode { get; set; }
        public string DunningCod { get; set; }
        public string BslineDate { get; set; }
        public string InstNum { get; set; }
        public string TolDays { get; set; }
        public string VATFirst { get; set; }
        public string CrdMthd { get; set; }
        public string CshRelev { get; set; }
    }
}
