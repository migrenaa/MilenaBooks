using BookStore.DATA.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStore.Service.Mapping;
using AutoMapper;
using BookStore.DATA.ADO.NET;

namespace BookStore.Service.Models
{
    public class BooksInStoresViewModel : IMapFrom<BooksInStore>, IMapTo<BooksInStores>
    {
        [Required]
        public string Book { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Store { get; set; }

    }
}
