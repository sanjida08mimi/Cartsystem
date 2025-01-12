using CartSystem.Data;
using CartSystem.Models.Domain;
using CartSystem.Models.ViewModel;
using CartSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CartSystem.Controllers
{
    public class AdminOrderController : Controller
    {
        private readonly ICartRepo _cartRepo;

        public AdminOrderController(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }



        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddToCartRequest addToCartRequest)
        {
            var cartitem = new CartItem
            {
                Colour = addToCartRequest.Colour,
                Quantity = addToCartRequest.Quantity
            };
            await _cartRepo.AddAsync(cartitem);
            return RedirectToAction("List");
        }
        [HttpGet]

        public async Task<IActionResult> List()
        {
            var cartitems = await _cartRepo.GetAllAsync();
            return View(cartitems);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cartitems = await _cartRepo.GetAsync(id);
            if( cartitems != null)
            {
                var editCartRequest = new EditCartRequest
                {
                    Id = cartitems.Id,
                    Colour = cartitems.Colour,
                    Quantity = cartitems.Quantity
                };
                return View(editCartRequest);
            }
            return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCartRequest editCartRequest)
        {
            var cartItem = new CartItem
            {
                Id = editCartRequest.Id,
                Colour = editCartRequest.Colour,
                Quantity = editCartRequest.Quantity

            };
          var updatedCartItem = await _cartRepo.UpdateAsync(cartItem);
            if (updatedCartItem != null)
            {
                return RedirectToAction("List");

            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public async Task<IActionResult> DeletAsync(EditCartRequest editCartRequest)
        {
            // Find the existing cart item using the provided Id
            var deletedCartItem = await _cartRepo.DeletAsync(editCartRequest.Id);
            if (deletedCartItem != null)
            {
                return RedirectToAction("List");

            }
            return RedirectToAction("List");
        }


    }
}
