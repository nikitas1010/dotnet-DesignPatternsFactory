using System;

namespace DPs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            UsernameTest();
            // Dialog Client factory Method
            new DialogClient().Main();
        }



        public static void UsernameTest() {
            //Create a username simple factory that creates username. 
            UsernameSimpleFactory usernameSimpleFactory = new UsernameSimpleFactory();
            //Dependancy Inversion, so we can make changes to Simple factory and inject it from this part of the program
            UserNameManager userNameManager = new UserNameManager(usernameSimpleFactory);

            userNameManager.ManageUsername("Sinhal, Nikita");
            userNameManager.ManageUsername("Nikita Sinhal");
        }
    }

}
