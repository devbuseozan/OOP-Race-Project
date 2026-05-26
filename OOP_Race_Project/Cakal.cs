using System;

namespace Yarisma{// her dosyayi ayni projede anlamasi icin
     public class Cakal : Hayvan
    {
        public Cakal(string isim, int no, Pist pist) : base(isim, no, pist){
        }

        public override void HareketEt()//cakala ozel hareketet metodu tanimlandi.
        {
            int olasilik=rng.Next(1, 101);

            if(olasilik<=30)
                Konum += 3;
            else if(olasilik<=80)
                Konum+=2;
            else 
                Konum-=4;

            if(Konum<0)Konum=0;


           Console.WriteLine(Konum + " :: " + YarismaciNo + ", " + Isim);
        }
        public void Avla(DeveKusu ezilen)
        {
            if(this.Konum==ezilen.Konum) // Aynı pozisyona gelirse 
            {
                if(rng.Next(1,101)<=50)
                {
                    ezilen.Paralize=true; // Devekuşunu paralize eder 
                }
            }
        }
    }
    }
