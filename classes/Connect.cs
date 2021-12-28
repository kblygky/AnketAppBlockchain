﻿
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

        public void AddVote(int uId, int chooseId,int questId)
        {

            tblOy vote = new tblOy()
            {
                kId = uId,
                secenekId = chooseId,
                oyTarih = DateTime.Now
            };

            /*api ile çekilicek*/
            int nonce = 1234532;
            string blockHash= "sonraskdjflksdjfkljsdflkjdslkfjksd";

            /*veritabanından çekilicek son blockun numarası çekilicek*/
            int blockNo = 1;
            string prevHash = "öncekiskdjflksdjfkljsdflkjdslkfjksd";


            tblBlock block = new tblBlock()
            {
                blockNo = blockNo,
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
            string query = "SELECT k.adSoyad, o.oyId, k.kId, s.secenekId, s.secenek, o.oyTarih, b.blockNo,b.nonce,a.anketId,a.anketAd,b.prevHash,b.blockHash " +
                "FROM tblBlock AS b INNER JOIN " +
                "tblOy AS o ON b.oyId = o.oyId INNER JOIN " +
                "tblKullanici AS k ON o.kId = k.kId INNER JOIN " +
                "tblSecenek AS s ON s.secenekId = o.secenekId INNER JOIN " +
                "tblAnket AS a ON a.anketId = s.anketId where a.anketId=" + questId;




            var deneme = db.tblBlock.SqlQuery(query).SingleOrDefaultAsync();

            return null;
        }
    }
}