using System;
namespace ExtAppraisalApp.Models
{
    public class ProspectParams

    {

        public int YearId { get; set; }

        public int makeId { get; set; }

        public int modelId { get; set; }

        public int trimId { get; set; }

        public int transmissionId { get; set; }

        public int engineId { get; set; }

        public int drivetrainId { get; set; }

        public int colorId { get; set; }

        public string vin { get; set; }

        public int mileage { get; set; }

        public int dealerId { get; set; }

        public short currStoreId { get; set; }



    }
}
