using System;

namespace Yarisma{
public class SalyanBot : Robot
{
    public SalyanBot(string isim,int no,Pist pist) : base(isim,no,pist){
    }

    public override void HareketEt()//salyanbot icin ozel hareket et metodu
    {
        if(!Bozuldu)//robot bozulmadiysa 
        {
            //salyanbot her turda 1 birim ilerler
            Konum+=1;

            if(Konum<0)
                Konum=0;

            Console.WriteLine(Konum + " :: " + YarismaciNo + ", " + Isim);
        }
    }
}
}