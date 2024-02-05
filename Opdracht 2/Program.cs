using System.Linq;

namespace Opdracht1 {
    class House {
        public List<Room> rooms = new List<Room>();
        public int totalVolume => rooms.Sum(r => r.volume);

        // Constructor
        public House()
        {
        }

        public void addRoom(Room pRoom) {
            rooms.Add(pRoom);
        }

        public string getPrice() {
            string returnString = "Inhoud Kamers: \n\n";
            foreach (var room in rooms) {
                returnString += $"    - Lengte: {room.length}m Breedte: {room.width}m Hoogte: {room.height}m\n";
            }
            returnString += $"\nVolume Totaal = {totalVolume}m3\n";
            returnString += $"Prijs van het huis is = {totalVolume * 3000}Euro";

            return returnString;
        }
    }

    class Room {
        public float length { get; }
        public float height { get; }
        public float width { get; }

        public int volume => Convert.ToInt32(length * height * width);

        // Constructor
        public Room(float pLenght
                  , float pHeight
                  , float pWidth)
        {
            length = pLenght;
            height = pHeight;
            width = pWidth;
        }
    }

    class Program {
        static void Main(string[] args)
        {
            var tmpHouse = new House();
            tmpHouse.addRoom(new Room(5.2f, 5.5f, 5.1f));
            tmpHouse.addRoom(new Room(4.8f, 4.9f, 4.6f));
            tmpHouse.addRoom(new Room(5.9f, 3.1f, 2.5f));

            Console.WriteLine(tmpHouse.getPrice());
        }
    }
    
}

