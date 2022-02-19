using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebExam.Models
{
    public class Product
    {
        internal int ProductId;

        public int ProductID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Product Name.")]
        public String ProductName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Rate.")]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Product's Description.")]
        public String Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Entee Product's Category Name.")]
        public String CategoryName { get; set; }
    }
}