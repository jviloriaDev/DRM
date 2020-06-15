using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Function
{
    public partial class Spartan_Report_FunctionMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Function.Spartan_Report_Function>
    {
        public Spartan_Report_FunctionMap()
        {
            this.ToTable("Spartan_Report_Function");
            this.HasKey(a => a.FunctionId);
            this.Ignore(a => a.Id);
        }
    }
}
