﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// from Additional Branch

namespace WebAddressbookTests
{
    public class AccountData

    {
        private string userName;
        private string password;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }

        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public AccountData(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
