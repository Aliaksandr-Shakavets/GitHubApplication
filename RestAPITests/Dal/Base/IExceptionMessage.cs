namespace RestAPITests.Dal
{
    internal interface IExceptionMessage
    {
        IErrorDetails Details { get; set; }
        string Message { get; set; }
    }
}