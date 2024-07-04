namespace StudentAPI.Models
{
    public enum Year
    {
        firstYear = 1,
        secondYear = 2,
        thirdYear = 3
    }

    public class Student
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int avgMarks { get; set; }
        public bool active { get; set; }
        public DateTime departureDate { get; set; }
        public int korsId { get; set; }
        public Year year { get; set; }
        public AbsenceDays[] absenceDays { get; set; }
        public int sumOfAbsence { get; set; }
    }
}
