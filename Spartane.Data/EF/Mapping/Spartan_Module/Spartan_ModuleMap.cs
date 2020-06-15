using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Module
{
    public partial class Spartan_ModuleMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Module.Spartan_Module>
    {
        public Spartan_ModuleMap()
        {
            this.ToTable("Spartan_Module");
            this.HasKey(a => a.Module_Id);
            this.Ignore(a => a.Id);
        }
    }
}
