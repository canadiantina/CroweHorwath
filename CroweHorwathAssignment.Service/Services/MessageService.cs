using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CroweHorwathAssignment.Data.Models.DTO;
using CroweHorwathAssignment.Service.Interfaces;
using CroweHorwathAssignment.Data.Models;

namespace CroweHorwathAssignment.Service.Services
{
    public class MessageService : IMessageService
    {
        private CroweExampleDBEntities db = new CroweExampleDBEntities();
        public List<tblTagDTO> GetMessages()
        {
            List<tblTagDTO> tagDTOs = null;

            try
            {
                List<tblTag> Tags = db.tblTags.ToList();
                tagDTOs = AutoMapper.Mapper.Map <List<tblTag>, List<tblTagDTO>>(Tags);

            } catch (Exception ex)
            {
                throw ex;
            }
            

            return tagDTOs;
        }

        public tblTagDTO GetMessage(int id)
        {
            tblTagDTO tagDTO = null;
            try
            {
                tblTag tag = db.tblTags.Where(x => x.tagId == id).FirstOrDefault();
                tagDTO = AutoMapper.Mapper.Map<tblTag, tblTagDTO>(tag);

            } catch (Exception ex)
            {
                throw ex;
            }

            return tagDTO;
        }

        public tblTagDTO DefaultMessage()
        {
            tblTagDTO tagDTO = new tblTagDTO {tagId = -1, tagDescription="Hello World", tagName = "Default"};
            return tagDTO;
        }

    }
}