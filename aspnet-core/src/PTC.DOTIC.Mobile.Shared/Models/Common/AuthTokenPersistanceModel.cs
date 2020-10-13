using System;
using Abp.AutoMapper;
using PTC.DOTIC.Sessions.Dto;

namespace PTC.DOTIC.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}