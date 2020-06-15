using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Object_Path
{
    public partial class Spartan_Object_PathMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Object_Path.Spartan_Object_Path>
    {
        public Spartan_Object_PathMap()
        {
            this.ToTable("Spartan_Object_Path");
            this.HasKey(a => a.Object_Path_Id);
            this.Ignore(a => a.Id);
        }
    }
}
