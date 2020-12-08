namespace RestAPITests.Dal
{
    internal interface INewBrancheRequestBody
    {
        string Ref { get; set; }
        string Sha { get; set; }
    }
}