using System;
using Microsoft.EntityFrameworkCore;

namespace Final3312 // You can use any namespace you like. Remember to add the using directive to Program.cs
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
			: base(options)
		{
		}
        public DbSet<user> user {get; set;}=null!;
        public DbSet<like> like {get; set;}=null!;
        public DbSet<post> post {get; set;}=null!;
        public DbSet<comment> comment {get; set;}=null!;
    }
}