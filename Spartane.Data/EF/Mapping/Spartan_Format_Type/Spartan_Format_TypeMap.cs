using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Format_Type
{
    public partial class Spartan_Format_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Format_Type.Spartan_Format_Type>
    {
        public Spartan_Format_TypeMap()
        {
            this.ToTable("Spartan_Format_Type");
            this.HasKey(a => a.FormatTypeId);
            this.Ignore(a => a.Id);
        }
    }
}
