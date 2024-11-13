using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchulungQotd.Shared.Models
{
    public class AuthorForCreateViewModel : AuthorBaseViewModel
    {
        //File
        public IFormFile? Photo { get; set; }
    }
}
