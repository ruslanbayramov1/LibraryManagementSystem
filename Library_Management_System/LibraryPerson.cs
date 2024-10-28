namespace Library_Management_System
{
    abstract class Person
    {
        private static int _id;
        public int Id { get; set; }
        public string Name { get; set; }

        protected Person(string name)
        {
            Name = name;
            Id = ++_id;
        }
    }

    class Librarian : Person
    {
        public DateTime HireDate { get; private set; }
        public Librarian(string name, DateTime hireDate) : base(name)
        {
            HireDate = hireDate;
        }

        public override string ToString()
        {
            return $"{this.GetType().ToString().Split('.')[^1]} {{ Id: {Id}, Name: {Name}, Hire date: {HireDate} }}";
        }
    }

    sealed class LibraryMember : Person
    {
        public DateTime MembershipDate { get; private set; }
        public LibraryMember(string name, DateTime membershipDate) : base(name)
        {
            MembershipDate = membershipDate;
        }

        public override string ToString()
        {
            return $"{this.GetType().ToString().Split('.')[^1]} {{ Id: {Id}, Name: {Name}, Membership date: {MembershipDate} }}";
        }
    }
}