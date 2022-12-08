using System;
using System.ComponentModel.DataAnnotations;

  namespace Final3312
  {
    //this is a model of the users
      public class user
      {
        public int UserID {get; set;}// This is the "primary key"
        [StringLength(30)]
        [Required]
        public string username {get; set;} = string.Empty;
        [StringLength(260)]
        [Required]
        public string password {get; set;} = string.Empty;
      }
  }