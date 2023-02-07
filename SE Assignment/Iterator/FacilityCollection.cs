namespace SE_Assignment.Iterator
{
    public interface IFacilityCollection
    {
        IFacilityIterator CreateIterator();
    }

    public class FacilityCollection : List<Facility>, IFacilityCollection
    {
        public IFacilityIterator CreateIterator()
        {
            return new FacilityIterator(this);
        }
    }
}
