﻿using System;
using System.Collections.Generic;

namespace EAI.Template.Data
{
    public partial class ApplicationKeys
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int OstypeId { get; set; }
        public string AppKey { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
