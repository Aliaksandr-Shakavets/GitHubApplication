
using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class NewBrancheRequestBody : INewBrancheRequestBody
    {
        private string @ref;

        [DataMember(Name = "ref")]
        public string Ref { get => @ref; set => @ref = "refs/heads/" + value; }

        [DataMember(Name = "sha")]
        public string Sha { get; set; }
    }
}
