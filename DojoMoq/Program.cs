using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojoMoq
{
	class Program
	{
		static void Main(string[] args)
		{
			var service = new UserService();

			var usersToAdd = new List<string>
			{
				"Ringo", "Raoul", "Pedro", "Mojito", "Paolo", "Bernardo"
			};

			var i = 0;
			usersToAdd.ForEach((userName) =>
			{
				service.Add(new User
				{
					Name = userName,
					DatavivAccessAllowed = (i % 2 == 0)
				});
				i++;
			});

			var userFound = service.FindById(4);
			if (userFound != null)
				Console.WriteLine(userFound);

			var users = service.FindDatavivAccessAllowed();
			foreach (var x in users)
			{
				Console.WriteLine(x);
			}

			Console.WriteLine("Finish");
			Console.ReadKey();
		}
	}
}
