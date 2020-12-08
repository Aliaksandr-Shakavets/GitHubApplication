namespace RestAPITests.Dal
{
    internal interface IBranchDetails
    {
        string Sha { get; set; }
        string Type { get; set; }
    }
}