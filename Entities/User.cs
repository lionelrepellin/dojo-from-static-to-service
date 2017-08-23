using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
		public int Id { get; set; }
		public string Name { get; set; }		
		public bool DatavivAccessAllowed { get; set; }

		public override string ToString()
		{
			var authorized = DatavivAccessAllowed ? string.Empty : "not ";
			return $"My name is {Name} (id:{Id}) - I am {authorized}authorized to use Dataviv";
		}
	}
}
