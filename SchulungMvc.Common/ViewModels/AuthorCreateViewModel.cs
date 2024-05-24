using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchulungMvc.Common.ViewModels
{
    public class AuthorCreateViewModel : AuthorBaseViewModel
    {
        public IFormFile? Photo { get; set; }
    }
}
