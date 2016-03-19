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
    public class KanbanBoardsController : Controller
    {
        private KanbanDbContext db = new KanbanDbContext();

        // GET: KanbanBoards
        public ActionResult Index()
        {
            return View(db.Boards.ToList());
        }

        // GET: KanbanBoards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KanbanBoard kanbanBoard = db.Boards.Find(id);
            if (kanbanBoard == null)
            {
                return HttpNotFound();
            }
            return View(kanbanBoard);
        }

        // GET: KanbanBoards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KanbanBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KanbanBoardId,BoardName")] KanbanBoard kanbanBoard)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Add(kanbanBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kanbanBoard);
        }

        // GET: KanbanBoards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KanbanBoard kanbanBoard = db.Boards.Find(id);
            if (kanbanBoard == null)
            {
                return HttpNotFound();
            }
            return View(kanbanBoard);
        }

        // POST: KanbanBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KanbanBoardId,BoardName")] KanbanBoard kanbanBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kanbanBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kanbanBoard);
        }

        // GET: KanbanBoards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KanbanBoard kanbanBoard = db.Boards.Find(id);
            if (kanbanBoard == null)
            {
                return HttpNotFound();
            }
            return View(kanbanBoard);
        }

        // POST: KanbanBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KanbanBoard kanbanBoard = db.Boards.Find(id);
            db.Boards.Remove(kanbanBoard);
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
