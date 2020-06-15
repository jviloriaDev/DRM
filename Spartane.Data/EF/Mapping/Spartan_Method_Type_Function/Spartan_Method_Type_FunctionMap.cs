using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Method_Type_Function
{
    public partial class Spartan_Method_Type_FunctionMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Method_Type_Function.Spartan_Method_Type_Function>
    {
        public Spartan_Method_Type_FunctionMap()
        {
            this.ToTable("Spartan_Method_Type_Function");
            this.HasKey(a => a.Method_Type_Function_Id);
            this.Ignore(a => a.Id);
        }
    }
}
