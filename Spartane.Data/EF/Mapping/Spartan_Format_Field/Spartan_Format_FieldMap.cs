using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Format_Field
{
    public partial class Spartan_Format_FieldMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field>
    {
        public Spartan_Format_FieldMap()
        {
            this.ToTable("Spartan_Format_Field");
            this.HasKey(a => a.FormatFieldId);
            this.Ignore(a => a.Id);
        }
    }
}
