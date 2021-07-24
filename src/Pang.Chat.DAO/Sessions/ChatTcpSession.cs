using SuperSocket.Server;
using System;
using System.Collections.Generic;
using System.Text;
using Pang.Chat.DAO.Models;

namespace Pang.Chat.DAO.Sessions
{
    public class ChatTcpSession: AppSession
    {
        public User User { get; set; }
    }
}
