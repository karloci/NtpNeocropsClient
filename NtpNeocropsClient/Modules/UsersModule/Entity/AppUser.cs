﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NtpNeocropsClient.Modules.FarmModule.Entity;

namespace NtpNeocropsClient.Modules.Users.Entity
{
    [Serializable]
    public class AppUser
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Farm UserFarm { get; set; } = new Farm();
    }
}
