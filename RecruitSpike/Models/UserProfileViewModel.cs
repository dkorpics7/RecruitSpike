using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitSpike.Models
{
    public class UserProfileViewModel
    {
        public AspNetUser user { get; set; }
        public Profile profile { get; set; }
    }
}