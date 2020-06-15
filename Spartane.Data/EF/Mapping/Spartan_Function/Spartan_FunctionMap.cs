using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Function
{
    public partial class Spartan_FunctionMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Function.Spartan_Function>
    {
        public Spartan_FunctionMap()
        {
            this.ToTable("Spartan_Function");
            this.HasKey(a => a.Function_Id);
            this.Ignore(a => a.Id);
        }
    }
}
