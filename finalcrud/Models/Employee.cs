using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalcrud.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        [Column("date")]
        public DateTime? Joindate { get; set; }
        public decimal Salary { get; set; }
        public string Photo { get; set; }
        public int DeptID { get; set; }
        public  Department Department { get; set; }
    }
}