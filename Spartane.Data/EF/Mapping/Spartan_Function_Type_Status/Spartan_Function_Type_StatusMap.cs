using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Function_Type_Status
{
    public partial class Spartan_Function_Type_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status>
    {
        public Spartan_Function_Type_StatusMap()
        {
            this.ToTable("Spartan_Function_Type_Status");
            this.HasKey(a => a.Function_Type_Status_Id);
            this.Ignore(a => a.Id);
        }
    }
}
