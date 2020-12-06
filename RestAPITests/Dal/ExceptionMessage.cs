using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class ExceptionMessage
    {
        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name ="errors")]
        public ErrorDetails Details { get; set; }
    }
}
