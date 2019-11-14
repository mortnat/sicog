//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureReportingPeriod]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportingPeriodConfiguration : EntityTypeConfiguration<PerformanceMeasureReportingPeriod>
    {
        public PerformanceMeasureReportingPeriodConfiguration() : this("dbo"){}

        public PerformanceMeasureReportingPeriodConfiguration(string schema)
        {
            ToTable("PerformanceMeasureReportingPeriod", schema);
            HasKey(x => x.PerformanceMeasureReportingPeriodID);
            Property(x => x.PerformanceMeasureReportingPeriodID).HasColumnName(@"PerformanceMeasureReportingPeriodID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureReportingPeriodCalendarYear).HasColumnName(@"PerformanceMeasureReportingPeriodCalendarYear").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureReportingPeriodLabel).HasColumnName(@"PerformanceMeasureReportingPeriodLabel").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.TargetValue).HasColumnName(@"TargetValue").HasColumnType("float").IsOptional();
            Property(x => x.TargetValueLabel).HasColumnName(@"TargetValueLabel").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.PerformanceMeasureReportingPeriods).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID
        }
    }
}