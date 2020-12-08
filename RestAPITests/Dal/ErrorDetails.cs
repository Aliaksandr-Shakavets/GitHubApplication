using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class ErrorDetails : IErrorDetails
    {
        [DataMember(Name = "field")]
        public string Field { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
