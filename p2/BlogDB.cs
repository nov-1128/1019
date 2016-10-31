namespace p2
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BlogDB : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“BlogDB”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“p2.BlogDB”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“BlogDB”
        //连接字符串。
        public BlogDB()
            : base("name=BlogDB")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

         public virtual DbSet<Blog> Blogs { get; set; }

        public virtual DbSet<BlogArticle> BlogArticles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var blogTable = modelBuilder.Entity<Blog>();
            var blogArtticleTable = modelBuilder.Entity<BlogArticle>();
            blogTable.HasKey(o => o.ID);
            blogArtticleTable.HasKey(o => o.ID);
            base.OnModelCreating(modelBuilder);
        }

    }

    public class BlogArticle
    {
        public int ID { get; set; }
        public string BlogID { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreTime { get; set; }
    }
        public class Blog
        {
            public int ID { get; set; }
            public string Title { get; set; }
        }


        //public class MyEntity
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}
    }