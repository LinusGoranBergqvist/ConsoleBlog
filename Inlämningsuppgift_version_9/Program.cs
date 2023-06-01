using Inlämningsuppgift_version_9;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

MyDbContext Context = new MyDbContext();

BlogPost blogPost = new BlogPost();

Category newcategory = new Category();



bool start = true;

while (start)
{
    Console.WriteLine("");
    Console.WriteLine("Blog Menu:");
    Console.WriteLine("1. Display all posts");
    Console.WriteLine("2. Display the names of all the categories");
    Console.WriteLine("3. Add new blog post");
    Console.WriteLine("4. Add a new category");
    Console.WriteLine("5. Display all the blog titles from a category");
    Console.WriteLine("6. Add an existing blog post to an existing category");
    Console.WriteLine("q. Exit");
    Console.WriteLine("");

    string Input = Console.ReadLine();

    if (Input == "q")
    {
        start = false;
    }
    else if (Input == "1")
    {
        var blogposts = Context.BlogPosts;
        Console.WriteLine("Detta är alla Blog Inlägg");
        foreach (BlogPost p in blogposts)
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine($"Titel: {p.Title}");
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"{p.Text}");
            Console.WriteLine("_______________________________________________________________________________");
        }
    }
    else if (Input == "2")
    {
        var categorys = Context.Categories;
        Console.WriteLine("Detta är alla de olika Kategorierna");
        foreach (Category p in categorys)
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"{p.Name}");
            Console.WriteLine("_______________________________________________________________________________");
        }
        //Console.WriteLine("Välja vilken Category du vill se alla blog posts ifrån från de över");
        //string categoryval = Console.ReadLine();
        //List<Category> BlogCategory = Context.BlogPosts.Where(x => x.CategoryId);

    }
    else if (Input == "3")
    {
        Console.Write("Add a title for your post: ");
        string blogtitle = Console.ReadLine();
        Console.Write("Add the text for your post: ");
        string blogtext = Console.ReadLine();
        Console.Write("För att lägga till en kategori till din Post gå in på det meny valet");
        Console.WriteLine("");

        var blogpost = new BlogPost
        {
            Title = blogtitle,
            Text = blogtext
        };

        Context.BlogPosts.Add(blogpost);

        Context.SaveChanges();
    }
    else if (Input == "4")
    {
        Console.Write("Add the name for this new category: ");
        string NewCategory = Console.ReadLine();


        //kollar om det finns en kategori  med samma namn redan
        Category CategoryAuthentication = Context.Categories.FirstOrDefault(x => x.Name == NewCategory);


        if (CategoryAuthentication != null)
        {
            //List<Category> BlogPostCategory = Context.BlogPosts.Include(x => x.Categories ==);
            Console.WriteLine("Kategorin finns redan");
            Console.WriteLine("");

        }

        else
        {
            var newCategory = new Category
            {
                Name = NewCategory
            };

            Context.Categories.Add(newCategory);
            Context.SaveChanges();
        }


    }
    else if (Input == "5")
    {
        var categorys = Context.Categories;
        Console.WriteLine("Detta är alla olika Kategorierna Id");
        foreach (Category p in categorys)
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"Id: {p.Name}");
            Console.WriteLine("_______________________________________________________________________________");
        }




        Console.WriteLine("Enter Category ID");
        int categorysId = Convert.ToInt32(Console.ReadLine());

        BlogPost CurrentBlogPost = Context.BlogPosts.FirstOrDefault(x => x.Id == categorysId);
        if (CurrentBlogPost == null)
        {
            Console.WriteLine("Fanns ej");
        }
        else
        {
            Category ReturnCategoryId = Context.Categories.Where(x => x.Id == categorysId).First();
            Console.WriteLine($"Id: {ReturnCategoryId.Id}");
            Console.WriteLine($"Titel: {ReturnCategoryId.Name}");
            //Console.WriteLine($" {ReturnCategoryId.Text}");
            Console.WriteLine($"BlogPosts under denna kategori" +
                $" {ReturnCategoryId.BlogPosts}");

            Console.ReadLine();
        }
        Context.SaveChanges();





        //-----------------------------------------------------------------------------------------------------------------




        //Console.WriteLine("Enter Blog ID");
        //int BlogPostId = Convert.ToInt32(Console.ReadLine());
        //Category CurrentBlogPosts = Context.Categories.FirstOrDefault(x => x.Id == BlogPostId);

        //blogAddId.Id = BlogPostId;
        //CurrentBlogPosts.BlogPosts = new List<BlogPost>();
        //CurrentBlogPosts.BlogPosts.Add(blogAddId);
        //Context.Categories.Update(CurrentBlogPosts);




    }





    else if (Input == "6")
    {

        Category newCategory = new Category();
        BlogPost newBlogPost = new BlogPost();
        Console.WriteLine("Enter Category ID");
        int CategoryInput = Convert.ToInt32(Console.ReadLine());

        Category ExistingCategory = Context.Categories.FirstOrDefault(x => x.Id == CategoryInput);

        ExistingCategory.BlogPosts = new List<BlogPost>
        {
            newBlogPost
        };
        Context.Categories.Update(ExistingCategory);
        Context.SaveChanges();



        Console.WriteLine("Enter Category ID");
        int BlogPostInput = Convert.ToInt32(Console.ReadLine());
        BlogPost ExistingBlogPost = Context.BlogPosts.FirstOrDefault(x => x.Id == BlogPostInput);

        ExistingBlogPost.Categories = new List<Category>
        {
            newCategory
        };
        Context.BlogPosts.Update(ExistingBlogPost);

        //var categorys = Context.Categories;
        //Console.WriteLine("Detta är alla de olika Kategorierna");
        //foreach (Category p in categorys)
        //{
        //    Console.WriteLine("-------------------------------------------------------------------------------");
        //    Console.WriteLine($"Id: {p.Id}");
        //    Console.WriteLine($"{p.Name}");
        //    Console.WriteLine("_______________________________________________________________________________");
        //}

        //Console.WriteLine("Enter Category ID ");
        //int CategoryInput = Convert.ToInt32(Console.ReadLine());

        //BlogPost CurrentBlogPost = Context.BlogPosts.FirstOrDefault(x => x.Id == CategoryInput);
        //if (CurrentBlogPost == null)
        //{

        //    Console.WriteLine("Den Id fanns ej");

        //}
        //else
        //{
        //    Category ReturnCategoryId = Context.Categories.Where(x => x.Id == CategoryInput).First();
        //    Console.WriteLine($"Du valde Id: {ReturnCategoryId.Id}");
        //    Console.WriteLine($"Som har Titel: {ReturnCategoryId.Name}");

        //    Console.ReadLine();
        //}





        //var blogposts = Context.BlogPosts;
        //Console.WriteLine("Detta är alla Blog Inlägg");
        //foreach (BlogPost p in blogposts)
        //{
        //    Console.WriteLine("-------------------------------------------------------------------------------");
        //    Console.WriteLine($"Titel: {p.Title}");
        //    Console.WriteLine($"Id: {p.Id}");
        //    Console.WriteLine($"{p.Text}");
        //    Console.WriteLine("_______________________________________________________________________________");
        //}


        //Console.WriteLine("Enter Category ID ");
        //int BlogPostInput = Convert.ToInt32(Console.ReadLine());
        //Category CurrentCategorie = Context.Categories.FirstOrDefault(x => x.Id == BlogPostInput);
        //if (CurrentBlogPost == null)
        //{

        //    Console.WriteLine("Den Id fanns ej");

        //}
        //else
        //{
        //    BlogPost ReturnBlogId = Context.BlogPosts.Where(x => x.Id == BlogPostInput).First();
        //    Console.WriteLine($"Du valde Id: {ReturnBlogId.Id}");
        //    Console.WriteLine($"Som har Titel: {ReturnBlogId.Title}");
        //    Console.WriteLine($"Och texten: {ReturnBlogId.Text}");

        //    Console.ReadLine();
        //}




        //var blogposts = Context.BlogPosts;
        //Console.WriteLine("Välj Ett Blog Inlägg med hjälp av Id");
        //foreach (BlogPost p in blogposts)
        //{
        //    Console.WriteLine("-------------------------------------------------------------------------------");
        //    Console.WriteLine($"Titel: {p.Title}");
        //    Console.WriteLine($"Id: {p.Id}");
        //    Console.WriteLine($"{p.Text}");
        //    Console.WriteLine("_______________________________________________________________________________");
        //}
        //Console.Write("Blog Val: ");
        //int blogId = Convert.ToInt32(Console.ReadLine());
        //BlogPost BlogCheck = Context.BlogPosts.FirstOrDefault(x => x.Id == blogId);
        //if (BlogCheck == null)
        //{
        //    Console.WriteLine("Du har inte angivit en tillgänglig blogpost");
        //}
        //else if (BlogCheck != null)
        //{
        //    List<BlogPost> CategoryBlog = Context.BlogPosts.Where(x => x.Id == blogId).ToList();
        //    //BlogPost blogPost1 = CategoryBlog.FirstOrDefault();
        //    var newCateId = new Category
        //    {
        //        //BlogPostId = blogId
        //    };
        //    Console.WriteLine($"Du har valt: {blogId}");
        //    Console.ReadLine();
        //}

        //Console.WriteLine("");

        //var categorys = Context.Categories;
        //Console.WriteLine("Välj Vilken kategori ditt inlägg ska tillhöra Kategorierna");
        //foreach (Category p in categorys)
        //{
        //    Console.WriteLine("-------------------------------------------------------------------------------");
        //    Console.WriteLine($"Id: {p.Id}");
        //    Console.WriteLine($"{p.Name}");
        //    Console.WriteLine("_______________________________________________________________________________");
        //}
        //Console.Write("Kategori Val: ");
        //int cateId = Convert.ToInt32(Console.ReadLine());
        //string cateId = Console.ReadLine();
        //Category CategoryCheck = Context.Categories.FirstOrDefault(x => x.Id == cateId);

        //if (CategoryCheck == null)
        //{
        //    Console.WriteLine("Du har inte angivit en tillgänglig blogpost");
        //}
        //else if (CategoryCheck != null)
        //{
        //    //newcategory.Id = cateId;

        //    Console.WriteLine($"Du har valt: {cateId}");
        //    Console.ReadLine();
        //}

        //Console.WriteLine($"Adding Blog Id: {blogId}" +
        //    $"\nWith Category Id: {cateId}");
        //Console.ReadLine();
        //Context.Categories.Update(CategoryCheck);
        //Context.SaveChanges();





    }
    else
    {
        Console.WriteLine("Du angav fel");
    }
}

