using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Presentation_View
{
    public partial class Spartan_Report_Presentation_ViewMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>
    {
        public Spartan_Report_Presentation_ViewMap()
        {
            this.ToTable("Spartan_Report_Presentation_View");
            this.HasKey(a => a.PresentationViewId);
            this.Ignore(a => a.Id);
        }
    }
}
