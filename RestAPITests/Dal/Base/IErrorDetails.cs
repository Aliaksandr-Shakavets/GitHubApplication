namespace RestAPITests.Dal
{
    internal interface IErrorDetails
    {
        string Field { get; set; }
        string Message { get; set; }
    }
}