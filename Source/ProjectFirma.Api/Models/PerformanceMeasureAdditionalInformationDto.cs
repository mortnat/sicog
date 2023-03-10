using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Models
{
    public class PerformanceMeasureAdditionalInformationDto
    {
        public PerformanceMeasureAdditionalInformationDto(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            AdditionalInformation = performanceMeasure.AdditionalInformation;
        }

        public PerformanceMeasureAdditionalInformationDto()
        {
        }

        public int PerformanceMeasureID { get; set; }
        public string AdditionalInformation { get; set; }
    }
}