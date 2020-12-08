namespace RestAPITests.Dal
{
    internal interface IRepositoryContext
    {
        string FullName { get; set; }
        uint Id { get; set; }
        bool IsPrivate { get; set; }
        string Name { get; set; }
        string NodeId { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}