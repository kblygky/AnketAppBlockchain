using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackatonAnketApp.classes
{
    public class FullBlock
    {
        public int voteId { get; set; }
        public int userId { get; set; }
        public int optionId { get; set; }
        public string optionStr { get; set; }
        public DateTime date { get; set; }
        public int blockNo { get; set; }
        public int nonce { get; set; }
        public string prevHash { get; set; }
        public  string  blockHash { get; set; }
        public int questId { get; set; }
        public string questName { get; set; }
    }
}