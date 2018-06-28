using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalRChat
{
    public class ChatHub:Hub    // chat işlemlerimizi bu class yapacak.
    {
        public void sendbroadcast(string name, string message)   // broadcast mesaj gönderir.
        {
            Clients.All.broadcastMessage(name + " | broadcast msg.", message);
        }
        public void sendgroup(string name, string message, string groupName)  // grup mesajı gönderir.
        {
            Clients.Group(groupName).broadcastMessage(name + " | group msg.", message);
        }

        public void sendtouser(string name, string message, string receiverConId, string selfConId)  // özel mesaj gönderir.
        {
            Clients.Client(receiverConId).broadcastMessage(name + " | private msg.", message); 
            Clients.Client(selfConId).broadcastMessage(name + " | private msg.", message);
        }
        public void join(string roomName)   // kullanıcıyı gruba ekler.
        {
            Groups.Add(Context.ConnectionId, roomName);
        }
      
    }
}