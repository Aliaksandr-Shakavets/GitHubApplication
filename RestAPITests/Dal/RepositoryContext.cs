using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class RepositoryContext : IRepositoryContext
    {
        [DataMember(Name = "id")]
        public uint Id { get; set; }

        [DataMember(Name = "node_id")]
        public string NodeId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        [DataMember(Name = "private")]
        public bool IsPrivate { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is RepositoryContext x)
            {
                return x.Id == Id &&
                   x.NodeId == NodeId &&
                   x.Name == Name &&
                   x.IsPrivate == IsPrivate;
            }

            return false;
        }

        public override int GetHashCode() => (NodeId.GetHashCode() << 2) ^ Id.GetHashCode();
    }
}
