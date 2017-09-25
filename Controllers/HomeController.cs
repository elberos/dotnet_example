using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Elberos.Orm;

namespace aspnetrazor{

	public class HomeController : Controller {
		
		[Route("/", Name = "site:index")]
		public async Task<IActionResult> IndexAction() {

			var url = this.Url.Action("site:index");
			this.ViewData["url"] = url;
			
			IEntityManager em = EntityManager.getInstance();
			QueryBuilder qb = em.select(typeof(TestEntityRepository));
			
			await qb.execute();
			
			QueryResult result = qb.getQueryResult();
			List<TestEntity> a = await QueryObjects<TestEntity>.get(result);
			
			//string s = (string)qb.getQuery();
			//Console.WriteLine("Execute query:");
			//Console.WriteLine(s);
			
			this.ViewData["result"] = result;
			
			return this.View("/Views/Home/IndexAction.cshtml");
		}


	}
}

