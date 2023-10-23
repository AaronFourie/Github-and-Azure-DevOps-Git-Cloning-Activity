using System.ComponentModel.DataAnnotations;

namespace ICE_TASK_3.Model
{
    public class Farm
    {
        [Key] // Primary Key
        public int FarmID { get; set; }
        public string FarmName { get; set; }
        public string FarmAddress { get; set; }

        // Navigation property for the 1-to-many relationship with Cow
        public List<Cow> Cows { get; set; }
    }
}
