using System;
namespace Yarisma{
public class DeveKusu : Hayvan
{
    public bool Paralize{get;set;}

    public DeveKusu(string isim,int no,Pist pist)
        : base(isim,no,pist)
    {
        Paralize=false;
    }

    public override void HareketEt()//deve kusu icin ozel hareket et metodu
    {
       if(!Paralize)// paralize olma durumu yoksa
            {
                int olasilik=rng.Next(1,101);

            if(olasilik<=50)       
                    Konum+=3;//kosma hareketi 3 ileri
            else if(olasilik<=70) 
                    Konum += 6;//hizli kosma hareketi 6 ileri
            else   
                    Konum-= 4;//kayma hareketi 4 geri

                if(Konum<0)
                Konum=0;


                Console.WriteLine(Konum + " :: " + YarismaciNo + ", " + Isim);
            }
        }
    }
}