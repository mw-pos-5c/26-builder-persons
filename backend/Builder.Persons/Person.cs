using System;

namespace Builder.Persons;

public class Person
{
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public int Age { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }

    private Person()
    {
        
    }

    public override string ToString()
    {
        return $"{nameof(Firstname)}: {Firstname}, {nameof(Lastname)}: {Lastname}, {nameof(Age)}: {Age}, {nameof(Phone)}: {Phone}, {nameof(Address)}: {Address}";
    }

    public class Builder
    {
        private string firstname;
        private string lastname;
        private int age;
        private string phone;
        private string address;
        
        public Builder SetCsvData(string str)
        {
            string[] data = str.Split(";");
            if (data.Length < 2)
            {
                throw new ArgumentException("Firstname or Lastname missing!");
            }

            firstname = data[0];
            lastname = data[1];

            if (firstname.Length < 3)
            {
                throw new ArgumentException("Firstname is too short!");
            }
            
            if (data.Length >= 3)
            {
                int.TryParse(data[2], out age);

                if (age > 115)
                {
                    throw new ArgumentException("Person is too old!");
                }
            } 
            
            if (data.Length >= 4)
            {
                phone = data[3];
            } 
            
            if (data.Length >= 5)
            {
                address = data[4];
            }

            return this;

        }

        public Person Build()
        {
            return new Person
            {
                Address = address,
                Age = age,
                Firstname = firstname,
                Lastname = lastname,
                Phone = phone
            };
        }
    }
}
