using MVC_1.DAL;
using MVC_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_1.Services
{
    public class UserServices
    {
        UserDAL userdal = new UserDAL();

        public int insert(Users users)
        {
            return userdal.insert(users);
        }

        public int update(Users users)
        {
            return userdal.update(users);
        }

        public List<Users> userList()
        {
            return userdal.userList();
        }

        public List<Users> findByid(int id)
        {
            return userdal.findByid(id);
        }

        public int deleteByid(int id)
        {
            return userdal.delete(id);
        }

        public Users findByusrname(string usrName)
        {
            return userdal.findByusrname(usrName);
        }
    }
}