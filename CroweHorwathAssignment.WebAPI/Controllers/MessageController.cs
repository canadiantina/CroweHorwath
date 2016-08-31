using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CroweHorwathAssignment.Data.Models.DTO;
using CroweHorwathAssignment.Service.Services;
using CroweHorwathAssignment.Service.Interfaces;

namespace CroweHorwathAssignment.WebAPI.Controllers
{
    public class MessageController : ApiController
    {
        private IMessageService messageService = new MessageService();

        public IEnumerable<tblTagDTO> GetMessages()
        {
            return messageService.GetMessages();
        }

        public IHttpActionResult GetMessage(int id)
        {
            tblTagDTO tag = messageService.GetMessage(id);
            if (tag == null)
                return NotFound();
            return Ok(tag);
        }

        public tblTagDTO GetDefault()
        {
            return messageService.DefaultMessage();
        }

    }
}
