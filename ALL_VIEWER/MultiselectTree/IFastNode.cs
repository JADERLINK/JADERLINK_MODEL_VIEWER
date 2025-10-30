namespace NsMultiselectTreeView
{
    public interface IFastNode
    {
        int GetHashCode();
        bool Equals(object obj);
        int HashCodeID { get; }
    }
}
