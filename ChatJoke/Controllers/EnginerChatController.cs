using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;

namespace ChatJoke.Controllers
{

    /// <summary>
    /// API Rest Контроллер, так как у нас одно приложение и одна задача, то мы делаем WebSocket сервер прям тут...
    /// </summary>
    public class EnginerChatController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler());
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);

        }

        /// <summary>
        /// 
        /// </summary>
        class ChatWebSocketHandler : WebSocketHandler
        {

            private static WebSocketCollection _chatCients = new WebSocketCollection();
            public string uname;

            public ChatWebSocketHandler()
            {
                
            }

            /// <summary>
            /// 
            /// </summary>
            public override void OnOpen()
            {

                if (!_chatCients.Contains(this))
                {
                    uname = Guid.NewGuid().ToString("N");
                    //this.uname = this.WebSocketContext.QueryString["uname"];
                    _chatCients.Add(this);
                    _chatCients.Broadcast($"--- к нам присоеденился пользователь с иминем :{uname} ---");
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="message"></param>
            public override void OnMessage(string message)
            {
                if (message.IndexOf(":") >= 0)
                {
                    var spl = message.Split(':');
                    var users_private = _chatCients.Where(r => ((ChatWebSocketHandler)r).uname == spl[0] || ((ChatWebSocketHandler)r).uname == this.uname);
                    var collect = new WebSocketCollection();
                    foreach (ChatWebSocketHandler cont in users_private)
                    {
                        cont.Send($"{(uname == cont.uname ? $"{uname} -> {spl[0]}" : $"{uname} <- {cont.uname}")}: {spl[1]}");
                    }
                    //collect.Broadcast($"{uname}: {spl[1]}"); // .Broadcast($"{uname}: {message}");
                }
                else
                {
                    _chatCients.Broadcast($"{uname}: {message}");
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public override void OnClose()
            {
                _chatCients.Remove(this);
                _chatCients.Broadcast($"Пользователь с именем {uname} покинул чат :(");
            }

        }
    }
}