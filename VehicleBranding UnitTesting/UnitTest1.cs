using BusinessLL.BusinessLogic;
using System.Text.Json.Nodes;

namespace VehicleBranding_UnitTesting
{
    public class UnitTest1
    {
        
        private VehicleService _testingUnit = null;
        public UnitTest1()
        {
            if(_testingUnit==null)
            {
                _testingUnit = new VehicleService();
            }
        }
        [Fact]
        public void GetVehicleDetails()
        {
            var expected = new JsonArray();
            

        }
    }
}