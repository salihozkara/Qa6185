namespace Qa6185.MyEntities
{
    public static class MyEntityConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MyEntity." : string.Empty);
        }

    }
}