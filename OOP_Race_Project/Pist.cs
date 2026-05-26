using System;
using System.Collections.Generic;

namespace Yarisma
{
    public class Pist
    {

        private List<IYarismaci>yarismacilar=new List<IYarismaci>();
        private Random rnd=new Random();

      
        public uint PistUzunlugu{get;set;}

        public Pist(uint uzunluk)
        {  PistUzunlugu=uzunluk;
        }

        public void YarismaciEkle(IYarismaci y)
        {
            yarismacilar.Add(y);
        }

     
        public void KonumGuncelle(List<IYarismaci> liste)
        {
            foreach(var y in liste)
            {
                int eskiKonum=y.Konum;
                y.HareketEt();

                if(y.Konum < 0)y.Konum=0;


                if(eskiKonum> 0||y.Konum>0)//baslangicta birbirlerini etkileyemezler
                {
                    EtkilesimKontrolu(y,liste,eskiKonum);
                }
            }
        }

        private void EtkilesimKontrolu(IYarismaci hareketEden,List<IYarismaci>liste,int eski)
        {
            foreach(var hedef in liste)
            {
              
                if(hedef is DeveKusu dk &&dk.Konum==hareketEden.Konum &&eski<dk.Konum)
                {
                    if(hareketEden is Cakal&&rnd.Next(1,101)<=50)
                        dk.Paralize = true; // Çakal %50 ihtimalle durdurur
                    
                    else if(hareketEden is MekanikFil&&rnd.Next(1,101)<=20)
                        dk.Paralize=true; 
                }

               
                if(hareketEden is SalyanBot && hedef is Hayvan h&&h.Konum==hareketEden.Konum)
                {
                    if(rnd.Next(1,101)<=25)
                    {
                        h.Konum-=1;
                        if(h.Konum<0)h.Konum=0;
                    }
                }
            }
        }

        public void DurumuYazdir()
        {
      
        }
    }
}