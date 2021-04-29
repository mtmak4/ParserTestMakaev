using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Parser;
using ParserTestMakaev.BL;
using ParserTestMakaev.DAL;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ParserTestMakaev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParserController : Controller
    {

        WebClient wc = new WebClient();
        ApplicationDbContext db;
        string siteAdress = @"https://www.avito.ru/orenburg/avtomobili";
        public  ParserController(ApplicationDbContext context)
        {
            db = context;
            db.Products.ForEachAsync(x => db.Products.Remove(x));
            

        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var config = Configuration.Default;
            List<string> res = new List<string>();
           
            //Create a new context for evaluating webpages with the given config
            var browseContext = BrowsingContext.New(config);

            string source = wc.DownloadString(siteAdress);
            //Source to be parsed


            //Create a virtual request to specify the document to load (here from our fixed string)
            var document = await browseContext.OpenAsync(req => req.Content(source));

            var titles = document.QuerySelectorAll("h3");
            var prices = document.QuerySelectorAll("span[data-marker='item-price']>span");
            for (int i = 0; i < titles.Length; i++)
            {
                
                Product itemProduct = new Product();
                try
                {
                    itemProduct.Title = titles[i].InnerHtml;
                }
                catch
                {
                    continue;
                }
                try
                {
                    itemProduct.Price = prices[i].TextContent;
                }
                catch
                {
                    continue;
                }
                
                db.Products.Add(itemProduct);
            }
            await db.SaveChangesAsync();
            return await db.Products.ToListAsync();
        }
    }
}
