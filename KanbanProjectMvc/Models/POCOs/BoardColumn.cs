using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KanbanProjectMvc.Models
{
    public class BoardColumn
    {
        public int BoardColumnId { get; set; }
        [Required]
        [Display(Name = "Column Name")]
        public string ColumnName { get; set; }
        public virtual ICollection<BoardSticker> Stickers { get; set; }
        }
}