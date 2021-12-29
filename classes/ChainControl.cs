using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackatonAnketApp.classes
{
    public class ChainControl
    {
        public List<int> control(List<FullBlock> chain)
        {
            List<int> erorBlock = new List<int>();

            Crypto crypto = new Crypto();

            foreach (var item in chain)
            {
                if (item.blockNo != 1)
                {
                    if (crypto.Hashing(item.DataConstruct())[1] != item.blockHash)
                    {
                        erorBlock.Add(item.blockNo);
                    }
                }
            }

            return erorBlock;
        }
    }
}