using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Rule_Module
{
    public partial class Spartan_User_Rule_ModuleMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Rule_Module.Spartan_User_Rule_Module>
    {
        public Spartan_User_Rule_ModuleMap()
        {
            this.ToTable("Spartan_User_Rule_Module");
            this.HasKey(a => a.User_Rule_Module_Id);
            this.Ignore(a => a.Id);
        }
    }
}
