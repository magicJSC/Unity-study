using System;

namespace CSarp
{
    enum ItemType
    {
        Weapon,
        Armor,
        Amulet,
        Ring
    }
    enum Rarity
    { 
        Normal,
        Uncommon,
        Rare
    }

    class Item
    {
        public ItemType itemType;
        public Rarity rarity;
    }
    class Program
    {
        static List<item> _item = new List<item>();
        delegate Return Func<T, Return>(T item);   //delegate에도 T를 사용 할수있다
        
        static Item FindItem(Func<Item,bool>  selector)
        {
            foreach(Item item in _item)
            {
                if(item.itemType == ItemType.Weapon)
                {
                    return item;
                }
               
            }
            return null;
        }
        void Main(string[] args)
        {
            _item.Add(new Item() { itemType = ItemType.Weapon, rarity = Rarity.Normal });
            _item.Add(new Item() { itemType = ItemType.Ring, rarity = Rarity.Rare });


            Item item = FindItem(delegate (Item item) { return item.itemType == ItemType.Weapon; });  //delegate를 사용해서 일회성 함수 만들기

            //delegate를 선언하지 않아도 delegate가 있다
            //반환 타입이 있을 경우 Func
            //반환 타입이 없을 경우 Action
            Func<Item,bool>selector = new Myfunc<Item, bool>(Item item) => { return item.itemType == ItemType.Weapon; });  //람다식를 사용해서 일회성 함수 만들기
            Item item = FindItem(selector);
        }
    }

}
