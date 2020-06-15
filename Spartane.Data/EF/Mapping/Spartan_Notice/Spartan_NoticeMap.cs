using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Notice
{
    public partial class Spartan_NoticeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Notice.Spartan_Notice>
    {
        public Spartan_NoticeMap()
        {
            this.ToTable("Spartan_Notice");
            this.HasKey(a => a.Notice_Id);
            this.Ignore(a => a.Id);
        }
    }
}
