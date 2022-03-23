using System;
namespace PS3.Models
{
	public class Users
	{
		public List<UserDataHolder> uzytkownicy { get; set; }
		public Users()
		{
			uzytkownicy = new List<UserDataHolder>();
		}

	}
}

