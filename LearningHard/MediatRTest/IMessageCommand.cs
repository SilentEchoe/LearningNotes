using System;
using System.Collections.Generic;
using System.Text;

namespace MediatRTest
{
    public interface IMessageCommand
    {
        void DoAction();
    }

    public class Broker
    {
        public void SendMessage(IMessageCommand command)
        {
            command.DoAction();
        }

    }

}
