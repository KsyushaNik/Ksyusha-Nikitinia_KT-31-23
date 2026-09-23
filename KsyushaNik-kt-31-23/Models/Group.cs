namespace KsyushaNik_kt_31_23.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public int Course { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int? SpecialtyId { get; set; }
        public Specialty? Specialty { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}