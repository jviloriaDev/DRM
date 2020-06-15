using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Rule_Object_Function
{
    public partial class Spartan_User_Rule_Object_FunctionMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Rule_Object_Function.Spartan_User_Rule_Object_Function>
    {
        public Spartan_User_Rule_Object_FunctionMap()
        {
            this.ToTable("Spartan_User_Rule_Object_Function");
            this.HasKey(a => a.User_Rule_Object_Function_Id);
            this.Ignore(a => a.Id);
        }
    }
}
