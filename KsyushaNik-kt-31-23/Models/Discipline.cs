using System.Diagnostics;

namespace KsyushaNik_kt_31_23.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        // Навигационное свойство
        public List<Grade> Grades { get; set; } = new();
    }
}