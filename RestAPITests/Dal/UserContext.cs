using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class UserContext : IUserContext
    {
        [DataMember(Name = "id")]
        public uint Id { get; set; }

        [DataMember(Name = "node_id")]
        public string NodeId { get; set; }

        [DataMember(Name = "login")]
        public string Login { get; set; }

    }
}
