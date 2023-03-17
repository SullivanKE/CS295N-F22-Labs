using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KatieSite.Models
{
	public class RpgBook
	{
		[Key]

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Description is required")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Date is required")]
		public DateTime Published { get; set; }
		public Publisher PublishedBy { get; set; }
	}
}
