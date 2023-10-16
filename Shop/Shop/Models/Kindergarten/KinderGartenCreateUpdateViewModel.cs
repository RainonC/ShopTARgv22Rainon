namespace Shop.Models.Kindergarten
{
    public class KinderGartenCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public int RoomCount { get; set; }
        public int Floor { get; set; }
        public string BuildingType { get; set; }

        //database
        public DateTime BuiltInYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
