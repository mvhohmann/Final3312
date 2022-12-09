using System;
using System.ComponentModel.DataAnnotations;

  namespace Final3312
  {
    //this is a model of the likes
      public class like
      {
        public int LikeID {get; set;}// This is the "primary key"
        [Required]
        public int PostID {get; set;}
        [Required]
        public int UserID {get;set;}
        public int? CommentID {get; set;}
        [Required]
        //should be bool
        public int likes {get; set;}
      }
  }