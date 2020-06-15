using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Object_Method
{
    public partial class Spartan_Object_MethodMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Object_Method.Spartan_Object_Method>
    {
        public Spartan_Object_MethodMap()
        {
            this.ToTable("Spartan_Object_Method");
            this.HasKey(a => a.Object_Method_Id);
            this.Ignore(a => a.Id);
        }
    }
}
