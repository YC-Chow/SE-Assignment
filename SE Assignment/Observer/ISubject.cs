namespace SE_Assignment.Observer
{
	public interface ISubject
	{
        void registerObserver(IObserver observer);
        void removeObserver(IObserver observer);
        void notifyObserver();
    }
}

