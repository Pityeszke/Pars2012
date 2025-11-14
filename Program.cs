using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Pars2012
{
    internal class Program
    {
        class Versenyző
        {
            public string Név;
            public string Csoport;
            public string NemzetEsKód;
            public string[] Dobások = new string[3];
            public Versenyző(string egysor)
            {
                string[] adatok = egysor.Split(';');
                Név = adatok[0];
                Csoport = adatok[1];
                NemzetEsKód = adatok[2];
                if (adatok[3] == "X")
                {
                    Dobások[0] = "X";
                }
                else
                {
                    Dobások[0] = adatok[3];
                }


                if (adatok[4] == "X")
                {
                    Dobások[1] = "X";
                }
                else if (adatok[4] == "-")
                {
                    Dobások[1] = "-";
                }
                else
                {
                    Dobások[1] = adatok[4];
                }

                if (adatok[5] == "X")
                {
                    Dobások[2] = "X";
                }
                else if (adatok[5] == "-")
                {
                    Dobások[2] = "-";
                }
                else
                {
                    Dobások[2] = adatok[5];
                }
            }
            public double Eredmény(string[] dobások)
            {
                double[] dobások_double = new double[dobások.Length];
                for (int i = 0; i < dobások.Length; i++)
                {
                    if (dobások[i] == "X" || dobások[i] == "-")
                    {
                        dobások_double[i] = 0;
                    }
                    else
                    {
                        dobások_double[i] = double.Parse(dobások[i]);
                    }
                        
                }
                double legnagyobb_dobás = dobások_double.Max();
                return legnagyobb_dobás;
            }
            public string Nemzet(string NemzetÉsKód)
            {
                string[] Nemzetek_darabolt =NemzetÉsKód.Split(' ');
                return Nemzetek_darabolt[0];
            }
            public string Kód(string NemzetÉsKód)
            {
                string[] Nemzetek_darabolt = NemzetÉsKód.Split('(');

                return Nemzetek_darabolt[1].Remove(Nemzetek_darabolt[1].Count()-1);
            }
            static void Main(string[] args)
            {
                List<Versenyző> Versenyzők = new List<Versenyző>();
                foreach (var item in File.ReadLines(@"C:\Users\12d\Fazekas István\Asztali\erettsegi\informatikai ismeretek\emelt\2021 május\Informatikai_ism_emelt_gyakorlati_forras_E2111\2. Kalapácsvetés\Selejtezo2012.txt").Skip(1))
                {
                    Versenyző adat = new Versenyző(item);
                    Versenyzők.Add(adat);
                }
                //foreach (var item in Versenyzők)
                //{
                //    Console.Write(item.Név + "-" + item.Csoport + "-" + item.NemzetEsKód);
                //    for(int i = 0;i< item.Dobások.Count(); i++)
                //    {
                //        Console.Write("-"+item.Dobások[i]);
                //    }
                //    Console.WriteLine();
                //}
                Console.WriteLine();
                Console.WriteLine("5. feladat: Versenyzők száma a selejtezőben: {0} fő",Versenyzők.Count());
                int mennyiség = 0;
                foreach(var item in Versenyzők)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        if (item.Dobások[i].Contains("78") || item.Dobások[i+1].Contains("78"))
                        {
                            mennyiség++;
                        }
                    }
                }
                Console.WriteLine("6. feladat 78,00 méter feletti eredménnyel továbbjutott: {0} fő",mennyiség);
                
                Console.WriteLine("9. feladat: A selejtező nyertese:");
                int[] melyik = new int[Versenyzők.Count()];
                double legnagyobb = 0;
                foreach (var item in Versenyzők)
                {
                    if(legnagyobb< item.Eredmény(item.Dobások))
                    {
                        legnagyobb = item.Eredmény(item.Dobások);
                        melyik.Append(Versenyzők.IndexOf(item));
                    }

                }
                Console.WriteLine("\t Név: {0}", Versenyzők[melyik[0]].Név);
                Console.WriteLine("\t Csoport: {0}",Versenyzők[melyik[0]].Csoport);
                Console.WriteLine("\t Nemzet: {0}", Versenyzők[melyik[0]].Nemzet(Versenyzők[melyik[0]].NemzetEsKód));
                Console.WriteLine("\t Nemzet kód: {0}", Versenyzők[melyik[0]].Kód(Versenyzők[melyik[0]].NemzetEsKód)); //zárójelek eltávolítása még kell
                string sorozat = "";
                for (int i = 0; i < Versenyzők[].Dobások.Count(); i++)
                {
                    if(i == 2)
                    {
                        sorozat += Versenyzők[melyik[0]].Dobások[i];
                    }
                    else
                    {
                        sorozat += Versenyzők[melyik[0]].Dobások[i]+";" ;
                    }
                        
                }
                Console.WriteLine("\t Sorozat: {0}",sorozat);
                Console.WriteLine("\t Eredmény: {0}", Versenyzők[melyik[0]].Eredmény(Versenyzők[melyik[0]].Dobások));
                using(StreamWriter writer = new StreamWriter("Dontos2012.txt"))
                {
                    writer.WriteLine("Helyezés;Név;Csoport;Nemzet;NemzetKód;Sorozat;Eredmény");
                    for (int i = 0;  i < Versenyzők.Count();  i++)
                    {
                        
                    }
                }
            }
        }
    }
}
