namespace Scrabex.WebApi.Constants
{
    public static class UserMessages
    {
        public const string ChangePasswordEmailSent = "If provided login is correct, you should shortly receive a confirmation link on your email.";
        public const string ChangePasswordEmailError = "Failed to send a confirmation link to provided email address. Try again later.";
        public const string LogoutFailed = "Log out failed becaused no user was logged in.";
        public const string LogoutSuccessful = "Successfully logged out user: ";
        public const string LoginFailed = "Provided login or password is incorrect.";
        public const string RegisterFailed = "Could not register a new user with provided details. Try again.";
        public const string RegisterSuccessful = "User registered. Check your email for confirmation link.";

        public const string UnauthorizedAnon = "Unauthorized - Please log in.";
        public const string UnauthorizedRestricted = "Unauthorized - No permission.";
        public const string UnauthorizedNotConfirmed = "Unauthorized - Please log in.";
        public const string ObjectNotFound = "Requested object could not be found";
        public const string ObjectUpdateFailed = "Requested object could not be updated. Verify request body content";
        public const string ObjectCreateFailed = "Requested object could not be created. Verify request body content";
        public const string ObjectDeleteFailed = "Requested object could not be deleted. Verify request body content";
    }
}
