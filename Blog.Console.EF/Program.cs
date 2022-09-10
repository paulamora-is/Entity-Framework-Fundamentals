using Blog.Console.EF.Data;

namespace Blog.Console.EF
{
    public static class Program
    {
        public static void Main()
        {
            using var context = new BlogDataContext();
        }
    }
}
