using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;



class knihovna
{
    public class TridaKnihy
    {
        public string nazev;
        public string autor;
        public int rok;




        public TridaKnihy(string nazev, string autor, int rok)
        {
            this.nazev = nazev;
            this.autor = autor;
            this.rok = rok;
        }




    }



    private static class Inventory
    {
        public static List<TridaKnihy> Products { get; set; } = new List<TridaKnihy>();



        public static int pocet { get; set; }



        public static void AddProduct(string nazev, string autor, int rok)
        {
            try
            {
                Products.Add(new TridaKnihy(nazev, autor, rok));
                pocet++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public static void RemoveProduct(string nazev)
        {
            int pocet = Products.IndexOf(Products.Find(p => p.nazev == nazev));



            if (pocet == -1) throw new Exception();
            Products.RemoveAt(pocet);
            AnsiConsole.Markup($"Kniha [Yellow]{nazev}[/] byla odebrána");
            Console.ReadKey();
        }

        public static void FindProductAutorem(string autor)
        {
            int pocet = Products.IndexOf(Products.Find(p => p.autor == autor));
            int pocetKnih = 0;
            foreach (var kniha in Products)
            {
                
                int i = 0;
                if (Products[i].autor == Products[pocet].autor)
                {
                    AnsiConsole.Markup($"nazev: [Green]{Products[i].nazev}[/], autor: [Red]{Products[i].autor}[/], rok vydani: [Yellow]{Products[i].rok}[/]\n");
                    pocetKnih++;
                }
                i++;
                
                
            }
            AnsiConsole.Markup($"{Products[pocet].autor} ma {pocetKnih} knihy/u");
        }
        public static void FindProductRokem(int rok)
        {
            int pocet = Products.IndexOf(Products.Find(p => p.rok == rok));
            int pocetKnih = 0;
            foreach (var kniha in Products)
            {

                int i = 0;
                if (Products[i].autor == Products[pocet].autor)
                {
                    AnsiConsole.Markup($"nazev: [Green]{Products[i].nazev}[/], autor: [Red]{Products[i].autor}[/], rok vydani: [Yellow]{Products[i].rok}[/]\n");
                    pocetKnih++;
                }
                i++;


            }
            AnsiConsole.Markup($"{Products[pocet].autor} ma {pocetKnih} knihy/u");
        }
    }




    public static void Main()
    {




        while (true)
        {


            var inputik = "";
            Console.Clear();
            AnsiConsole.Markup($"Zadej akci: [Green]pridat[/], [Red]odebrat[/], [Yellow]zobrazit[/], [Yellow]vyhledat[/], [Blue]konec[/]\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "pridat":
                    {
                        try
                        {
                            Console.Write("Zadej název knihy: ");
                            string nazev = Console.ReadLine();
                            Console.Write("Zadej autora knihy: ");
                            string autor = Console.ReadLine();
                            Console.Write("Zadej rok vydání knihy: ");
                            int rok = int.Parse(Console.ReadLine());
                            Inventory.AddProduct(nazev, autor, rok);
                            Console.Clear();
                            AnsiConsole.Markup($"Kniha [Yellow]{nazev}[/], [Yellow]{autor}[/], [Yellow]{rok}[/] byla přidána");
                            Console.ReadKey();



                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;



                case "odebrat":
                    {
                        Console.WriteLine("zadej název knihy kterou chceš odebrat");
                        try
                        {

                            Inventory.RemoveProduct(Console.ReadLine());

                        }
                        catch
                        {
                            Console.WriteLine("CHYBA");
                            Console.ReadKey();
                            continue;
                        }
                    }
                    break;



                case "zobrazit":
                    {
                        foreach (var product in Inventory.Products)
                        {
                            AnsiConsole.Markup($"[Blue]{product.nazev}[/], [Blue]{product.autor}[/], [Blue]{product.rok}[/]\n");




                        }
                        if (Inventory.Products.Count == 0)
                        {
                            Console.WriteLine("knihovna je prázdná");
                        }
                        Console.ReadKey();
                    }
                    break;


                case "vyhledat":
                    {
                        AnsiConsole.Markup("Zadej [Grey]jmeno autora / rok vydani[/] knihy kterou chceš vyhledat: ");
                        try
                        {
                            input = Console.ReadLine();
                            if ()
                            {
                                Inventory.FindProductAutorem(Console.ReadLine());
                                Console.ReadKey();
                            }else if(input == input)
                            {
                                Inventory.FindProductRokem(int.Parse(Console.ReadLine()));
                                Console.ReadKey();
                            }
                            
                        }
                        catch
                        {
                            Console.WriteLine("CHYBA");
                            Console.ReadKey();
                            continue;
                        }
                    }
                    break;



                case "konec":
                    {
                        Console.WriteLine("Konec");
                        break;
                    }
                    break;



            }
        }
    }
}