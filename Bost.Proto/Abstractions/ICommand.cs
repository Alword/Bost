namespace Bost.Proto.Abstractions
{
    public interface ICommand<T>
    {
        void Execute(T data);
    }

    public interface ICommand<T, Q>
    {
        void Execute(T param, Q data);
    }
}
