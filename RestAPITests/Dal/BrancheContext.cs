using System.Runtime.Serialization;

namespace RestAPITests.Dal
{
    internal class BrancheContext
    {
        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        [DataMember(Name = "done_id")]
        public string NodeId { get; set; }

        public BranchDetails Details { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is BrancheContext branche)
            {
                return Ref == branche.Ref &&
                       NodeId == branche.NodeId &&
                       Details.Sha == branche.Details.Sha;
            }

            return false;
        }

        public override int GetHashCode() => (Ref.GetHashCode() << 2) ^ NodeId.GetHashCode() ^ Details.Sha.GetHashCode();
    }
}
