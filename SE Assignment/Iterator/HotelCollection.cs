namespace SE_Assignment.Iterator
{
    public interface IHotelCollection
    {
        HotelIterator CreateIterator();
    }

    public class HotelCollection : List<Hotel>, IHotelCollection
    {
        public HotelIterator CreateIterator()
        {
            return new HotelIterator(this);
        }
    }
}
