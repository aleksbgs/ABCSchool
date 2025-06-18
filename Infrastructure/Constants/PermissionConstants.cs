namespace Infrastructure.Constants;

public static class SchoolAction
{
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Read = nameof(Read);
    
    public const string UpgradeSubScription = nameof(UpgradeSubScription);
}
public static class SchoolFeature
{
    public const string Tenants = nameof(Tenants);
    public const string Users = nameof(Users);
    public const string Roles = nameof(Roles);
    public const string UserRoles = nameof(UserRoles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string School = nameof(School);
}

public record SchoolPermission(
    string Action,
    string Feature,
    string Description,
    bool IsBasic = false,
    bool IsRoot = false)
{
    public string Name => NameFor(Action, Feature);
    public static string NameFor(string action, string feature) => $"Permission.{feature}.{action}";
}

public static class SchoolPermissions
{
    private static readonly SchoolPermission[] _allPermissions =
    [
        new SchoolPermission(SchoolAction.Create, SchoolFeature.Tenants, "Create Tenants", IsRoot: true),
        new SchoolPermission(SchoolAction.Read, SchoolFeature.Tenants, "Read Tenants", IsRoot: true),
        new SchoolPermission(SchoolAction.Update, SchoolFeature.Tenants, "Update Tenants", IsRoot: true),
        new SchoolPermission(SchoolAction.UpgradeSubScription, SchoolFeature.Tenants, "Upgrade Tenant's Subscription",
            IsRoot: true),

        new SchoolPermission(SchoolAction.Create, SchoolFeature.Users, "Create Users"),
        new SchoolPermission(SchoolAction.Update, SchoolFeature.Users, "Update Users"),
        new SchoolPermission(SchoolAction.Delete, SchoolFeature.Users, "Delete Users"),
        new SchoolPermission(SchoolAction.Read, SchoolFeature.Users, "Read Users"),
        
        new SchoolPermission(SchoolAction.Read, SchoolFeature.UserRoles, "Read User Roles"),
        new SchoolPermission(SchoolAction.Update, SchoolFeature.UserRoles, "Update User Roles"),
       
        new SchoolPermission(SchoolAction.Read, SchoolFeature.Roles, "Read Roles"),
        new SchoolPermission(SchoolAction.Create, SchoolFeature.Roles, "Create Roles"),
        new SchoolPermission(SchoolAction.Update, SchoolFeature.Roles, "Update Roles"),
        new SchoolPermission(SchoolAction.Delete, SchoolFeature.Roles, "Delete Roles"),
        
        new SchoolPermission(SchoolAction.Read, SchoolFeature.RoleClaims, "Read Role Claims/Permissions"),
        new SchoolPermission(SchoolAction.Update, SchoolFeature.RoleClaims, "Update Role Claims/Permissions"),
        
        new SchoolPermission(SchoolAction.Read, SchoolFeature.School, "Read School"),
        new SchoolPermission(SchoolAction.Create, SchoolFeature.School, "Create School"),
        new SchoolPermission(SchoolAction.Update, SchoolFeature.School, "Update School"),
        new SchoolPermission(SchoolAction.Delete, SchoolFeature.School, "Delete School"),
 
        
    ];
}

 