using System;
using System.ComponentModel.DataAnnotations;

  namespace Final3312
  {
    //this is a model of the post
      public class post
      {
        public int PostID {get; set;}// This is the "primary key"
        [Display(Name = "Poster")]
        [Required]
        public int UserID {get; set;}
        [Display(Name = "Post")]
        [StringLength(260)]
        [Required]
        public string postedPath {get; set;} = string.Empty;
        [Display(Name = "Post Time")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime postTime {get; set;}
      }
  }