using System.Data.Entity.Migrations;

namespace SimpleTaskSystem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimpleTaskSystem";
        }

        protected override void Seed(SimpleTaskSystem.EntityFramework.SimpleTaskSystemDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
            context.Users.AddOrUpdate(p => p.UserId, 
                new SMPSUser { UserId = 518462, FirstName = "Satyendra", LastName = "Kandregula", Address="HYD-JVP", ParkingSlotNumber = "HYD-JVP-01" },
                new SMPSUser { UserId = 518491, FirstName = "Pavan", LastName = "Gautaraju", Address = "HYD-JVP", ParkingSlotNumber = "HYD-JVP-02" },
                new SMPSUser { UserId = 519187, FirstName = "Simhadri", LastName = "Saripalli", Address = "HYD-JVP", ParkingSlotNumber = "HYD-JVP-03" },
                new SMPSUser { UserId = 519420, FirstName = "Sai", LastName = "Patha", Address = "HYD-JVP", ParkingSlotNumber = "HYD-JVP-04" },
                new SMPSUser { UserId = 518951, FirstName = "Manasa", LastName = "Karri", Address = "HYD-JVP", ParkingSlotNumber = "HYD-JVP-05" },
                new SMPSUser { UserId = 519325, FirstName = "Prem", LastName = "Yelavarthi", Address = "HYD-JVP", ParkingSlotNumber = null },
                new SMPSUser { UserId = 519310, FirstName = "Venkatesh", LastName = "Pydi", Address = "HYD-JVP", ParkingSlotNumber = null },
                new SMPSUser { UserId = 518935, FirstName = "Srinivasa", LastName = "Injam", Address = "HYD-JVP", ParkingSlotNumber = null },
                new SMPSUser { UserId = 519280, FirstName = "Sujitha", LastName = "Vemulapally", Address = "HYD-JVP", ParkingSlotNumber = null }
                );
        }
    }
}
