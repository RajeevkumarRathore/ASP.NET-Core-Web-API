﻿namespace Application.EmailModels
{
    public class UserEmailConfirmationModel
    {
       public string Name { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public string EmailConfirmationUrl { get; set; }
    }
}
