using mtsToolsWebAPI.Model;
using mtsToolsWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtsToolsWebAPI.Services
{
    public class UserService
    {
        private UserRepository userRepository = new UserRepository();
        public List<UserMenuItem> GetUserMenuTree(UserAccessRequest userAccessRequest)
        {
            return userRepository.GetUserMenuTree(userAccessRequest);
        }
    }
}
