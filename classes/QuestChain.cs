using HackatonAnketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackatonAnketApp.classes
{
    public class QuestChain
    {
        public tblAnket quest { get; set; }
        public List<FullBlock> blocks{ get; set; }
        public List<int> errorBlocks { get; set; }
    }
}