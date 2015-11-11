using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Constants
    {
        public class Permissions
        {
            public static string God = "God";
            public static string Admin = "Admin";
            public static string RegularPoster = "Regular Poster";
            public static string User = "User";
        }

        public class PermissionIDs
        {
            public static int God = 1;
            public static int Admin = 2;
            public static int RegularPoster = 3;
            public static int User = 4;
        }

        public class Urls
        {
            public static string Home = "http://localhost:50930/";
            //public static string Home = "http://potpourriblogs.gear.host/";

            public class Account
            {
                public static string Login = Home + "account/login";
                public static string Manage = Home + "account/manage";
                public static string Register = Home + "account/register";
            }
            public static string Admin = Home + "admin";
            public class Blog
            {
                public static string Create = Home + "blog/create";
            }
        }

        public class Cookies
        {
            public static string Name = "_ncfa";
            public static string UserCookieData = 
                "%2bUuN7%2fAviLb8i9Faf%2b7l5n1BrpI67reD06B";
            public static string AdminCookieData =
                "2bNgSFtQSZNjo60TM8Q%2f67LX2MYjz81O4oMgWH7cog6wRH0S";
        }

        public class ViewLocations
        {
            public static string _404 = "Content/html/shared/404";
        }

        public class Messages
        {
            public class Account
            {
                public class Login
                {
                    public static string MissingUsername =
                        "'Username' should not be empty.";
                    public static string MissingPassword =
                        "'Password' should not be empty.";
                    public static string MismatchedUsernamePassword =
                        "Username and/or password is not correct.";
                }

                public class Manage
                {
                    public static string MissingOldPassword =
                        "'OldPassword' should not be empty.";
                    public static string MissingNewPassword =
                        "'NewPassword' should not be empty.";
                    public static string MissingConfirmNewPassword =
                        "'ConfirmNewPassword' should not be empty.";
                    public static string InvalidOldPassword =
                        "Old password is not correct!";
                    public static string MismatchedPasswords =
                        "New passwords do not match!";
                    public static string SuccessPasswordChanged =
                        "Your password was updated successfully!";
                }

                public class Register
                {
                    public static string UserExists =
                        "User with username {0} already exists!";
                    public static string MismatchedPasswords =
                        "Passwords do not match!";
                }
            }

            public class Blog
            {
                public class New
                {
                    public static string SelectCategoryError =
                        "Please select a category.";
                    public static string EmptyTitleError =
                        "'Title' should not be empty.";
                    public static string EmptyContentError =
                        "'Content' should not be empty.";
                }
            }
        }
    }
}
