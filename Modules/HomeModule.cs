using Nancy;
using CarDealership.Objects;
using System.Collections.Generic;

namespace CarDealership
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/add_car"] = _ => {
        return View["add_car.cshtml"];
      };
      Post["/car_added"] = _ => {
        string inputMake = Request.Form["new-make-model"];
        int inputYear = int.Parse(Request.Form["new-year"]);
        int inputPrice = int.Parse(Request.Form["new-price"]);

        Car inputCar = new Car(inputMake, inputYear, inputPrice);
        inputCar.AddToCarList();

        return View["car_added.cshtml", inputCar];
      };
      Get["/car_list"] = _ => {
        return View["car_list.cshtml", Car.ViewCarList()];
      };
    }
  }
}
