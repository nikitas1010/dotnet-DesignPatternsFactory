using System;

namespace DPs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            UserNameFactoryTest.TestUserNameFactory();
        }
    }

    //This is the client code, which calls the Simple Factory
    class UserNameFactoryTest {



        public static void TestUserNameFactory()
        {

            /*
             1. Username may be passed in as Nikita Sinhal, or Sinhal, Nikita, or with leading/trailing spaces
             2. Factory Method will determine order and return username object with first and last name
             3. We can write username object to Console, as it will have ToString method implemented
             */
            var username = new Username("Nikita", "Sinhal");
            Console.WriteLine(username);

            UsernameSimpleFactory usernameSimpleFactory = new UsernameSimpleFactory();

            var username2 = usernameSimpleFactory.GetUserNameObject("Sinhal, Nikita");
            Console.WriteLine(username2);
            var username3 = usernameSimpleFactory.GetUserNameObject(" Nikita Sinhal ");
            Console.WriteLine(username3);
        }
    }

    //Simple Factory which only handles different types of inputs, to create the Username Object.
    //Encapsulate username creation and all its complexities. If we need to handle new kind of input, just change this class
    class UsernameSimpleFactory {

        public Username GetUserNameObject(String name) {
            name  = name.Trim();

            if (name.Contains(","))
            {
                String last = name.Split(',')[0].Trim();
                String first = name.Split(',')[1].Trim();
                return new Username(first, last);
            }
            else {
                String first = name.Split(' ')[0].Trim();
                String last = name.Split(' ')[1].Trim();
                return new Username(first, last);
            }
            //can extend to handle special characters, 'Mr/Miss/Dr' etc...
        }

    }

    class Username {
        public String First { get; set; }
        public String Last { get; set; }

        public Username(String first, String last)
        {
            First = first;
            Last = last;
        }
        public override string ToString()
        {
            return $"{First} {Last}";
        }
    }


}
