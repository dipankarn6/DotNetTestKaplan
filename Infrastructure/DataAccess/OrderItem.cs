namespace DotNetDeveloperTest.IS.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short LineNumber { get; set; }

        public int ProductID { get; set; }

        public short Quantity { get; set; }

        public int StudentPersonID { get; set; }

        public virtual Person StudentPerson { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
