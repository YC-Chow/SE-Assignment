namespace SE_Assignment.Iterator
{
    public interface IRoomTypeCollection
    {
        RoomTypeIterator CreateIterator();
    }

    public class RoomTypeCollection : List<RoomType>, IRoomTypeCollection
    {
        public RoomTypeIterator CreateIterator()
        {
            return new RoomTypeIterator(this);
        }
        public int count
        {
            get { return this.Count; }
        }
    }
}
