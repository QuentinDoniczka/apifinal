gitusing _27_11_23_asp.Data;
using _27_11_23_asp.Migrations;
using _27_11_23_asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// instaler le packer nget
using Microsoft.AspNetCore.JsonPatch;
using System.Text.RegularExpressions;
using NuGet.DependencyResolver;
using System.Linq;

namespace _27_11_23_asp.Controllers
{
    //[Route("api/Contact")]
    [Route("api/[controller]")]

    public class Contact : Controller
    {
        private readonly ApplicationDbContext _context;

        public Contact(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public ActionResult Get()
        {
            List<Model.Contact> contactList = new List<Model.Contact>(_context.Contact.ToList());
            return Ok(contactList);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Model.Contact? contact = _context.Contact.Find(id);
            return Ok(contact);
        }
/*        exemple d'une requette put avec l'id 5
         {
             "lastName": "TESTlast",
             "firstName": "TESTfirst",
             "email": "TESTfirst@test",
             "isPro": true
         }
*/
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Model.Contact contact)
        {
            contact.Id = id;

            _context.Attach(contact).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(contact);
        }
        /*        exemple d'une requette patch avec l'id 5
            [
                { "op": "replace", "path": "/LastName", "value": "TESTlast" },
                { "op": "replace", "path": "/FirstName", "value": "TESTfirst" },
                { "op": "replace", "path": "/Email", "value": "TESTfirst@test.com" },
                { "op": "replace", "path": "/IsPro", "value": true }
            ]
           */
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<Model.Contact> patch)
        {
            Model.Contact? contact = _context.Contact.Find(id);
            patch.ApplyTo(contact);
            _context.SaveChanges();
            return Ok(contact);
        }
        public ActionResult Post([FromBody] Model.Contact contact)
        {
            _context.Contact.Add(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpGet("{id}/groups")]
        public ActionResult GetGroups(int id)
        {
            return Ok(_context.ContactGroup.Where(x => x.ContactId == id));
        }

        [HttpPost("{id}/groups")]
        public ActionResult AddGroups(int id, [FromBody] Model.Groupe groupe)
        {
            groupe.Id = id;
            _context.Groupe.Add(groupe);
            _context.SaveChanges();
            return Ok(_context.Groupe.Where(x => x.Id == id)); ;
        }

        [HttpDelete("{id}/groups/{GroupId}")]
        public ActionResult DeleteGroup(int id, int GroupId)
        {
            var ctg = _context.ContactGroup.Where(x => x.ContactId == id && x.GroupeId == GroupId).FirstOrDefault();
            _context.Remove(ctg);
            _context.SaveChanges();
            return Ok(null);
        }
    }
    /* public class TeacherService
     {
         public Teacher Validate(Teacher teacher)
         {

             if (teacher.FirstName == null)
             {
                 return null;
             }
             teacher.Trigram = teacher.FirstName.EelementAt(0) + teacher.LastName.EelementAt(0) + teacher.LastName.EelementAt(0);
             teacher.Trigram = teacher.Trigram.ToUpper();
             if (!dbAccess.Exists(teacher))
             {
                 dbAccess.Save(teacher);
             }
             return teacher;
         }

         public interface IDbAccess
         {
             bool Exists(Teacher teacher);
             void Save(Teacher teacher);
         }
     }*/
}
