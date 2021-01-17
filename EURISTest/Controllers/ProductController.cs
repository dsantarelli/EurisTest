using EURIS.Domain.Services;
using EURISTest.Mappers;
using EURISTest.Models.Product;
using System.Net;
using System.Web.Mvc;

namespace EURISTest.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
      _productService = productService;      
    }

    // GET: Product
    public ActionResult Index()
    {
      var products = _productService.GetProducts();
      return View(ProductViewModelMapper.MapListViewModel(products));
    }

    // GET: Product/Details/5
    public ActionResult Details(string code)
    {
      if (string.IsNullOrWhiteSpace(code))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var product = _productService.GetProduct(code);

      if (product == null) 
        return HttpNotFound();

      return View(ProductViewModelMapper.MapDetailsViewModel(product));
    }

    // GET: Product/Create
    public ActionResult Create()
    {
      return View(ProductViewModelMapper.MapCreateViewModel());
    }

    // POST: Product/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ProductCreateViewModel viewModel)
    {
      if (ModelState.IsValid)
      {
        _productService.AddProduct(viewModel.Code, viewModel.Description);
        return RedirectToAction("Index");
      }

      return View(viewModel);
    }

    // GET: Product/Edit/5
    public ActionResult Edit(string code)
    {
      if (string.IsNullOrWhiteSpace(code))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var product = _productService.GetProduct(code);

      if (product == null)
        return HttpNotFound();

      return View(ProductViewModelMapper.MapEditViewModel(product));
    }

    // POST: Product/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ProductEditViewModel viewModel)
    {
      if (ModelState.IsValid)
      {
        _productService.UpdateProduct(viewModel.Code, viewModel.Description);
        return RedirectToAction("Index");
      }

      return View(viewModel);
    }

    // GET: Product/Delete/5
    public ActionResult Delete(string code)
    {
      if (string.IsNullOrWhiteSpace(code))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var product = _productService.GetProduct(code);

      if (product == null)
        return HttpNotFound();

      return View(ProductViewModelMapper.MapDeleteViewModel(product));
    }

    // POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(string code)
    {
      _productService.DeleteProduct(code);
      return RedirectToAction("Index");
    }
  }
}
