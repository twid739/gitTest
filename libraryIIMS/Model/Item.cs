using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libraryIIMS.Model
{
    [Table("item")]
    public partial class Item
    {
        [Column("itemID")]
        public int ItemId { get; set; }
        [Column("title")]
        [StringLength(60)]
        public string Title { get; set; }
        [Column("authorFirstName")]
        [StringLength(50)]
        public string AuthorFirstName { get; set; }
        [Column("authorLastName")]
        [StringLength(50)]
        public string AuthorLastName { get; set; }
        [Column("publisher")]
        [StringLength(50)]
        public string Publisher { get; set; }
        [Column("itemType")]
        [StringLength(50)]
        public string ItemType { get; set; }
        [Column("datePublished", TypeName = "date")]
        public DateTime? DatePublished { get; set; }
        [Column("startRentDate", TypeName = "date")]
        public DateTime? StartRentDate { get; set; }
        [Column("endRentDate", TypeName = "date")]
        public DateTime? EndRentDate { get; set; }
    }
}
