namespace RestAPITests.Dal
{
    internal interface IBrancheContext
    {
        IBranchDetails Details { get; set; }
        string NodeId { get; set; }
        string Ref { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}