namespace SE_Assignment.Iterator
{
    public interface IRoomTypeIterator
    {
        RoomType First();
        RoomType Next();
        bool isCompleted { get; }
        RoomType Current { get; }
    }

    public class RoomTypeIterator : IRoomTypeIterator
    {
        private RoomTypeCollection roomTypeCollection;
        private int current = 0;
        private int step = 1;

        public RoomTypeIterator(RoomTypeCollection collection)
        {
            roomTypeCollection = collection;
        }
        public RoomType First()
        {
            current = 0;
            return roomTypeCollection[current];
        }
        public RoomType Next()
        {
            current += step;
            if (!isCompleted)
            {
                return roomTypeCollection[current];
            }
            else
            {
                return null;
            }
        }
        public bool isCompleted
        {
            get { return current >= roomTypeCollection.Count; }
        }
        public RoomType Current
        {
            get { return roomTypeCollection[current]; }
        }
    }
}
