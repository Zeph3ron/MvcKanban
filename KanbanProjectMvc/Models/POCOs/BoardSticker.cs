using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KanbanProjectMvc.Models.POCOs;

namespace KanbanProjectMvc.Models
{
    public class BoardSticker
    {
        public int BoardStickerId { get; set; }
        [Required]
        [Display(Name = "Sticker Name")]
        public string StickerName { get; set; }
        public virtual ICollection<StickerAssignment> Assignments { get; set; }
        }
}