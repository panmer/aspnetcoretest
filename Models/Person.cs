namespace gcsharpRPC.Models
{
    public class Person
    {
        private string name;

        public int Id { get; set; }
        public string Name {
            get {
                if (string.IsNullOrEmpty(name))
                    return "";

                return name;
            }
            set {
                name = value;
            }
        }
        public int BirthYear { get; set; }
    }
}