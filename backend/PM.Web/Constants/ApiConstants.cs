namespace PM.Web.Constants
{
    public class ApiConstants
    {
        public const string ApiPrefix = "api/";

        public const string ApiRoute = ApiPrefix + ControllerTemplate;

        private const string ControllerTemplate = "[controller]";

        public const string IdIndicator = "{id}";

        public const string PersonsWithPAging = ApiPrefix + "persons/" + IdIndicator;
    }
}
