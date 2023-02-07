namespace SE_Assignment.Iterator
{
    public interface IHotelCollection
    {
        IHotelIterator CreateIterator();
    }

    public class HotelCollection : List<Hotel>, IHotelCollection
    {
        public IHotelIterator CreateIterator()
        {
            return new HotelIterator(this);
        }
    }
}
