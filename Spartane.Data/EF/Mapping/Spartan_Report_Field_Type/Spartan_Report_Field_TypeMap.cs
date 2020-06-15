using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Field_Type
{
    public partial class Spartan_Report_Field_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Field_Type.Spartan_Report_Field_Type>
    {
        public Spartan_Report_Field_TypeMap()
        {
            this.ToTable("Spartan_Report_Field_Type");
            this.HasKey(a => a.FieldTypeId);
            this.Ignore(a => a.Id);
        }
    }
}
