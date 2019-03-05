using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modellib.Model
{
    public class Room
    {
        private int _id;
        private int _hotelId;
        private char _type;
        private double _price;

        public Room()
        {
        }

        public Room(int id, int hotelId, char type, double price)
        {
            _id = id;
            _hotelId = hotelId;
            _type = type;
            _price = price;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int HotelId
        {
            get => _hotelId;
            set => _hotelId = value;
        }

        public char Type
        {
            get => _type;
            set => _type = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }
    }
}
