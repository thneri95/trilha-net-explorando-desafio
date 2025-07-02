namespace DesafioProjetoHospedagem.Models
{
    public class Person
    {
        public Person() { }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string FullName => $"{Name} {Surname}".Trim().ToUpper();
    }
}
