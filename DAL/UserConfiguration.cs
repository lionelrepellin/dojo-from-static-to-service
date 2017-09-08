using Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL
{
	public class UserConfiguration : EntityTypeConfiguration<User>
	{
		public UserConfiguration()
		{
			ToTable("utilisateurs");

			HasKey(t => t.Id);

			Property(t => t.Id).HasColumnName("id");
			Property(t => t.Name).HasColumnName("nom");
			Property(t => t.DatavivAccessAllowed).HasColumnName("acces_dataviv");
		}
	}
}