﻿namespace WebServiceVM.WebAPI.Controllers.WebClientController
{
    public class AddWebClientRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
    }
}