
using HackatonAnketApp.context;
using HackatonAnketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackatonAnketApp.classes
{
    public class Connect
    {
        anketAppEntities3 db = new anketAppEntities3();

        /*kullanıcı kayıt olma kısmı*/
        public void AddUser(string tc, string password, string name, string tel, string address, int age, string education, int rank, string mail)
        {
            tblKullanici user = new tblKullanici()
            {
                tc = tc,
                sifre = password,
                adSoyad = name,
                tel = tel,
                adres = address,
                yas = age,
                ogrenimDurum = education,
                durum = rank,
                mail = mail
            };
            db.tblKullanici.Add(user);
            db.SaveChanges();
        }

        public void AddVote(int uId, int chooseId, int questId)
        {
            Connect connect = new Connect();

            //DateTime now = ;
            //int h = now.Hour;
            //int m = now.Minute;
            //int s = now.Second;

            tblOy vote = new tblOy()
            {
                kId = uId,
                secenekId = chooseId,
                oyTarih = DateTime.Now
            };



            /*api ile çekilicek*/
            int nonce = 1234532;
            string blockHash = "sonraskdjflksdjfkljsdflkjdslkfjksd";

            /*veritabanından çekilicek son blockun numarası çekilicek*/
            string prevHash = connect.ReturnQuestChain(questId).OrderBy(x => x.blockNo).Last().blockHash;
            int blockNo = connect.ReturnQuestChain(questId).OrderBy(x => x.blockNo).Last().blockNo;

            tblBlock block = new tblBlock()
            {
                blockNo = blockNo + 1,
                nonce = nonce,
                prevHash = prevHash,
                blockHash = blockHash,
                tblOy = vote
            };

            db.tblBlock.Add(block);
            db.SaveChanges();
        }

        public void AddQuest(int categoryId, string questName, string questInfo, List<tblSecenek> options)
        {

            tblAnket quest = new tblAnket()
            {
                kategoriId = categoryId,
                anketAd = questName,
                aciklama = questInfo,
                tblSecenek = options
            };

            db.tblAnket.Add(quest);
            db.SaveChanges();
        }

        public tblKullanici CheckLogin(string mail, string password)
        {
            var user = db.tblKullanici.FirstOrDefault(a => a.mail == mail && a.sifre == password);

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public void UserUpdate(string tc, string password, string name, string tel, int age, string education, string mail, int uId)
        {
            tblKullanici user = db.tblKullanici.FirstOrDefault(x => x.kId == uId);
            user.adSoyad = name;
            user.tc = tc;
            user.sifre = password;
            user.tel = tel;
            user.yas = age;
            user.ogrenimDurum = education;
            user.mail = mail;
            db.SaveChanges();
        }

        public List<tblAnket> ReturnQuestList()
        {
            var Quests = db.tblAnket.ToList();
            foreach (var item in Quests)
            {
                item.tblSecenek = db.tblSecenek.Where(x => x.anketId == item.anketId).ToList();
            }

            return Quests;
        }

        public List<FullBlock> ReturnUserBlocks(int uId)
        {
            List<FullBlock> blocks = new List<FullBlock>();

            var votes = db.tblOy.Where(x => x.kId == uId).ToList();
            foreach (var item in votes)
            {
                var block = db.tblBlock.FirstOrDefault(x => x.oyId == item.oyId);
                var option = db.tblSecenek.FirstOrDefault(x => x.secenekId == item.secenekId);
                var quest = db.tblAnket.FirstOrDefault(x => x.anketId == option.anketId);
                FullBlock fullBlock = new FullBlock()
                {
                    voteId = item.oyId,
                    userId = Convert.ToInt32(item.kId),
                    optionId = Convert.ToInt32(item.secenekId),
                    optionStr = option.secenek,
                    questId = Convert.ToInt32(option.anketId),
                    questName = quest.anketAd,
                    date = Convert.ToDateTime(item.oyTarih),
                    blockNo = Convert.ToInt32(block.blockNo),
                    nonce = Convert.ToInt32(block.nonce),
                    prevHash = block.prevHash,
                    blockHash = block.blockHash
                };
                blocks.Add(fullBlock);
            }
            return blocks;
        }

        public List<FullBlock> ReturnQuestChain(int questId)
        {
            //string query = "SELECT k.adSoyad, o.oyId, k.kId, s.secenekId, s.secenek, o.oyTarih, b.blockNo,b.nonce,a.anketId,a.anketAd,b.prevHash,b.blockHash " +
            //    "FROM tblBlock AS b INNER JOIN " +
            //    "tblOy AS o ON b.oyId = o.oyId INNER JOIN " +
            //    "tblKullanici AS k ON o.kId = k.kId INNER JOIN " +
            //    "tblSecenek AS s ON s.secenekId = o.secenekId INNER JOIN " +
            //    "tblAnket AS a ON a.anketId = s.anketId where a.anketId=" + questId;


            //var deneme = db.tblBlock.SqlQuery(query).ToList();
            //return null;
            //var result =
            //        from car in db.tblCars.Where(c => c.Id == carId)
            //        join brand in db.tblBrands on car.BrandId equals brand.Id
            //        join color in db.tblColors on car.ColorId equals color.Id
            //        select new CarDetailDto
            //        {
            //            CarId = car.Id,
            //            CarName = car.Name,
            //            BrandName = brand.Name,
            //            ColorName = color.Name,
            //            DailyPrice = car.DailyPrice,
            //            ModelYear = car.ModelYear
            //        };
            //return result.SingleOrDefault();



            //var x = from block in db.Set<tblBlock>()
            //            join oy in db.Set<tblOy>() on block.oyId equals oy.oyId
            //            join kullanici in db.Set<tblKullanici>() on oy.kId equals kullanici.kId
            //            join secenek in db.Set<tblSecenek>() on secenek.secenekId equals oy.secenekId
            //            join anket in db.Set<tblAnket>() on anket.anketId equals secenek.anketId
            //questId.ToString();

            //using (FullBlockContext fullBlockContext = new FullBlockContext())
            //{
            //    var result =
            //    from b in fullBlockContext.blocks
            //    join o in fullBlockContext.votes on b.oyId equals o.oyId
            //    join k in fullBlockContext.users on o.kId equals k.kId
            //    join s in fullBlockContext.options on o.secenekId equals s.secenekId
            //    join a in fullBlockContext.quests.Where(c => c.anketId == 2) on s.anketId equals a.anketId
            //    select new FullBlock
            //    {
            //        voteId = o.oyId,
            //        userId = k.kId,
            //        optionId = o.oyId,
            //        optionStr = s.secenek,
            //        date = (DateTime)o.oyTarih,
            //        blockNo = (int)b.blockNo,
            //        nonce = (int)b.nonce,
            //        questId = a.anketId,
            //        questName = a.anketAd,
            //        prevHash = b.prevHash,
            //        blockHash = b.blockHash
            //    };
            //    var x=result.ToList();
            //    return x;
            //}

            var options = db.tblSecenek.Where(x => x.anketId == questId).ToList();

            foreach (var option in options)
            {
                option.tblOy = db.tblOy.Where(x => x.secenekId == option.secenekId).ToList();
                foreach (var vote in option.tblOy)
                {
                    vote.tblBlock = db.tblBlock.Where(x => x.oyId == vote.oyId).ToList();
                }
            }

            for (int i = options.Count() - 1; i >= 0; i--)
            {
                if (options[i].tblOy.Count == 0)
                {
                    options.RemoveAt(i);
                }
            }

            List<FullBlock> chain = new List<FullBlock>();

            foreach (var item in options)
            {
                string questName = db.tblAnket.Where(x => x.anketId == item.anketId).FirstOrDefault().anketAd;
                foreach (var vote in item.tblOy)
                {

                    FullBlock block = new FullBlock()
                    {
                        voteId = item.secenekId,
                        userId = Convert.ToInt32(item.tblOy.First().kId),
                        optionId = item.secenekId,
                        optionStr = item.secenek,
                        date = item.tblOy.First().oyTarih,
                        blockNo = Convert.ToInt32(vote.tblBlock.First().blockNo),
                        nonce = Convert.ToInt32(vote.tblBlock.First().nonce),
                        questId = Convert.ToInt32(item.anketId),
                        questName = questName,
                        prevHash = vote.tblBlock.First().prevHash,
                        blockHash = vote.tblBlock.First().blockHash
                    };
                    chain.Add(block);
                }

            }

            return chain;

        }
    }
}