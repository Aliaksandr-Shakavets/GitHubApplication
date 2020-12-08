namespace RestAPITests.Dal
{
    internal interface IUserContext
    {
        uint Id { get; set; }
        string Login { get; set; }
        string NodeId { get; set; }
    }
}