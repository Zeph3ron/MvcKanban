using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KanbanProjectMvc.EF;

namespace KanbanProjectMvc.Models.POCOs
{
    public class SampleData : System.Data.Entity.DropCreateDatabaseIfModelChanges<KanbanDbContext>
    {
        protected override void Seed(KanbanDbContext context)
        {
            var profiles = new List<Profile>
            {
                new Profile() {UserName = "Chris", Email = "zeph3ron@gmail.com"}
            
            };
            profiles.ForEach(profile => context.Profiles.Add(profile));
            context.SaveChanges();
            
            var boards = new List<KanbanBoard>
            {
                new KanbanBoard() {BoardName = "Trello Board"}
            };
            boards.ForEach(board => context.Boards.Add(board));
            context.SaveChanges();

            var columns = new List<BoardColumn>
            {
                new BoardColumn() {ColumnName = "Things to do"}
            };
            columns.ForEach(column => context.Columns.Add(column));
            context.SaveChanges();

            var stickers = new List<BoardSticker>
            {
                new BoardSticker() {StickerName = "Make soup"}
            };
            stickers.ForEach(sticker => context.Stickers.Add(sticker));
            context.SaveChanges();

            var assignments = new List<StickerAssignment>
            {
            };
            assignments.ForEach(assignment => context.Assignments.Add(assignment));
            context.SaveChanges();
            }
    }
}