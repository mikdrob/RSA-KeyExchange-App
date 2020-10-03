using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MenuSystem;

namespace Console_application
{
    class Program
    {

        static void Main(string[] args)
        {
            Encryption();
        }
        
        
        
        
        

        static void Encryption()
        {
            
            Console.Clear();
            var caesar = new Menu(1)
            {
                Title = "Choose action",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Encrypt",
                            Encrypt = true,
                            CommandToExecute = null
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Decrypt",
                            Encrypt = false,
                            CommandToExecute = null
                        }
                    },
                }
            };


            var menu0 = new Menu(0)
            { 
                Title = "Pick cipher",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Caesar",
                            Reverse = true,
                            CommandToExecute = caesar.Run
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Vigenere",
                            Reverse = false,
                            CommandToExecute = null
                        }
                    },

                }
            };

            menu0.Run();
        }

    }
}
