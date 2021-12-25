
using HackatonAnketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackatonAnketApp.classes
{
    public class Connect
    {
        anketAppEntities db = new anketAppEntities();

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
        /*kullanıcının oy verme kısmı*/
        public void AddVote(int uId, int chooseId, DateTime Date, int blockNo, int nonce, string prevHash, string blockHash)
        {/*
            tblOy vote = new tblOy()
            {
                kId = uId,
                secenekId = chooseId,
                oyTarih = Date
            };
            tblBlock block = new tblBlock();*/
        }

        public void AddQuest(int categoryId,string questName,string questInfo ,List<tblSecenek> options)
        {
            

            tblAnket quest = new tblAnket() {
                kategoriId = categoryId,
                anketAd=questName,
                aciklama=questInfo
            };

            db.tblAnket.Add(quest);
            db.SaveChanges();
        }

       /* public List<tblAnket> listQuest()
        {
            
        }*/

    }
}