using System;

namespace Yarisma{
public class MekanikFil : Robot
{
    public MekanikFil(string isim, int no, Pist pist) : base(isim, no, pist){
    }

    public override void HareketEt()//mekanik fil icin ozel hareket et metodu
    {
        if(!Bozuldu)// robot bozulmadiysa hareket eder
        { 
            int olasilik=rng.Next(1,101);

            if (olasilik <= 40) 
                Konum += 2;//yurume hareketi 2 ileri
            else if (olasilik <= 50) 
                Konum += 3;//kosma hareketi 3 ileri

            if(Konum<0)
                Konum=0;

            Console.WriteLine(Konum + " :: " + YarismaciNo + ", " + Isim);
        }
    }

    public void Ez(DeveKusu ezilen)// devekusunu sakatlama kurali
    {
        if(this.Konum==ezilen.Konum)
        {
            if(rng.Next(1,101)<=20) // %20 ihtimalle sakatlama
            {
                ezilen.Paralize =true;
            }
        }
    }
}
}