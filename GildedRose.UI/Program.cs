using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                // Format item list, agar lebih mudah di baca / ditambahkan
                Items = new List<Item>
                {
                new Item
                    {
                        Name = "+5 Dexterity Vest",
                        SellIn = -10,
                        Quality = 20
                    },
                new Item
                    {
                        Name = "Aged Brie",
                        SellIn = -2,
                        Quality = 0
                    },
                new Item
                    {
                        Name = "Elixir of the Mongoose",
                        SellIn = -5,
                        Quality = 7
                    },
                new Item
                    {
                        Name = "Sulfuras, Hand of Ragnaros",
                        SellIn = 0,
                        Quality = 80
                    },
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = -15,
                        Quality = 20
                    },
                new Item
                    {
                        Name = "Conjured Mana Cake",
                        SellIn = -3,
                        Quality = 6
                    },
                }
            };

            app.UpdateQuality();

            // pause the console
            System.Console.ReadKey();
        }


        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                // Invert condition, then use guard clause to reduce nested if
                if (Items[i].Name == "Aged Brie" || Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality++;

                        // Cannot be combined to retain the logic, looking at original code
                        // "Items[i].Quality++; " must be called twice if "Items[i].SellIn < 6"
                        // remove unused / duplicate condition "Quality < 50", already evaluted at outer block
                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert" && Items[i].SellIn < 11)
                        {
                            Items[i].Quality++;
                        }

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert" && Items[i].SellIn < 6)
                        {
                            Items[i].Quality++;
                        }
                    }
                }
                else if (Items[i].Quality > 0 && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].Quality--;
                }


                // Cannot be combined to retain the logic
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn--;
                }


                if (Items[i].SellIn < 0)
                {
                    // Invert condition, then use guard clause to reduce nested if
                    if (Items[i].Name == "Aged Brie" && Items[i].Quality < 50)
                    {
                        Items[i].Quality++;
                    }
                    else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        Items[i].Quality=0;
                    }
                    else if (Items[i].Quality > 0 && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Items[i].Quality--;
                    }
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}