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
    public class BoardStickersController : Controller
    {
        private KanbanDbContext db = new KanbanDbContext();

        // GET: BoardStickers
        public ActionResult Index()
        {
            return View(db.Stickers.ToList());
        }

        // GET: BoardStickers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardSticker boardSticker = db.Stickers.Find(id);
            if (boardSticker == null)
            {
                return HttpNotFound();
            }
            return View(boardSticker);
        }

        // GET: BoardStickers/Create
        public ActionResult Create(int? columnId, int? boardId)
        {
            ViewBag.ColumnId = columnId;
            ViewBag.ColumnName = db.Columns.Find(columnId).ColumnName;
            return View();
        }

        // POST: BoardStickers/MoveSticker
        [HttpPost]
        public void MoveSticker(int? id, int? toColumnId, int? boardId)
        {
            var sticker = db.Stickers.Find(id);
            var columns = db.Columns.Select(c => c).Include(c => c.Stickers).ToList();
            var fromColumn = columns.Where(c => c.Stickers.Contains(sticker)).Select(c => c).ToList().Single();
            var toColumn = columns.Where(column => column.BoardColumnId == toColumnId).ToList().Single();
            var boardUsed = db.Boards.Find(boardId);

            fromColumn.Stickers.Remove(sticker);
            toColumn.Stickers.Add(sticker);
            db.SaveChanges();
        }

        // GET: BoardStickers/MoveSticker
        //public int GetBoardId(int? id)
        //{
            
        //}

        // POST: BoardStickers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoardStickerId,StickerName")] BoardSticker boardSticker, int? columnId, int? boardId)
        {
            if (ModelState.IsValid)
            {
                db.Columns.Find(columnId).Stickers.Add(boardSticker);
                db.SaveChanges();
                return RedirectToAction("Details", "KanbanBoards", new {id = boardId});
            }

            return View(boardSticker);
        }

        // GET: BoardStickers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardSticker boardSticker = db.Stickers.Find(id);
            if (boardSticker == null)
            {
                return HttpNotFound();
            }
            return View(boardSticker);
        }

        // POST: BoardStickers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoardStickerId,StickerName")] BoardSticker boardSticker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardSticker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boardSticker);
        }

        // GET: BoardStickers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardSticker boardSticker = db.Stickers.Find(id);
            if (boardSticker == null)
            {
                return HttpNotFound();
            }
            return View(boardSticker);
        }

        // POST: BoardStickers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardSticker boardSticker = db.Stickers.Find(id);
            var boardId = GetBoardId(boardSticker);
            db.Stickers.Remove(boardSticker);
            db.SaveChanges();
            return RedirectToAction("Details", "KanbanBoards", new {id = boardId});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public int GetBoardId(BoardSticker sticker)
        {
            var allColumns = db.Columns.ToList();
            var stickerColumn = allColumns.Where(column => column.Stickers.Contains(sticker)).ToList().Single();

            var allBoards = db.Boards.ToList();
            var columnBoard = allBoards.Where(board => board.Columns.Contains(stickerColumn)).ToList().Single();

            return columnBoard.KanbanBoardId;
         }
    }
}
