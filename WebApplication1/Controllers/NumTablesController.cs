using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NumTablesController : ApiController
    {
        private MyBaseEntities db = new MyBaseEntities();

        // GET: api/NumTables
        public IQueryable<NumTable> GetNumTable(int year,int iPageSize)
        {
            
            var q = (from n in db.NumTable
                     where n.StartDate.EndsWith(year.ToString()) 
                     orderby n.StartDate descending,n.Seq descending
                     select n
                     );

            
            return q.Take(iPageSize);

        }

        public List<CalResult> GetNumTable()
        {

            CalResult m = new CalResult(db);
            var q =  m.GeustNum();

            return q;
            
        }

        // GET: api/NumTables/5
        [ResponseType(typeof(NumTable))]
        public IHttpActionResult GetNumTable(int id)
        {
            NumTable numTable = db.NumTable.Find(id);
            if (numTable == null)
            {
                return NotFound();
            }

            return Ok(numTable);
        }

        // PUT: api/NumTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNumTable(int id, NumTable numTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != numTable.id)
            {
                return BadRequest();
            }
            numTable.flag = 0;
            db.Entry(numTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NumTables
        [ResponseType(typeof(NumTable))]
        public IHttpActionResult PostNumTable(NumTable numTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            numTable.flag = 0;
            db.NumTable.Add(numTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = numTable.id }, numTable);
        }

        // DELETE: api/NumTables/5
        [ResponseType(typeof(NumTable))]
        public IHttpActionResult DeleteNumTable(int id)
        {
            //System.IO.File.AppendAllText(@"C:\data\log.txt", id.ToString() + "\r\n");
            if (id == 1)
            {
                var q = (from n in db.NumTable
                         where n.flag == 0
                         orderby n.StartDate descending, n.Seq descending
                         select n).FirstOrDefault();

                if (q == null)
                {
                    return NotFound();
                }

                q.flag = 1;
                db.Entry(q).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Database.ExecuteSqlCommand("update NumTable set flag = 0 where flag =1");
                db.SaveChanges();
            }
            return Ok(200);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NumTableExists(int id)
        {
            return db.NumTable.Count(e => e.id == id) > 0;
        }
    }
}