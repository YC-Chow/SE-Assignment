namespace SE_Assignment.Iterator
{
    public interface IVoucherIterator
    {
        Voucher First();
        Voucher Next();
        bool isCompleted { get; }
        Voucher Current { get; }
    }

    public class VoucherIterator : IVoucherIterator
    {
        private VoucherCollection voucherCollection;
        private int current = 0;
        private int step = 1;

        public VoucherIterator(VoucherCollection collection)
        {
            voucherCollection = collection;
        }
        public Voucher First()
        {
            current = 0;
            return voucherCollection[current];
        }
        public Voucher Next()
        {
            current += step;
            if (!isCompleted)
            {
                return voucherCollection[current];
            }
            else
            {
                return null;
            }
        }
        public bool isCompleted
        {
            get { return current >= voucherCollection.Count; }
        }
        public Voucher Current
        {
            get { return voucherCollection[current]; }
        }
    }
}
