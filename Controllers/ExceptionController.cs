using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace aspnetrazor{

	public class ExceptionController : Controller {
		
		[Route("error/404")]
		public IActionResult Error404Action() {
			ContentResult res = new ContentResult();
			res.Content = "<h1>404 Error</h1>";
			res.ContentType = "text/html";
			res.StatusCode = 404;
			return res;
		}
		
		
		[Route("error/{code:int}")]
		public IActionResult ErrorCodeAction(int code) {
			ContentResult res = new ContentResult();
			res.Content = "<h1>" + code + " Error</h1>";
			res.ContentType = "text/html";
			res.StatusCode = code;
			return res;
		}
		
	}
}