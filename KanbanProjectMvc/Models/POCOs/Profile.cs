using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KanbanProjectMvc.Models.POCOs;

namespace KanbanProjectMvc.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<StickerAssignment> Assignments { get; set; }
     }
}