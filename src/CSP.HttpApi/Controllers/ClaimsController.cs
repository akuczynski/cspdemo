using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace CSP.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/claims")]
	public class ClaimsController : Controller
	{
		[HttpGet]
		public JsonResult Get()
		{
			return Json(User.Claims.Select(x => new { Type = x.Type, Value = x.Value }));
		}
	}
}
