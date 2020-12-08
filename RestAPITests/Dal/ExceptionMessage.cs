using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class ExceptionMessage : IExceptionMessage
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "errors")]
        public IErrorDetails Details { get; set; }
    }
}
