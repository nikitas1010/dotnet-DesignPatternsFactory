using System;
namespace DPs
{
    /*
        UserNameManager can perform various tasks ralted to username. It may rely on factory to create the object,
        write it to console or do other tasks like write to db.

        This is the client code, which calls the Simple Factory. This is the higher level code,
        which should not depend on the lower level objects like factory and username, so we inject them as dependancy
    */
    class UserNameManager
    {

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
        public void DoOtherUsernameTasks()
        {
            Console.WriteLine("Adding Username to DB");
        }
    }

    //Simple Factory which only handles different types of inputs, to create the Username Object.
    //Encapsulate username creation and all its complexities. If we need to handle new kind of input, just change this class
    class UsernameSimpleFactory
    {
        public UserName GetUserNameObject(String name)
        {
            //name = name.Trim();

            if (name.Contains(","))
            {
                return new LastNameFirst(name);
            }
            else
            {
                return new FirstNameFirst(name);
            }

            //can extend to handle special characters, 'Mr/Miss/Dr' etc...
        }

    }

    public class UserName
    {
        public string First { get; set; }
        public string Last { get; set; }

        public override string ToString()
        {
            return $"{First} {Last}";
        }
    }

    public class FirstNameFirst : UserName
    {
        public FirstNameFirst(string name)
        {
            if (name.Length <= 0) return;
            First = name.Split(' ')[0].Trim();
            Last = name.Split(' ')[1].Trim();
        }
    }

    public class LastNameFirst : UserName
    {
        public LastNameFirst(string name)
        {
            if (name.Length <= 0) return;
            Last = name.Split(',')[0].Trim();
            First = name.Split(',')[1].Trim();

        }
    }

}
