using Core_Deneme.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Core_Deneme.Controllers
{
    public class KullaniciGirisController : Controller
    {
        private AppDbContext _context;
        public KullaniciGirisController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult KullaniciGiris()
        {
            return View();
        }
        public async Task<IActionResult> KullaniciGir(Kullanicilar kullanicilar)
        {

            Kullanicilar kullanici;
            try
            {
                kullanici = _context.Kullanicilar.Where(k => k.E_Posta.Equals(kullanicilar.E_Posta)).First();
                if (kullanici.Sifre.Equals(kullanicilar.Sifre))
                {

                    HttpContext.Session.SetInt32("Id", kullanici.Id);
                    HttpContext.Session.SetString("E_Posta", kullanici.E_Posta);
                    HttpContext.Session.SetString("Ad", kullanici.Ad);
                    HttpContext.Session.SetString("Soyad", kullanici.Soyad);
                    HttpContext.Session.SetString("Sifre", kullanici.Sifre);
                    HttpContext.Session.SetString("Telefon", kullanici.Telefon);
                    HttpContext.Session.SetString("Rol", kullanici.Rol);
                }

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, HttpContext.Session.GetString("Ad")),
                new Claim(ClaimTypes.Role, HttpContext.Session.GetString("Rol"))
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            }
            catch (Exception ex)
            {

                TempData["girisDurum"] = "Hatalı Veya Eksik Bilgi Girildi";
                return RedirectToAction("KullaniciGiris");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
