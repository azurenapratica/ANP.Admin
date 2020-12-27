namespace ANPAdmin.UI.Model
{
    public static class GlobalVariables
    {
        static string _ActualRegion;

        public static string ActualRegion
        {
            get { return _ActualRegion; }
            set { _ActualRegion = value; }
        }
    }
}
