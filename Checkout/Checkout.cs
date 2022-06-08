using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Checkout
{
    public class SpecialPrice
    {
        public int SpecialPriceCount { get; set; }
        public double Price { get; set; }
    }
    public class Item
    {
        public char ItemCode { get; set; }
        public double Price { get; set; }
        public SpecialPrice SpecialPrice { get; set; }
    }

    public class Checkout
    {
        private readonly List<Item> _items;

        public Checkout(List<Item> items)
        {
            this._items = items;
        }
        public Checkout()
        {
            _items = new List<Item>
            {
                new Item
                {
                    ItemCode = 'A',
                    Price = 50,
                    SpecialPrice = new SpecialPrice
                    {
                        Price = 130,
                        SpecialPriceCount = 3
                    }
                },
                new Item
                {
                    ItemCode = 'B',
                    Price = 30,
                    SpecialPrice = new SpecialPrice
                    {
                        Price = 45,
                        SpecialPriceCount = 2
                    }
                },
                new Item
                {
                    ItemCode = 'C',
                    Price = 20
                },
                new Item
                {
                    ItemCode = 'D',
                    Price = 15
                },
            };
        }
        private readonly Dictionary<char, (int, double, double)> _totalPrice = new Dictionary<char, (int, double, double)>();
        public double Scann(string codes)
        {
            if (string.IsNullOrWhiteSpace(codes)) return 0;

            var arrayCodes = codes.ToCharArray();
            foreach (var code in arrayCodes)
            {
                var itemFound = _items.FirstOrDefault(item => item.ItemCode == code);
                if (itemFound == null)
                {
                    throw new Exception($"code {code} does not exist");
                }

                if (!_totalPrice.Keys.Contains(code))
                {
                    _totalPrice.Add(code, (1, itemFound.Price, 0));
                }
                else
                {
                    var existingPrice = _totalPrice[code];

                    if ((existingPrice.Item1 + 1) % itemFound.SpecialPrice?.SpecialPriceCount != 0)
                    {
                        _totalPrice[code] = (++existingPrice.Item1, existingPrice.Item2 + itemFound.Price, existingPrice.Item3);
                    }

                    else
                    {
                        var specialPrice = itemFound.SpecialPrice == null ? 0 : itemFound.SpecialPrice.Price;
                        _totalPrice[code] = (++existingPrice.Item1, 0, existingPrice.Item3 + specialPrice);
                    }
                }
            }
            return _totalPrice.Sum(item => item.Value.Item2 + item.Value.Item3);

        }
    }
}
