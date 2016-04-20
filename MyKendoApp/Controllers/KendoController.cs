using System.Web.Mvc;
using MyKendoRepository.Model;
using Kendo.Mvc.UI;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MyKendoBusinessLogic.ForUnity;


namespace MyKendoApp.Controllers
{
    public class KendoController : Controller
    {
        ICustomerBusinessLogic _customerBusinessLogic { get; set; }
        public KendoController()
        {
            IUnityContainer container;
            container = new UnityContainer();
            container.LoadConfiguration("default");
            _customerBusinessLogic = container.Resolve<ICustomerBusinessLogic>();
        }
     
        public ActionResult Home()
        {            
            return View();
        }
        
        public JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {   
            DataSourceResult result = _customerBusinessLogic.Read(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Create(CustomerModel objCustomer)
        {
            if (objCustomer.Id == null)
            {
                objCustomer = _customerBusinessLogic.Create(objCustomer);
            }
            // Return the Schema Data Updated with new Customer Object for update on client side
            return Json(new { Data = new[] { objCustomer } }, JsonRequestBehavior.AllowGet);            
        }
        public JsonResult Update(CustomerModel objCustomer)
        {
            if (objCustomer != null)
            {
                _customerBusinessLogic.Update(objCustomer);
            }
            return Json(new[] { objCustomer }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Destroy(CustomerModel objCustomer)
        {
            int? CustomerId = (objCustomer == null) ? 0 : objCustomer.Id;
            if (CustomerId > 0)
            {
                _customerBusinessLogic.Destroy(CustomerId);
            }
            return Json(new[] { CustomerId }, JsonRequestBehavior.AllowGet);
        }
	}
}