using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Database.Tables;

[Table("TBL_User")]
public class TBLUser
{
	[Key]
	public string Id { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
}
