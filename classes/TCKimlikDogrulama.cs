using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HackatonAnketApp.classes
{
    public class TCKimlikDogrulama
    {

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
        public partial class Envelope
        {

            private EnvelopeBody bodyField;

            /// <remarks/>
            public EnvelopeBody Body
            {
                get
                {
                    return this.bodyField;
                }
                set
                {
                    this.bodyField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public partial class EnvelopeBody
        {

            private TCKimlikNoDogrula tCKimlikNoDogrulaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://tckimlik.nvi.gov.tr/WS")]
            public TCKimlikNoDogrula TCKimlikNoDogrula
            {
                get
                {
                    return this.tCKimlikNoDogrulaField;
                }
                set
                {
                    this.tCKimlikNoDogrulaField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tckimlik.nvi.gov.tr/WS")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tckimlik.nvi.gov.tr/WS", IsNullable = false)]
        public partial class TCKimlikNoDogrula
        {

            private ulong tCKimlikNoField;

            private string adField;

            private string soyadField;

            private ushort dogumYiliField;

            /// <remarks/>
            public ulong TCKimlikNo
            {
                get
                {
                    return this.tCKimlikNoField;
                }
                set
                {
                    this.tCKimlikNoField = value;
                }
            }

            /// <remarks/>
            public string Ad
            {
                get
                {
                    return this.adField;
                }
                set
                {
                    this.adField = value;
                }
            }

            /// <remarks/>
            public string Soyad
            {
                get
                {
                    return this.soyadField;
                }
                set
                {
                    this.soyadField = value;
                }
            }

            /// <remarks/>
            public ushort DogumYili
            {
                get
                {
                    return this.dogumYiliField;
                }
                set
                {
                    this.dogumYiliField = value;
                }
            }
        }
        public string GetTCKimlikDogrulama(ulong TCKimlikNo, String Ad, String Soyad, ushort DogumYili)
        {
            TCKimlikDogrulama.TCKimlikNoDogrula tcKimlikDogrulama = new TCKimlikDogrulama.TCKimlikNoDogrula();
            tcKimlikDogrulama.TCKimlikNo = TCKimlikNo;
            tcKimlikDogrulama.Ad = Ad;
            tcKimlikDogrulama.Soyad = Soyad;
            tcKimlikDogrulama.DogumYili = DogumYili;

            TCKimlikDogrulama.EnvelopeBody tcKimlikEnvelopeBody = new TCKimlikDogrulama.EnvelopeBody();
            tcKimlikEnvelopeBody.TCKimlikNoDogrula = tcKimlikDogrulama;

            TCKimlikDogrulama.Envelope tcKimlikEnvelope = new TCKimlikDogrulama.Envelope();
            tcKimlikEnvelope.Body = tcKimlikEnvelopeBody;

            XmlSerializer xsSubmit = new XmlSerializer(typeof(TCKimlikDogrulama.Envelope));
            var subReq = new TCKimlikDogrulama.Envelope();
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, tcKimlikEnvelope);
                    xml = sww.ToString();
                }
            }

            XDocument doc = XDocument.Parse(xml);

            String sDoc = doc.ToString();

            byte[] byteArray = Encoding.UTF8.GetBytes(sDoc);

            CookieContainer cookies = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx");
            //request.CookieContainer = cookies;
            //request.Timeout = 999999;

            request.Method = "POST";
            request.ContentType = "text/xml;charset=\"utf-8\"";

            request.ContentLength = byteArray.Length;

            request.Headers.Add("SOAPAction", "http://tckimlik.nvi.gov.tr/WS/TCKimlikNoDogrula");

            Stream dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                String status = ((HttpWebResponse)response).StatusDescription;

                reader.Close();
                dataStream.Close();
                response.Close();

                if (responseFromServer.Contains("<TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult>"))
                {

                    return "tamam";
                }
                else
                {
                    return "Başarısız.";
                }
            }
            catch (Exception ex)
            {
                return "TC Kimlik No Doğrulanamadı."+ex.ToString();
            }
        }
    }
}