namespace Aspform.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender gender { get; set; }
    }
    public enum Gender
    {
        Male, Female

    }
}