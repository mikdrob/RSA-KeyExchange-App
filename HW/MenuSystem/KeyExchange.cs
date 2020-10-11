using System;

namespace MenuSystem
{
    public class KeyExchange
    {
        private int pKeyFirst;
        private int pKeySecond;
        private int pSecretFirst;
        private int pSecretSecond;
        

        static int keyValidation()
        {
            var tKey = 0;
            var inputKey = "";
            bool wrongInput = false;
            do
            {
                if (wrongInput)
                    Console.WriteLine("Try again");
                inputKey = Console.ReadLine();
                if (Int32.TryParse(inputKey, out tKey))
                    wrongInput = primesValidation(tKey);
            } while (wrongInput);
            return tKey;
        }

        static bool primesValidation(int inputKey)
        {
            if (inputKey < 2)
                return true;
            for (int i = inputKey/2; i > 1; i--)
            {
                if (inputKey % i == 0)
                    return true;
            }
            return false;
        }
        
        static int keyGenerator(int publicKeyA, int secretPart, int publicKeyB)
        {
            
            int powerOfKeyValue = 1;
            int remainingPart = publicKeyA % publicKeyB;

            for (int i = secretPart - 1; i >= 0; i--)
            {

                if (powerOfKeyValue < publicKeyB && i != secretPart - 1)
                {
                    powerOfKeyValue = powerOfKeyValue * publicKeyA;
                    if (powerOfKeyValue > publicKeyB)
                    {
                        remainingPart = powerOfKeyValue % publicKeyB;
                        powerOfKeyValue = 1;
                    }
                }

                if (remainingPart != 0)
                {
                    powerOfKeyValue = remainingPart * powerOfKeyValue;
                    remainingPart = 1;
                }
            }

            return powerOfKeyValue;
        }
        
        public void keyExchange()
        {
            var con = "";
            do
            {
                Console.WriteLine("Input first public key (has to be a prime number)");
                pKeyFirst = keyValidation();
                Console.WriteLine("Input second public key (has to be a prime number)");
                pKeySecond = keyValidation();

                int x;
                Console.WriteLine("Input first secret key (has to be a prime number)");
                String p1 = Console.ReadLine();

                while (!Int32.TryParse(p1, out x))
                {
                    Console.WriteLine("Not a valid number, try again.");
                    p1 = Console.ReadLine();
                }

                Console.WriteLine("Input second secret key (has to be a prime number)");
                String p2 = Console.ReadLine();

                while (!Int32.TryParse(p2, out x))
                {
                    Console.WriteLine("Not a valid number, try again.");
                    p2 = Console.ReadLine();
                }

                pSecretFirst = keyGenerator(pKeyFirst, Convert.ToInt32(p1), pKeySecond);
                pSecretSecond = keyGenerator(pKeyFirst, Convert.ToInt32(p2), pKeySecond);

                Console.WriteLine("First common key is - " +
                                  keyGenerator(pSecretSecond, Convert.ToInt32(p1), pKeySecond));
                Console.WriteLine("Second common key is - " +
                                  keyGenerator(pSecretFirst, Convert.ToInt32(p2), pKeySecond));
                con = Console.ReadLine();
            } while (con != "q");
        }
    }
}