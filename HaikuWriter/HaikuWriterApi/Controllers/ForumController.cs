using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BusinessLogic;
using Models;

namespace HaikuWriterApi.Controllers
{
    public class ForumController
    {
        private readonly ForumMethods _forumMethod;

        public ForumController(ForumMethods forummethod)
        {
            _forumMethod = forummethod;
        }
                
        [HttpGet("getthreadlist")]
        public ActionResult<List<Thread>> GetThreads()
        {
            List<Thread> threads = _forumMethod.GetThreads();
            return threads;
        }

        [HttpGet("getmessages/{threadid}")]
        public ActionResult<List<Message>> GetMessages(int threadid)
        {
            List<Message> messages = _forumMethod.GetMessages(threadid);
            return messages;
        }

        [HttpPost("newthread")]
        public ActionResult<Thread> NewThread([FromBody] Thread thread)
        {
            Thread newthread = _forumMethod.NewThread(thread);

            return newthread;
        }

        [HttpPost("newmessage")]
        public ActionResult<Message> NewMessage([FromBody] Message message)
        {
            Message newmessage = _forumMethod.NewMessage(message);
            return newmessage;
        }
    }
}