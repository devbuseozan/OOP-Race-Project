using System;

namespace Yarisma{
public abstract class Robot : IYarismaci
{
    protected static Random rng=new Random();//robotlarin ortak kullanimi icin

    public string Isim {get;set;}
    public int Konum {get;set;}
    public int YarismaciNo {get;set;}

    public bool Bozuldu {get;set;}

    protected Pist yarismaPisti;//miras alanlar gorebilsin

    public Robot(string isim,int no,Pist pist)
    {
        Isim=isim;
        YarismaciNo=no;
        yarismaPisti=pist;
        Konum=0;
        Bozuldu=false;
    }

    public abstract void HareketEt();

    public void YarismayaKatil()
    {
        Console.WriteLine(Isim + " isimli robot yarismaya dahil oldu.");
    }
}
}