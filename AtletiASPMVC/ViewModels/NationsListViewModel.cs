using AtletiASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtletiASPMVC.ViewModels
{
    public class NationsListViewModel
    {
        public int page { get; set; }
        public int pages { get; set; }
        public List<Nationality> nations { get; set; }

    }
}