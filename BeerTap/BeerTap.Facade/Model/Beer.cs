namespace BeerTap.Facade.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Beer")]
    public partial class Beer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal mL { get; set; }
        public decimal Container { get; set; }
        public int OfficeId { get; set; }
    }
}
