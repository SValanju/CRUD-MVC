using MVC_1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_1.DAL
{
    public class UserDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbName"].ConnectionString);

        public int insert(Users users)
        {
            try
            {
                string passHash = BCrypt.Net.BCrypt.HashPassword(users.password);
                string sql = "insert into MVCUsers(Name,UserName,Email,PhoneNumber,Password) values('" + users.name + "', '" + users.usrName + "', '" + users.email + "','" + users.cnum + "', '" + passHash + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        public int update(Users users)
        {
            try
            {
                string sql = "update MVCUsers set Name='" + users.name + "', UserName='" + users.usrName + "', Email='" + users.email + "', PhoneNumber='" + users.cnum + "' where ID='" + users.id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        public int delete(int id)
        {
            try
            {
                string sql = "delete from MVCUsers where ID='" + id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int status = cmd.ExecuteNonQuery();
                if (status > 0)
                {
                    return status;
                }
                else
                {
                    return status;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        public List<Users> userList()
        {
            List<Users> userList = new List<Users>();
            try
            {
                string sql = "select ID, Name, UserName, Email, PhoneNumber from MVCUsers where ActiveStatus=1";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Users usr = new Users();
                                usr.id = Convert.ToInt32(dr[0].ToString());
                                usr.name = dr[1].ToString();
                                usr.usrName = dr[2].ToString();
                                usr.email = dr[3].ToString();
                                usr.cnum = dr[4].ToString();
                                userList.Add(usr);
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            
            return userList;
        }


        public List<Users> findByid(int id)
        {
            List<Users> userList = new List<Users>();
            try
            {
                string sql = "select ID, Name, UserName, Email, PhoneNumber from MVCUsers where ID='" + id + "' and Active_status=1";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                Users usr = new Users();
                                usr.id = Convert.ToInt32(dr[0].ToString());
                                usr.name = dr[1].ToString();
                                usr.usrName = dr[2].ToString();
                                usr.email = dr[3].ToString();
                                usr.cnum = dr[4].ToString();
                                userList.Add(usr);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return userList;
        }

        public Users findByusrname(string usrName)
        {
            string sql = "select usr.ID, usr.UserName, usr.password, rl.RoleName from MVCUsers usr inner join UsrRole rl on usr.RoleID=rl.ID where usr.UserName = '" + usrName + "'";
            con.Open();
            Users usr = new Users();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                       
                        foreach (DataRow dr in dt.Rows)
                        {
                            usr.id = Convert.ToInt32(dr[0].ToString());
                            usr.usrName = dr[1].ToString();
                            usr.password = dr[2].ToString();
                            usr.role = dr[3].ToString();
                        }
                    }
                }
            }
            con.Close();
            return usr;
        }
    }
}