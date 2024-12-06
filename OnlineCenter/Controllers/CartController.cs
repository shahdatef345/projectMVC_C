using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Reposetory.IReposetory;
using DataAccess.Reposetory;
using Models;
using static DataAccess.Reposetory.IReposetory.ICartRepository;
using ICartRepository = DataAccess.Reposetory.IReposetory.ICartRepository;
namespace OnlineCenter.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartRepository _cartRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ICartRepository CartRepository, UserManager<IdentityUser> userManager)
        {
            _cartRepository = CartRepository;
            _userManager = userManager;
        }
        [HttpPost]
        public IActionResult Add(int bookId)
        {
            var userId = _userManager.GetUserId(User);
            var cartItem = new Cart { BookId = bookId, StudentId = userId };
            _cartRepository.Add(cartItem);
            _cartRepository.Commit();
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var ApplicationUserId = _userManager.GetUserId(User);

            var cartProduct = _cartRepository.GetAll([e => e.Book], e => e.StudentId == ApplicationUserId).ToList();

            ViewBag.Total = cartProduct.Sum(e => e.Book.Price);

            return View(cartProduct.ToList());
        }
        public IActionResult Delete(int bookId)
        {
            var ApplicationUserId = _userManager.GetUserId(User);

            var product = _cartRepository.GetOne(expresion: e => e.StudentId == ApplicationUserId && e.BookId == bookId);

            if (product != null)
            {
                _cartRepository.Delete(product);
                _cartRepository.Commit();

                return RedirectToAction("Index");
            }

            return RedirectToAction("NotFoundPage", "Home");
        }



    }
}
