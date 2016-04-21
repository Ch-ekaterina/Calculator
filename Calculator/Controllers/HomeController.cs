using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Calculator(string arg1, string arg2, string math)
        {
            Models.ResultModel model = new Models.ResultModel()
            {
                arg1 = arg1,
                arg2 = arg2,
                math = math,
            };
            decimal a = 0;
            decimal b = 0;
            string result = "";

            if (arg1 == "" || arg2 == "")
                result = "Укажите, пожалуйста, оба аргумента";
            else if (!decimal.TryParse(arg1, out a) || !decimal.TryParse(arg2, out b))
                result = "При вводе аргументов воспользуйтесь, пожалуйста, клавишами с цифрами";
            else
                switch (math)
                {
                    case "+":
                        result = (a + b).ToString();
                        break;
                    case "-":
                        result = (a - b).ToString();
                        break;
                    case "*":
                        result = (a * b).ToString();
                        break;
                    case "/":
                        result = b != 0 ?
                        (a / b).ToString()
                        : "На нуль делить нельзя";
                        break;
                    default:
                        result = "Выберите математическую функцию";
                        break;
                }
            model.result = result;

            return View(model);
        }
       
    }
}