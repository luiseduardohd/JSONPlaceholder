using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONPlaceholderApp.WebApplication.Entities
{
    public class Post 
    {
        public Post()
        {
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }

    }
}