using ListFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListFood.Controllers
{
    public class ItemController : Controller
    {
        private static IList<Item> _list = new List<Item>();
        private static int _id = 0;

        [HttpGet]
        public IActionResult Index()
        {
            if (_list.Any(x => x.Price > 0))
                TempData["value"] = $"Total value of items: {_list.Sum(x => x.Price)}";

            return View(_list);
        }

        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var items = from i in _list
                        select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Name.Contains(searchString));
            }

            if (items.Any(x => x.Price > 0))
            {
                TempData["value"] = $"Total value of items: {items.Sum(x => x.Price)}";
            }

            TempData["msg"] = "Filtered list!";

            return View(items.ToList());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _list.First(i => i.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            var index = _list.ToList().FindIndex(i => i.Id == item.Id);
            _list[index] = item;

            TempData["msg"] = "Item Updated!";

            if(_list.Any(x => x.Price > 0))
                TempData["value"] = $"Total value of items: {_list.Sum(x => x.Price)}";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Item item) 
        {
            item.Id = ++_id;
            _list.Add(item);
            TempData["message"] = "Item registered";
            return RedirectToAction("Register");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _list.Remove(_list.First(i => i.Id == id));
            TempData["msg"] = "Item removed!";
            return RedirectToAction("Index");
        }
    }
}
