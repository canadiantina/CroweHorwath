using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CroweHorwathAssignment.Data.Models;
using CroweHorwathAssignment.Data.Models.DTO;
using AutoMapper;

namespace CroweHorwathAssignment.Data.Core.Mapping
{
    public class CroweHorwathAssigmentDataMappingProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {

            try
            {
                base.Configure();

                #region "DTO to Entity"

                AutoMapper.Mapper.CreateMap<tblTagDTO, tblTag>();

                #endregion

                #region "Entity to DTO"

                AutoMapper.Mapper.CreateMap<tblTag, tblTagDTO>();

                #endregion

                AutoMapper.Mapper.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
