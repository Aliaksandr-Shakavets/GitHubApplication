using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class ErrorDetails
    {
        [DataMember(Name ="field")]
        public string Field { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
