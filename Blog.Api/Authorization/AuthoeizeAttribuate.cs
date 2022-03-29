namespace Blog.Api.Authorization
{
    //public class AuthorizePermissonAttribute : TypeFilterAttribute
    //{
    //    public AuthorizePermissonAttribute(PermissionItem permissionItem, PermissionAction permissionAction)
    //        : base(typeof(AuthorizeActionFilter))

    //    {
    //        Arguments = new object[] { permissionItem, permissionAction };

    //        //_permissionItem = permissionItem;
    //        //_permissionAction = permissionAction;
    //    }
    //}
    //public class AuthorizeActionFilter : IAuthorizationFilter
    //{
    //    private IPermissionManager _permissionManager;
    //    private PermissionItem _permissionItem;
    //    private PermissionAction _permissionAction;
    //    public AuthorizeActionFilter(IPermissionManager permissionManager, PermissionItem item, PermissionAction action)
    //    {
    //        _permissionManager = permissionManager;
    //        _permissionItem = item;
    //        _permissionAction = action;
    //    }
    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //        var user = context.HttpContext.User;

    //        if (!user.Identity.IsAuthenticated)
    //        {
    //            // it isn't needed to set unauthorized result 
    //            // as the base class already requires the user to be authenticated
    //            // this also makes redirect to a login page work properly
    //            context.Result = new UnauthorizedResult();
    //            return;
    //        }
    //        bool isAuthorized = _permissionManager.Check(context.HttpContext.GetUserId(),
    //           context.HttpContext.GetCompanyId(),
    //            _permissionItem, _permissionAction);

    //        if (!isAuthorized)
    //        {
    //            context.Result = new ForbidResult();
    //            return;
    //        }
    //    }

}

