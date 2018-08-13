using System;
using System.Collections.Generic;

namespace DemoqaRegister.UserRegData
{
    public class UserRegistration
    {
        private string firstName;
        private string lastName;
        private List<bool> martialStatus;
        private List<bool> hobbys;
        private string country;
        private string birthMonth;
        private string birthDay;
        private string birthYear;
        private string phone;
        private string userName;
        private string email;
        private string profilePicture;
        private string aboutYourself;
        private string password;
        private string confirmPassword;

        public UserRegistration(String firstName,
            String lastName,
            List<bool> martialStatus,
            List<bool> hobbys,
            String country,
            String birthMonth,
            String birthDay,
            String birthYear,
            String phone,
            String userName,
            String email,
            String profilePicture,
            String aboutYourself,
            String password,
            String confirmPassword)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.martialStatus = martialStatus;
            this.hobbys = hobbys;
            this.country = country;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.phone = phone;
            this.userName = userName;
            this.email = email;
            this.profilePicture = profilePicture;
            this.aboutYourself = aboutYourself;
            this.password = password;
            this.confirmPassword = confirmPassword;
        }

        public string FirstName => firstName;

        public string LastName => lastName;

        public List<bool> MartialStatus => martialStatus;

        public List<bool> Hobbys => hobbys;

        public string Country => country;

        public string BirthMonth => birthMonth;

        public string BirthDay => birthDay;

        public string BirthYear => birthYear;

        public string Phone => phone;

        public string UserName => userName;

        public string Email => email;

        public string ProfilePicture => profilePicture;

        public string AboutYourself => aboutYourself;

        public string Password => password;

        public string ConfirmPassword => confirmPassword;
    }
}

