using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KanbanProjectMvc.Models.POCOs
{
    public class StickerAssignment
    {
        public int StickerAssignmentId { get; set; }
        public int ProfileId { get; set; }
        public int BoardStickerId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual BoardSticker Sticker { get; set; }
    }
}