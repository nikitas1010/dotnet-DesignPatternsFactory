using System;

namespace DPs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //UsernameTest();
            // Dialog Client factory Method
            //new DialogClient().Main();

            //Command pattern test
            //CommandGenericTest();

            RemoteControlTest();

        }

        public static void RemoteControlTest() {
            //Invoker
            SimpleRemoteControl remote = new SimpleRemoteControl();
            //receiver
            Light light = new Light();
            //command
            ILightCommand lightOn = new LightOnCommand(light);
            remote.SetLightCommand(lightOn);
            remote.PressButton();

            ILightCommand lightOff = new LightOffCommand(light);
            remote.SetLightCommand(lightOff);
            remote.PressButton();


        }
    

        public static void CommandGenericTest() {
            // The client code can parameterize an invoker with any commands.
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.DoSomethingImportant();
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
