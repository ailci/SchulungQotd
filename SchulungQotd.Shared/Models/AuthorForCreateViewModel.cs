using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SchulungQotd.Shared.Validations;

namespace SchulungQotd.Shared.Models
{
    public class AuthorForCreateViewModel : AuthorBaseViewModel
    {
        //[AllowedExtensions("jpg,jpeg,png,bmp,gif")]
        public IFormFile? Photo { get; set; }
    }
}
