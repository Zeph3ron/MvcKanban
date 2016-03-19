using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KanbanProjectMvc.Models.POCOs;

namespace KanbanProjectMvc.Models
{
    public class KanbanBoard
    {
        public int KanbanBoardId { get; set; }
        [Required]
        [Display(Name = "Board Name")]
        public string BoardName { get; set; }
        public virtual ICollection<BoardColumn> Columns { get; set; }
        
    }
}