namespace Academy.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Models.Abstractions;

    internal class UserMock : User
    {
        public UserMock(string username)
            : base(username)
        {

        }
    }
}
