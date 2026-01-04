namespace FeatureRequestPortal.Permissions;

public static class FeatureRequestPortalPermissions
{
    public const string GroupName = "FeatureRequestPortal";


    
    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class FeatureRequests
    {
        public const string Default = GroupName + ".FeatureRequests";
        public const string Manage = Default + ".Manage";
    }
}
