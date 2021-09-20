using System;

namespace DPs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var username = new Username("Nikita", "Sinhal");
            Console.WriteLine(username);
            //Create a username simple factory that creates username. 
            UsernameSimpleFactory usernameSimpleFactory = new UsernameSimpleFactory();
            //Dependancy Inversion, so we can make changes to Simple factory and inject it from this part of the program
            UserNameManager userNameManager = new UserNameManager(usernameSimpleFactory);

            userNameManager.ManageUsername("Sinhal, Nikita");
            userNameManager.ManageUsername(" Nikita Sinhal ");


        }
    }
/*
    UserNameManager can perform various tasks ralted to username. It may rely on factory to create the object,
    write it to console or do other tasks like write to db.

    This is the client code, which calls the Simple Factory. This is the higher level code,
    which should not depend on the lower level objects like factory and username, so we inject them as dependancy
*/
    class UserNameManager {

        UsernameSimpleFactory usernameSimpleFactory = null;

        public UserNameManager(UsernameSimpleFactory usernameSimpleFactory)
        {
            this.usernameSimpleFactory = usernameSimpleFactory;
        }

        public void ManageUsername(String name)
        {

            /*
             1. Username may be passed in as Nikita Sinhal, or Sinhal, Nikita, or with leading/trailing spaces
             2. Factory Method will determine order and return username object with first and last name
             3. We can write username object to Console, as it will have ToString method implemented
             */

            var username = this.usernameSimpleFactory.GetUserNameObject(name);
            Console.WriteLine(username);           
            
        }
        public void DoOtherUsernameTasks() {
            Console.WriteLine("Adding Username to DB");
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
