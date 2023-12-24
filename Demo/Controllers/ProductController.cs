
using Demo.Models;
using Demo.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Demo.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                //return BadRequest("valid object");
            return View(product);


        }

        [HttpGet]
        public async Task<IActionResult> getData()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // Product Details
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
                return NotFound();

            var product = await _context.Products.FirstOrDefaultAsync(a=>a.Id == id);
            if(product == null)
                return NotFound();

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            ViewBag.PageName = id == null ? "Create Product" : "Edit Product";
            ViewBag.IsEdit = id == null ? false : true;
            if (id == null)
            {
                return View();
            }
            else
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id , [Bind("Id,Name,Image,Price")] Product productData)
        {
            bool IsProduct = false;
            var product = await _context.Products.FindAsync(id);
            if(product != null)
                IsProduct = true;
            if (ModelState.IsValid)
            {
                product.Price = productData.Price;
                product.Name = productData.Name;
                product.Image = productData.Image;

                if (IsProduct)
                        _context.Update(product);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(productData);
        }


        // ProductController.cs
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Image")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }



        
        public async Task<IActionResult> delete(int id)
        {

            if(id != 0) 
            {
                var product = await _context.Products.FindAsync(id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(id);
        }
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            int skip = (page - 1) * pageSize;


            var products =  _context.Products
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(pageSize)
                .ToList();
            int totalProduct = products.Count;
            var paginatedList = new PaginatedList<Product>(products, totalProduct, page, pageSize);
            return View(paginatedList);
        }
        public IActionResult ShowProduct(int id)
        {
            Product product = new Product() {
                Id = id,
            Name="Iphone",
            Image="1.jpg",
            Price=4000};
            return View("Show", product);
        }


        //product/ShowProduct Action
        //public ContentResult ShowProduct()
        //{
        //    //declare
        //    ContentResult result = new ContentResult();
        //    //set value
        //    result.Content = "My First Action";
        //   //returen
        //    return result;
        //}

        //public ViewResult getView()
        //{
        //    //DEclate
        //    ViewResult result = new ViewResult();
        //    //set
        //    result.ViewName = "View1";
        //    //return
        //    return result;
        //}
        //public JsonResult getJson()
        //{
        //    //DEclate
        //    //JsonResult result = new JsonResult(new {ID=1,Name="Ahmed" });

        //    //return
        //    return Json(new { ID = 1, Name = "Ahmed" });
        //}


        public IActionResult get(int id)
        {
            if (id % 2 == 0)
            {
                return Content("Hiiii");
            }
            else
            {
                return View("View1");
            }
        }

        //Content string ==>ContentREsukt
        //View HTML      ==>ViewReuslt
        //redirect another web app ==>REdirectREsult
        //json           ==>JsonREsult
        //File           ==>FileREsult
        //JAvascript     ==>JAvascriptREsult
    }
}
