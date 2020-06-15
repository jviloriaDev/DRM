using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Object_Method_Config
{
    public partial class Spartan_User_Object_Method_ConfigMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Object_Method_Config.Spartan_User_Object_Method_Config>
    {
        public Spartan_User_Object_Method_ConfigMap()
        {
            this.ToTable("Spartan_User_Object_Method_Config");
            this.HasKey(a => a.User_Object_Method_Config_Id);
            this.Ignore(a => a.Id);
        }
    }
}
