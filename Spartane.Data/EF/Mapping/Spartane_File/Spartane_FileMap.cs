using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartane_File
{
    public partial class Spartane_FileMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartane_File.Spartane_File>
    {
        public Spartane_FileMap()
        {
            this.ToTable("Spartan_File");
            this.HasKey(a => a.File_Id);
            this.Ignore(a => a.Id);
        }
    }
}
