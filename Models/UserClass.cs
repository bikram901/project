namespace Crud_Operation.Models
{
	public class UserClass
	{
		public string name { get; set; }
		public String mob { get; set; }
		public string email { get; set; }
		public string dob { get; set; }
		public string username { get; set; }
		public string password { get; set; }

		public string userrole { get; set; }

	}

	public class UserLogin
	{
        public string name { get; set; }
        public String mob { get; set; }
        public string email { get; set; }
        public string dob { get; set; }
        public string username { get; set; }
		public string password { get; set; }
		public string userrole { get; set; }
		public int Status {  get; set; }

	}
}
