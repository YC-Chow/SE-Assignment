namespace SE_Assignment.Iterator
{
    public interface IHotelIterator
    {
        Hotel First();
        Hotel Next();
        bool isCompleted { get; }
        Hotel Current { get; }
    }

    public class HotelIterator : IHotelIterator
    {
        private HotelCollection hotelCollection;
        private int current = 0;
        private int step = 1;

        public HotelIterator(HotelCollection collection)
        {
            hotelCollection = collection;
        }
        public Hotel First()
        {
            current = 0;
            return hotelCollection[current];
        }
        public Hotel Next()
        {
            current += step;
            if (!isCompleted)
            {
                return hotelCollection[current];
            }
            else
            {
                return null;
            }
        }
        public bool isCompleted
        {
            get { return current >= hotelCollection.Count; }
        }
        public Hotel Current
        {
            get { return hotelCollection[current]; }
        }
    }
}
