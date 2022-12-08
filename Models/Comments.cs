using System;
using System.ComponentModel.DataAnnotations;

  namespace Final3312
  {
    //this is a model of the comments
      public class comment
      {
        public int CommentID {get; set;}// This is the "primary key"
        [Required]
        public int UserID {get; set;}
        [Required]
        public int PostID {get; set;}
        public int? ReplyCommentID {get; set;}
        [StringLength(260)]
        [Required]
        public string commented {get; set;} = string.Empty;
        [Display(Name = "Comment Time")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime commentTime {get; set;}
      }
  }