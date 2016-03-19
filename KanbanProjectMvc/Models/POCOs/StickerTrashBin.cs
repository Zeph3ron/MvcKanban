using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KanbanProjectMvc.Models.POCOs
{
    public class StickerTrashBin
    {
        public List<BoardSticker> DeletedStickers { get; set; }
    }
}