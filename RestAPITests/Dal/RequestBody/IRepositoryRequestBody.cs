namespace RestAPITests.Dal
{
    internal interface IRepositoryRequestBody
    {
        bool AutoInit { get; set; }
        string Description { get; set; }
        string GitIgnoreTemplate { get; set; }
        bool IsPrivate { get; set; }
        string Name { get; set; }
    }
}