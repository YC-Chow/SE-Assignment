namespace SE_Assignment.Iterator
{
    public interface IFacilityCollection
    {
        FacilityIterator CreateIterator();
    }

    public class FacilityCollection : List<Facility>, IFacilityCollection
    {
        public FacilityIterator CreateIterator()
        {
            return new FacilityIterator(this);
        }
    }
}
