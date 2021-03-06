﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceNET.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string[] AttachmentUrls { get; set; }
    }
}
