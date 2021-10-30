using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchandiseService.HttpModels;

namespace Ozon.MerchandiseService.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MerchController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<MerchItemResponse>> GetMerch()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<MerchItemRequest>> GetInfoAboutMerch()
        {
            throw new NotImplementedException();
        }
    }
}