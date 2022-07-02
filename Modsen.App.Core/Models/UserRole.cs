using System;
using System.Collections.Generic;

namespace Modsen.App.Core.Models
{
	public class UserRole : Abstractions.BaseEntity
	{
		public virtual ICollection<User> Users { get; set; }

		public UserRole()
		{
			Users = new List<User>();
		}
	}
}
