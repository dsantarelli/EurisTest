using EURIS.Domain.Services;
using EURISTest.Mappers;
using EURISTest.Models.Catalog;
using System.Net;
using System.Web.Mvc;

namespace EURISTest.Controllers
{
  public class CatalogController : Controller
  {
    private readonly ICatalogService _catalogService;
    private readonly IProductService _productService;    

    public CatalogController(ICatalogService catalogService, IProductService productService)
    {
      _catalogService = catalogService;
      _productService = productService;      
    }

    // GET: Catalog
    public ActionResult Index()
    {
      var catalogs = _catalogService.GetCatalogs();
      return View(CatalogViewModelMapper.MapListViewModel(catalogs));
    }

    // GET: Catalog/Details/5
    public ActionResult Details(string code)
    {
      if (string.IsNullOrWhiteSpace(code))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var catalog = _catalogService.GetCatalog(code);
      
      if (catalog == null) 
        return HttpNotFound();

      return View(CatalogViewModelMapper.MapDetailsViewModel(catalog));
    }

    // GET: Catalog/Create
    public ActionResult Create()
    {   
      var products = _productService.GetProducts();
      return View(CatalogViewModelMapper.MapCreateViewModel(products));
    }

    // POST: Catalog/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CatalogCreateViewModel vm)
    {
      if (ModelState.IsValid)
      {       
        _catalogService.AddCatalog(vm.Code, vm.Description, vm.SelectedProducts.ToArray());
        return RedirectToAction("Index");
      }

      return View(vm);
    }

    // GET: Catalog/Edit/5
    public ActionResult Edit(string code)
    {
      if (string.IsNullOrWhiteSpace(code))      
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var catalog = _catalogService.GetCatalog(code);
      
      if (catalog == null) 
        return HttpNotFound();
      
      return View(CatalogViewModelMapper.MapEditViewModel(catalog, _productService.GetProducts()));
    }

    // POST: Catalog/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(CatalogEditViewModel vm)
    {
      if (ModelState.IsValid)
      {
        var catalog = _catalogService.GetCatalog(vm.Code);
        
        if (catalog == null) 
          return HttpNotFound();
      
        _catalogService.UpdateCatalog(vm.Code, vm.Description, vm.SelectedProducts.ToArray());

        return RedirectToAction("Index");
      }

      return View(vm);
    }

    // GET: Catalog/Delete/5
    public ActionResult Delete(string code)
    {
      if (string.IsNullOrWhiteSpace(code))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      
      var catalog = _catalogService.GetCatalog(code);
      
      if (catalog == null)      
        return HttpNotFound();
      
      return View(CatalogViewModelMapper.MapDeleteViewModel(catalog));
    }

    // POST: Catalog/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(string code)
    {
      _catalogService.DeleteCatalog(code);
      return RedirectToAction("Index");
    }
  }
}
