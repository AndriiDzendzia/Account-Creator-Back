using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace Account_Creator_Back.Services
{
    public class UserService
    {
        private readonly GraphServiceClient _graphServiceClient;

        public UserService(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }

        public Task<Microsoft.Graph.User> AddUser(User user)
        {
            var userToAdd = new Microsoft.Graph.User
            {
                DisplayName = user.GivenName + " " + user.Surname,
                GivenName = user.GivenName,
                Surname = user.Surname,
                Mail = user.Mail,
                JobTitle = user.JobTitle,
                OfficeLocation = user.OfficeLocation,
                PasswordProfile = new PasswordProfile
                {
                    ForceChangePasswordNextSignIn = false,
                    ForceChangePasswordNextSignInWithMfa = false,
                    Password = user.Password,
                },
                AccountEnabled = true,
                MailNickname = user.GivenName + user.Surname,
                UserPrincipalName = $"{user.GivenName}_{user.Surname}@SoftserveCarProject.onmicrosoft.com"
            };

            return _graphServiceClient.Users.Request().AddAsync(userToAdd);
        }
    }
}
