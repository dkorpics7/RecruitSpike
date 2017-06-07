using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitSpike.Models
{
    public class ProfileStepViewModel
    {

        public Profile profile { get; set; }
        public Mainstep mainstep { get; set; }
        public Heading heading { get; set; }
        public Substep substep { get; set; }

    }
}