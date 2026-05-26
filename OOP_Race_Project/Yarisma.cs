using System;
using System.Collections.Generic;
using System.IO;

namespace Yarisma
{
    public class Yarisma
    {
        private List<IYarismaci> yarismacilar;
        private Pist yarismaPisti;

       
        public Yarisma(string yarismaciDosyasiYolu,uint pistUzunlugu)
        {
            yarismacilar=new List<IYarismaci>();
            yarismaPisti=new Pist(pistUzunlugu);

            string[] satirlar=File.ReadAllLines(yarismaciDosyasiYolu);

            foreach(string satir in satirlar)
            {
                string[] parcalar=satir.Split(' ');

                if(parcalar.Length < 3)
                    continue;

                int no=int.Parse(parcalar[0]);
                string isim=parcalar[1];
                
                string tur = parcalar[2].ToUpper(); //buyuk kucuk harf cakismasini onlemek icin

                IYarismaci yeniYarismaci=null;

                
                if(tur=="CAKAL")
                    yeniYarismaci=new Cakal(isim,no,yarismaPisti);
                else if(tur=="DEVEKUSU")
                    yeniYarismaci=new DeveKusu(isim,no,yarismaPisti);
                else if(tur=="MEKANIKFIL")
                    yeniYarismaci=new MekanikFil(isim,no,yarismaPisti);
                else if(tur=="SALYANBOT")
                    yeniYarismaci=new SalyanBot(isim,no,yarismaPisti);

                if (yeniYarismaci!=null)
                {
                    yarismacilar.Add(yeniYarismaci);
                    yarismaPisti.YarismaciEkle(yeniYarismaci);
                }
            }
        }

     
        public void Baslat()
        {
      
            foreach(var y in yarismacilar){
                y.Konum=0;
                if(y is DeveKusu dk) dk.Paralize=false;
            }

            bool bitti=false;
            while(!bitti) {
             
                yarismaPisti.KonumGuncelle(yarismacilar); 

                foreach(var y in yarismacilar) {
                    if(y.Konum>=yarismaPisti.PistUzunlugu)
                    {y.Konum = (int)yarismaPisti.PistUzunlugu;
                        bitti=true;
                      
                    }
                }
            }
        }

      
        public void KonumlariYazdir()
        {
           
            for(int i=0;i<yarismacilar.Count-1;i++) {
                for(int j=0;j<yarismacilar.Count-i-1;j++) {
                    if(yarismacilar[j].Konum<yarismacilar[j+1].Konum){
                        var temp=yarismacilar[j];
                        yarismacilar[j]= yarismacilar[j+1];
                        yarismacilar[j+1]=temp;
                    }
                }
            }

            foreach(var y in yarismacilar)
            {
              
                Console.WriteLine($"{y.Konum} :: {y.YarismaciNo}, {y.Isim}");
            } Console.WriteLine();
        }
    }
}