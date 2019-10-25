using System;

namespace DecorateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new ApplePhone();

            Decorator applePhoneWithSticker = new Sticker(phone);

            applePhoneWithSticker.Print();


            Console.ReadLine();
        }
    }
}
