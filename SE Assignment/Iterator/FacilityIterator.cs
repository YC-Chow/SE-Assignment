namespace SE_Assignment.Iterator
{
    public interface IFacilityIterator
    {
        Facility First();
        Facility Next();
        bool isCompleted { get; }
        Facility Current { get;}
    }

    public class FacilityIterator : IFacilityIterator
    {
        private FacilityCollection facilityCollection;
        private int current = 0;
        private int step = 1;

        public FacilityIterator(FacilityCollection collection)
        {
            facilityCollection = collection;
        } 
        public Facility First()
        {
            current = 0;
            return facilityCollection[current];
        }
        public Facility Next()
        {
            current += step;
            if (!isCompleted)
            {
                return facilityCollection[current];
            }
            else
            {
                return null;
            }
        }
        public bool isCompleted
        {
            get { return current >= facilityCollection.Count; }
        }
        public Facility Current
        {
            get { return facilityCollection[current]; }
        }
    }
}
