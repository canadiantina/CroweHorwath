using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CroweHorwathAssignment.Data.Core.Mapping;
namespace CroweHorwathAssignment.WebAPI.App_Start
{
    public class MapperConfig
    {
        public static void ConfigureMapping()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile<CroweHorwathAssigmentDataMappingProfile>();
            });

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}