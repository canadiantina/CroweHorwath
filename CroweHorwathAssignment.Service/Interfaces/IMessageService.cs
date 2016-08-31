using CroweHorwathAssignment.Data.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroweHorwathAssignment.Service.Interfaces
{
    public interface IMessageService
    {
        List<tblTagDTO> GetMessages();
        tblTagDTO GetMessage(int id);

        tblTagDTO DefaultMessage();
    }
}
