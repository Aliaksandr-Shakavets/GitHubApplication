using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class RepositoryRequestBody
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "auto_init")]
        public bool AutoInit { get; set; }

        [DataMember(Name = "private")]
        public bool IsPrivate { get; set; }

        [DataMember(Name = "gitignore_template")]
        public string GitIgnoreTemplate { get; set; }
    }
}
