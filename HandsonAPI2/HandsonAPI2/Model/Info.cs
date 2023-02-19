﻿using Microsoft.OpenApi.Models;
using System.ComponentModel;

namespace HandsonAPI2.Model
{
    public class Info : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
        public object Contact { get; set; }
         public object License { get; set; }
    }
}
