using static Entrust.Bridegroom;

namespace Entrust
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化对象
            Bridegroom bridegroom = new Bridegroom();

            //实例化朋友对象
            Friend friend1 = new Friend("张三");
            Friend friend2 = new Friend("李四");
            Friend friend3 = new Friend("王五");

            //订阅事件
            bridegroom.MarryEvent += new MarryHandler(friend1.SendMessage);
            bridegroom.MarryEvent += new MarryHandler(friend2.SendMessage);

            // 发出通知，此时订阅事件的对象才能收到通知
            bridegroom.OnBirthdayComing("发出通知");
            System.Console.WriteLine("-----------------------------");

            //使用-= 取消事件订阅
            bridegroom.MarryEvent -= new MarryHandler(friend2.SendMessage);

            //使用+=添加事件订阅
            bridegroom.MarryEvent += new MarryHandler(friend3.SendMessage);

            bridegroom.OnBirthdayComing("再次发出通知");
            System.Console.Read();
        }
    }
}
