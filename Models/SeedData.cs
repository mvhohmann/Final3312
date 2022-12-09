using Microsoft.EntityFrameworkCore;

namespace Final3312
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBContext(
                serviceProvider.GetRequiredService<DbContextOptions<DBContext>>()))
            {
                // Look for any staff.
                if (!context.user.Any())
                {
                    context.user.AddRange(
                        new user{username="admin",password=Hash.hash256("admin","1")},
                        new user{username="test",password=Hash.hash256("test","2")}
                    );
                    context.SaveChanges();
                }
                // Look for any staff.
                if (!context.post.Any())
                {
                    context.post.AddRange(
                        new post{UserID=1,postedPath="Data/1.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/2.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/3.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/4.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/5.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/6.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/7.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/8.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/9.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/10.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/11.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/12.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/13.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/14.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/15.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/16.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/17.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/18.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/19.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/20.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/21.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/22.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/23.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/24.jpg",postTime=DateTime.Now},
                        new post{UserID=1,postedPath="Data/25.jpg",postTime=DateTime.Now}
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}