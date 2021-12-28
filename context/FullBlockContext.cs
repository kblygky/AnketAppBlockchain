using HackatonAnketApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HackatonAnketApp.context
{
    public class FullBlockContext:DbContext
    {
        public DbSet<tblAnket> quests { get; set; }
        public DbSet<tblSecenek> options { get; set; }
        public DbSet<tblOy> votes { get; set; }
        public DbSet<tblBlock> blocks { get; set; }
        public DbSet<tblKullanici> users { get; set; }
    }
}