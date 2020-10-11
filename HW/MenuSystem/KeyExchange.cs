using System;

namespace MenuSystem
{
    public class KeyExchange
    {
        private ulong pKeyFirst;
        private ulong pKeySecond;
        private ulong pSecretFirst;
        private ulong pSecretSecond;
        

        static ulong keyValidation()
        {
            ulong tKey = 0;
            var inputKey = "";
            bool wrongInput = false;
            do
            {
                if (wrongInput)
                    Console.WriteLine("Try again");
                inputKey = Console.ReadLine();
                if (ulong.TryParse(inputKey, out tKey))
                    wrongInput = primesValidation(tKey);
            } while (wrongInput);
            return tKey;
        }

        static bool primesValidation(ulong inputKey)
        {
            if (inputKey < 2)
                return true;
            for (ulong i = inputKey/2; i > 1; i--)
            {
                if (inputKey % i == 0)
                    return true;
            }
            return false;
        }
        
        static ulong keyGenerator(ulong publicKeyA, ulong secretPart, ulong publicKeyB)
        {
            
            ulong powerOfKeyValue = 1;
            ulong remainingPart = publicKeyA % publicKeyB;
            for (ulong i = secretPart; i > 0; i--)
            {
                
                if (powerOfKeyValue < publicKeyB && i != secretPart)
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
            Console.WriteLine("Input first public key (has to be a prime number)");
            pKeyFirst = keyValidation();
            Console.WriteLine("Input second public key (has to be a prime number)");
            pKeySecond = keyValidation();

            ulong x;
            ulong pFirst;
            ulong pSecond;
            Console.WriteLine("Input first secret key (has to be a prime number)");
            String p1 = Console.ReadLine();

            while (!ulong.TryParse(p1, out x))
            {
                Console.WriteLine("Not a valid number, try again.");
                p1 = Console.ReadLine();
            }

            Console.WriteLine("Input second secret key (has to be a prime number)");
            String p2 = Console.ReadLine();

            while (!ulong.TryParse(p2, out x))
            {
                Console.WriteLine("Not a valid number, try again.");
                p2 = Console.ReadLine();
            }

            pFirst = Convert.ToUInt64(p1);
            pSecond = Convert.ToUInt64(p2);

            pSecretFirst = keyGenerator(pKeyFirst, pFirst, pKeySecond);
            pSecretSecond = keyGenerator(pKeyFirst, pSecond, pKeySecond);
            Console.WriteLine("First common key is - " +
                              keyGenerator(pSecretSecond, pFirst, pKeySecond));
            Console.WriteLine("Second common key is - " +
                              keyGenerator(pSecretFirst, pSecond, pKeySecond));
        }
    }
}