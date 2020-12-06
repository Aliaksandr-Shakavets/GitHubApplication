using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class BranchDetails
    {
        [DataMember(Name = "sha")]
        public string Sha { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}