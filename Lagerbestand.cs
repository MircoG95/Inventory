using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Lagerbestand
{
    
    [DataContract]
    class Lagerbestand
    {
        //Felder
        private int schraubenAnzahl;
        private int mutternAnzahl;
        private int unterlegAnzahl;
        private int dreherAnzahl;

        //Eigenschaften
        [DataMember]
        public int SchraubenAnzahl
        {
            get { return schraubenAnzahl; }
            set
            {
                schraubenAnzahl = value;
                OnSchraubenAendern();
            }
        }
        [DataMember]
        public int MutternAnzahl
        {
            get { return mutternAnzahl; }
            set
            {
                mutternAnzahl = value;
                OnMutternAendern();
            }
        }
        [DataMember]
        public int UnterlegAnzahl
        {
            get { return unterlegAnzahl; }
            set
            {
                unterlegAnzahl = value;
                OnUnterlegAendern();
            }
        }
        [DataMember]
        public int DreherAnzahl
        {
            get { return dreherAnzahl; }
            set
            {
                dreherAnzahl = value;
                OnDreherAendern();
            }
        }

        //Konstruktor
        public Lagerbestand() { }                 

        //Events
        public event EventHandler schraubenAendern;
        public event EventHandler mutternAendern;
        public event EventHandler unterlegAendern;
        public event EventHandler dreherAendern;

        //statische Felder
        static string pfad = @"C:\Test\Lager.json";

        //statische Methoden
        public static Lagerbestand DatenEinlesen()
        {
            Lagerbestand temp;

            if (File.Exists(pfad))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Lagerbestand));

                using (FileStream fs = new FileStream(pfad, FileMode.Open))
                {
                    temp = (Lagerbestand)ser.ReadObject(fs);
                }
            }
            else
            {
                temp = new Lagerbestand();
            }

            return temp;
        }
        public static void DatenSchreiben(Lagerbestand lb)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Lagerbestand));

            using (FileStream fs = new FileStream(pfad, FileMode.Create))
            {
                ser.WriteObject(fs, lb);
            }
        }

        //Methoden
        protected virtual void OnSchraubenAendern()
        {
            schraubenAendern?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnMutternAendern()
        {
            mutternAendern?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnUnterlegAendern()
        {
            unterlegAendern?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnDreherAendern()
        {
            dreherAendern?.Invoke(this, EventArgs.Empty);
        }
    }
}
