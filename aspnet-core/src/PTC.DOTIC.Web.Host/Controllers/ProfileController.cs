using Abp.AspNetCore.Mvc.Authorization;
using PTC.DOTIC.Storage;

namespace PTC.DOTIC.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }
    }
}