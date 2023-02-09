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
            //Console.WriteLine(voucherCollection[current]);
            return voucherCollection[current];
            
        }
        public Voucher Next()
        {
            current += step;
            if (!isCompleted)
            {
                if (!voucherCollection[current].IsUsed)
                {
                    return voucherCollection[current];
                }
                return null;
            }
            return null;
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
