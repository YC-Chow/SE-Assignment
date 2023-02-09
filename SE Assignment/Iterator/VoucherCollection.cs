namespace SE_Assignment.Iterator
{
    public interface IVoucherCollection
    {
        VoucherIterator CreateIterator();
    }

    public class VoucherCollection : List<Voucher>, IVoucherCollection
    {
        public VoucherIterator CreateIterator()
        {
            return new VoucherIterator(this);
        }
        public int count
        {
            get { return this.Count; }
        }
    }
}
