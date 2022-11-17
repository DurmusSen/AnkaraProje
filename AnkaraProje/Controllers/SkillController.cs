using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnkaraProje.Models;

namespace AnkaraProje.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }
        DbAnkaraPortfolioEntities db = new DbAnkaraPortfolioEntities();
        public ActionResult SkillList()
        {
            //var ile değişken atanır ve döndürmesi için returnün içine atanan değişken yazılır.
            //Sonra Skillist() üzerine sağ tıklanıp tablo oluşturulur
            var values = db.TblSkill.ToList();
            return View(values);

        }


        //Sağa tıklayıp sayfanın gerekli kodlarını yazmamız gerekiyor
        //İlk Başta sayfa gelsin tıklanınca işlem yapsın diye [Httpler] eklenir 
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]

        //Girilen verileri tabloya işleyip skil listesine geri gönderiyor [Httpler] altındaki kodu çalıştırı
        public ActionResult AddSkill(TblSkill p)
        {
            db.TblSkill.Add(p);
            db.SaveChanges();
            return RedirectToAction("SkillList");

        }


        //Skilleri silmek için aşağıdaki yazılır Skillist içerisinde de fonksiyon içinde yazılır
        public ActionResult DeleteSkill(int id)
        {
            var values = db.TblSkill.Find(id);
            db.TblSkill.Remove(values);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }

        //Skilleri güncellemek için aşağıdaki kodlar yazılır bunuda skilliste href kısmında yazılır

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var values = db.TblSkill.Find(id);
            return View(values);
        }

        //Güncellenen veriyi ilgili id satırına yazması için aşağdaıki kodlar yazılır.
        //Değerleri skil sayfasından alıp yeni değeri ilgili title yazıp kaydedip sKİL LİSTE GERİ döndürüyor
        [HttpPost]
        public ActionResult UpdateSkill(TblSkill p)
        {
            var values = db.TblSkill.Find(p.SkilllD);
            values.Title = p.Title;
            values.Value = p.Value;
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}