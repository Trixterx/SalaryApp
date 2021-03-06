namespace SalaryApp
{
    public abstract class Account
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }
        public bool IsAdmin { get; set; }
    }
}