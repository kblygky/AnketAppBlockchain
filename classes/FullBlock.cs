using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackatonAnketApp.classes
{
    public class FullBlock
    {
        public int voteId { get; set; }//oyId
        public int userId { get; set; }//kId
        public int optionId { get; set; }//secenekId
        public string optionStr { get; set; }//secenek
        public DateTime date { get; set; }//oyTarih
        public int blockNo { get; set; }//blockNo
        public int nonce { get; set; }//nonce
        public int questId { get; set; }//anketId
        public string questName { get; set; }//AnketAd
        public string prevHash { get; set; }//prevHash
        public string blockHash { get; set; }//blockHash
    }
}