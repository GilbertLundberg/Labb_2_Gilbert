// See https://aka.ms/new-console-template for more information
using System;
using System.ComponentModel;
using System.Reflection.Metadata;
using Labb2;
/*
 * Jag har valt att inte ha med något abstract i denna uppgiften. 
 * Jag känner att man uppfyller bra funktionalitet med interfacet och med abstract skulle det möjligtvis
 * röra till det lite genom att man lägger till lite “onödigt” extra.
 * Om man istället hade skapat olika objekt som skulle representera köksapparaterna, 
 * så skulle det kunna vara ett alternativ att använda sig av en abstrakt klass som ärver av interfacet och som har en 
 * definierad använding för hur use-funktionen skulle vara utformad.
 * 
 */
var kitchen = new Kitchen();
kitchen.PrintMenu();

namespace Labb2
{

    public interface IKitchenAppliance
    {
        string Type { get; set; }
        string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        void Use();
    }

    class KitchenAppliance : IKitchenAppliance
    {

        public string Type { get; set; }
        public string Brand { get; set; }
        public bool IsFunctioning { set; get; }

        public KitchenAppliance(string type, string brand, bool isFunctioning) : base()
        {
            Type = type;
            Brand = brand;
            IsFunctioning = isFunctioning;
        }

        public void Use()
        {

            if (IsFunctioning == true)
            {
                Console.WriteLine();
                Console.WriteLine($"Använder {Type}...");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{Type} är trasig. Kan ej användas.");
                Console.WriteLine();

            }
        }

    }

    class Kitchen
    {
        List<KitchenAppliance> KitchenAppliances;

        public void PrintMenu()
        {
            KitchenAppliances = new List<KitchenAppliance>() { new KitchenAppliance("Ugn", "Cylinda", true), new KitchenAppliance("Brödrost", "Elektrolux", false), new KitchenAppliance("Riskokare", "Wilfa", true) };


            int input = 0;
            bool inmatat = false;

            try
            {
                while (true)
                {
                    Console.WriteLine("==========KÖKET==========");
                    Console.WriteLine("1. Använd köksapparat");
                    Console.WriteLine("2. Lägg till köksapparat");
                    Console.WriteLine("3. Lista köksapparater");
                    Console.WriteLine("4. Ta bort köksapparat");
                    Console.WriteLine("5. Avsluta");
                    Console.WriteLine("Ange val:");
                    Console.Write(">");

                    inmatat = int.TryParse(Console.ReadLine(), out input);
                    if (!inmatat)
                    {
                        Console.WriteLine("Var vänlig skriv in ett heltal.");
                    }

                    switch (input)
                    {
                        case 1:
                            UseAppliance();
                            break;
                        case 2:
                            AddAppliance();
                            break;
                        case 3:
                            ListAppliances();
                            break;
                        case 4:
                            RemoveAppliance();
                            break;
                        case 5:
                            ExitMenu();
                            break;
                        default:
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void UseAppliance()
        {
            while (true)
            {
                Console.WriteLine("Välj vilken köksapparat du vill använda:");
                if (KitchenAppliances.Count < 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Det finns för närvarande inga köksapparater i köket.");
                    Console.WriteLine();
                }
                else
                {
                    for (int i = 0; i < KitchenAppliances.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + KitchenAppliances[i].Type + " " + KitchenAppliances[i].Brand);

                    }
                    try
                    {
                        //bool wait = false;
                        //while (!false)

                        int use = int.Parse(Console.ReadLine());
                        if (use > KitchenAppliances.Count || use <= 0)
                        {
                            Console.WriteLine("Det finns ingen apparat med den siffran.\nFörsök igen.");
                            Console.WriteLine();
                        }
                        else
                        {
                            KitchenAppliances[use - 1].Use();
                            Console.WriteLine();
                            break;
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Vänligen skriv in en siffra.\nFörsök igen.");
                        Console.WriteLine();
                    }
                }

            }

        }
        void AddAppliance()
        {

            string type = String.Empty;
            string brand = null;
            bool isFunctioning = true;

            Console.WriteLine("Ny produkt:");

            Console.Write("Typ>");
            try
            {
                while (true)
                {
                    type = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(type))
                    {
                        Console.WriteLine("Ogiltig input.\n Försök igen:");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("Märke>");
            try
            {
                while (true)
                {
                    brand = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(brand))
                    {
                        Console.WriteLine("Ogiltig input.\n Försök igen:");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.Write("Fungerar den? j/n>");
            try
            {
                while (true)
                {
                    string key = Console.ReadLine();
                    if (key == "j")
                    {
                        isFunctioning = true;
                        break;
                    }
                    else if (key == "n")
                    {
                        isFunctioning = false;
                        break;
                    }
                    else if (string.IsNullOrEmpty(key))
                    {
                        Console.WriteLine("Ogiltig input. Skriv j för JA eller n för NEJ");
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig input. Skriv j för JA eller n för NEJ");
                    }
                }

            }
            catch
            {
                Console.WriteLine("Ogiltig input. Skriv j för JA eller n för NEJ");
            }

            var newKitchenAppliance = new KitchenAppliance(type, brand, isFunctioning);

            KitchenAppliances.Add(newKitchenAppliance);

            Console.WriteLine();
            Console.WriteLine($"Köksapparaten {newKitchenAppliance.Type} {newKitchenAppliance.Brand} är nu registrerad.");
            Console.WriteLine();
        }

        void ListAppliances()
        {
            Console.WriteLine();
            Console.WriteLine("Listar köksapparater:");
            if (KitchenAppliances.Count < 1)
            {
                Console.WriteLine("Det finns för närvarande inga köksapparater i köket.");
            }
            else
            {
                for (int i = 0; i < KitchenAppliances.Count; i++)
                {
                    Console.Write(i + 1 + ". " + KitchenAppliances[i].Type + " " + KitchenAppliances[i].Brand);
                    if (KitchenAppliances[i].IsFunctioning == true)
                    {
                        Console.Write(" | Skick: Fungerar\n");
                    }
                    else
                    {
                        Console.Write(" | Skick: Trasig\n");
                    }
                }
                Console.WriteLine();
            }
        }

        void RemoveAppliance()
        {
            if (KitchenAppliances.Count < 1)
            {
                Console.WriteLine();
                Console.WriteLine("Det finns för närvarande inga köksapparater i köket.");
                Console.WriteLine();
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Vilken köksapparat vill du ta bort?");
                    if (KitchenAppliances == null)
                    {
                        Console.WriteLine("Det finns för närvarande inga köksapparater i köket");
                    }
                    else
                    {

                        try
                        {
                            for (int i = 0; i < KitchenAppliances.Count; i++)
                            {
                                Console.WriteLine(i + 1 + ". " + KitchenAppliances[i].Type + " " + KitchenAppliances[i].Brand);
                            }
                            int removeAtNumber = int.Parse(Console.ReadLine());
                            if (removeAtNumber > KitchenAppliances.Count || removeAtNumber <= 0)
                            {
                                Console.WriteLine("Det finns ingen apparat med den siffran.\nFörsök igen.");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Köksapparaten {KitchenAppliances[removeAtNumber - 1].Type} {KitchenAppliances[removeAtNumber - 1].Brand} är nu borttagen.");
                                Console.WriteLine();
                                KitchenAppliances.RemoveAt(removeAtNumber - 1);

                                break;
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Vänligen skriv in en siffra.\nFörsök igen.");
                            Console.WriteLine();
                        }
                    }
                }
            }



        }

        void ExitMenu()
        {
            Console.WriteLine("Avslutar...");
            Environment.Exit(0);
        }
    }

}