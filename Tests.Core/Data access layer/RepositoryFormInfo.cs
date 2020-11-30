namespace Tests.Core.Data_access_layer
{
    public class RepositoryFormInfo
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Visibility RepositoryVisibility { get; set; }

        public bool NeedToAddReadmi { get; set; }

        public bool NeedToAddGitIgnore { get; set; }

        public string GitIgnoreTemplate { get; set; }
    }
}
