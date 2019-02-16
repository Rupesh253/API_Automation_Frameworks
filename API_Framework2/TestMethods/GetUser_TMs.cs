
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using API_Framework2.TestResources;

namespace API_Framework2.TestMethods
{
    [TestFixture]
    public class GetUser_TMs
    {

        [Test]
        public void GetUsersMethod()
        {
            Users_TR users = new Users_TR();
            users.GetUsers();
        }
    }
}
