using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using PTC.DOTIC.Dto;

namespace PTC.DOTIC.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
