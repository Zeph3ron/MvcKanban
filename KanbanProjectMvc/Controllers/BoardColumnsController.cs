using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KanbanProjectMvc.EF;
using KanbanProjectMvc.Models;

namespace KanbanProjectMvc.Controllers
{
    public class BoardColumnsController : Controller
    {
        private KanbanDbContext db = new KanbanDbContext();

        // GET: BoardColumns
        public ActionResult Index()
        {
            return View(db.Columns.ToList());
        }

        // GET: BoardColumns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardColumn boardColumn = db.Columns.Find(id);
            if (boardColumn == null)
            {
                return HttpNotFound();
            }
            return View(boardColumn);
        }

        // GET: BoardColumns/Create
        public ActionResult Create(int? boardId)
        {
            ViewBag.BoardId = boardId;
            ViewBag.BoardName = db.Boards.Find(boardId).BoardName;
            return View();
        }

        // POST: BoardColumns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardColumnId,ColumnName")] BoardColumn boardColumn, int? boardId)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Find(boardId).Columns.Add(boardColumn);
                db.SaveChanges();
                return RedirectToAction("Details", "KanbanBoards", new { id = boardId });
            }

            return View(boardColumn);
        }

        // GET: BoardColumns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardColumn boardColumn = db.Columns.Find(id);
            if (boardColumn == null)
            {
                return HttpNotFound();
            }
            return View(boardColumn);
        }

        // POST: BoardColumns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardColumnId,ColumnName")] BoardColumn boardColumn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardColumn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boardColumn);
        }

        // GET: BoardColumns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardColumn boardColumn = db.Columns.Find(id);
            if (boardColumn == null)
            {
                return HttpNotFound();
            }
            return View(boardColumn);
        }

        // POST: BoardColumns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardColumn boardColumn = db.Columns.Find(id);
            db.Columns.Remove(boardColumn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
