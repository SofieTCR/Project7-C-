namespace Opdracht1 {
    public class House
    {
        public int floors { get; private set; }
        public int rooms { get; private set; }
        public float width { get; private set; }
        public float height { get; private set; }
        public float depth { get; private set; }
        public int volume => Convert.ToInt32(width * height * depth);

        // Constructor
        public House(int pFloors
                   , int pRooms
                   , float pWidth
                   , float pHeight
                   , float pDepth)
        {
            floors = pFloors;
            rooms = pRooms;
            width = pWidth;
            height = pHeight;
            depth = pDepth;
        }

        public string getHouse()
        {
            return $"Dit huis heeft {floors} verdiepingen, {rooms} kamers en heeft een volume van {volume} m3";
        }

        public string getPrice()
        {
            return $"De prijs van het huis is: {1500 * volume}";
        }
    }

    class Program {
        static void Main(string[] args)
        {
            var tmpHouses = new List<House>{
                new House(2, 4, 5, 5, 5)
              , new House(3, 6, 10, 5, 7)
              , new House(2, 3, 7, 2, 5)
            };

            foreach(var house in tmpHouses) {
                Console.WriteLine(house.getHouse());
                Console.WriteLine(house.getPrice());
            }
        }
    }
}