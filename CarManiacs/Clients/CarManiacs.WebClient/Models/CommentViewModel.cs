using System;

namespace CarManiacs.WebClient.Models
{
    public class CommentViewModel
    {
        public string UserId { get; set; }

        public string UserFullName { get; set; }

        public string Comment { get; set; }

        public DateTime PublishDate { get; set; }
    }
}