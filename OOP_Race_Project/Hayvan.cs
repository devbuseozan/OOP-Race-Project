using System;

namespace Yarisma{
public abstract class Hayvan : IYarismaci
{
    protected static Random rng=new Random(); // Alt siniflarin ortak kullanabilmesi icin static ve protected
    public string Isim{get;set;}
    public int Konum{get;set;}
    public int YarismaciNo{get;set;}

    protected Pist yarismaPisti;

    public Hayvan(string isim,int no,Pist pist)
    {
        Isim=isim;
        YarismaciNo=no;
        yarismaPisti=pist;
        Konum=0;
    }

    public abstract void HareketEt();

    public void YarismayaKatil()
    {
        // Yarismaci baslangicta sifirdan baslar
        Console.WriteLine(Isim + " isimli hayvan yarismaya 0. konumdan dahil oldu.");
    }
}
}