namespace SE_Assignment.Iterator
{
    public interface IRoomTypeCollection
    {
        IRoomTypeIterator CreateIterator();
    }

    public class RoomTypeCollection : List<RoomType>, IRoomTypeCollection
    {
        public IRoomTypeIterator CreateIterator()
        {
            return new RoomTypeIterator(this);
        }
    }
}
