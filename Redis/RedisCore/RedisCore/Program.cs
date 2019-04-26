using System;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace RedisCore
{
    class Program
    {
        static void Main(string[] args)
        {

            RedisHelper redisHelper = new RedisHelper();
            for (int i = 0; i < 10; i++)
            {
                redisHelper.ListRightPush("RedisHelperTestone", i.ToString());
            }
            var showRedisList = redisHelper.ListRange("RedisHelperTestone");

            Console.WriteLine();
            


            //var redisManger = new RedisManagerPool("127.0.0.1:6379");      //Redis的连接字符串
            //var redis = redisManger.GetClient();                           //获取一个Redis Client
            //var redisTodos = redis.As<BinFileToCisco>();
            //var newTodo = new BinFileToCisco                                          //实例化一个Todo类
            //{
            //    Id = redisTodos.GetNextSequence(),
            //    Base64 = "DbAHAgAAAAAAAAAFZwAKAAAAAEBGUyAgICAgICAgICAgICAgAAAAX1FTRlAtTFI0LTQwRyAgICBBIGZYBRRGQwAADNhZMTgwNjAwMDQwNyAgICAgMjAxODA3MDUMAAB6AAAI22UFaSqjfKNUJjGCNEs2zAAAAAAAAAAAAIOUeIJJUDlJQU5FQ0FBMTAtMjg0OC0wMVYwMSABAAAAAAAAAAB+AAAAAAAAAACMmZsArdvZnAAAKZlhzx6aAGcAAKqqUVNGUC00MEdFLUxSNCAgICAgICAAAAAAAAAAAAAAADY2NDEzNDQxNQCcYkhiumL3ILcmcBpZ/wAAAAAAAAAAAA==",
            //    FileLocation = "/home/_project/fs/upload/file/rarbins/1531826433581/QSFP-LR4-40G-CO/Y1806000407.bin",
            //    IsDelete = 0,
            //    WriteStatus = 0 
            //};
            //redisTodos.Store(newTodo);                                    //把newTodo实例保存到数据库中    增     
            //BinFileToCisco saveTodo = redisTodos.GetById(newTodo.Id);               //根据Id查询查
            //"Saved Todo: {0}".Print(saveTodo.Dump());

            ////saveTodo.IsDelete = 1;                                         //改
            ////redisTodos.Store(saveTodo);

            ////var updateTodo = redisTodos.GetById(newTodo.Id);            //查
            ////"Updated Todo: {0}".Print(updateTodo.Dump());

            ////redisTodos.DeleteById(newTodo.Id);                           //删除

            ////var remainingTodos = redisTodos.GetAll();
            ////"No more Todos:".Print(remainingTodos.Dump());




            Console.ReadLine();

          
        }
    }
}
