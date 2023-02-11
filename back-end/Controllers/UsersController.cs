using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace back_end.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("api/users")]
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select * from
                        users
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SettingAppCon");
            MySqlDataReader myReader;
            using(MySqlConnection mycon= new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }

        [Route("api/users")]
        [HttpPost]
        public JsonResult Post(Users user)
        {
            string query = @"
                        insert into users (MyEmail, MyPass) values
                                           (@MyEmail, @MyPass);
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SettingAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@MyEmail", user.MyEmail);
                    myCommand.Parameters.AddWithValue("@MyPass", user.MyPass);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added successfully");
        }
/* CITY */
        [Route("api/city")]
        [HttpPut]
        public JsonResult Put(Users user)
        {
            string query = @"
                        update users set 
                        City=@City
                        where MyEmail=@UserEmail;
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SettingAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    myCommand.Parameters.AddWithValue("@City", user.City);
                    myCommand.Parameters.AddWithValue("@UserEmail", user.MyEmail);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated successfully");
        }
/* TIMER */
        [Route("api/timer")]
        [HttpPut]
        public JsonResult PutTimer(Users user)
        {
            string query = @"
                        update users set 
                        Timer=@Timer
                        where MyEmail=@UserEmail;
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SettingAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    myCommand.Parameters.AddWithValue("@Timer", user.Timer);
                    myCommand.Parameters.AddWithValue("@UserEmail", user.MyEmail);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated successfully");
        }
/* APOD */
        [Route("api/apod")]
        [HttpPut]
        public JsonResult PutApod(Users user)
        {
            string query = @"
                        update users set 
                        Apod=@Apod
                        where MyEmail=@UserEmail;
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SettingAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    myCommand.Parameters.AddWithValue("@Apod", user.Apod);
                    myCommand.Parameters.AddWithValue("@UserEmail", user.MyEmail);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated successfully");
        }
/* ARTIST */
        [Route("api/artist")]
        [HttpPut]
        public JsonResult PutArtist(Users user)
        {
            string query = @"
                        update users set 
                        ArtistId=@ArtistId
                        where MyEmail=@UserEmail;
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SettingAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    myCommand.Parameters.AddWithValue("@ArtistId", user.ArtistId);
                    myCommand.Parameters.AddWithValue("@UserEmail", user.MyEmail);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated successfully");
        }
/* DEEZER TOKEN */
        [Route("api/deezertoken")]
        [HttpPut]
        public JsonResult PutDeezerToken(Users user)
        {
            string query = @"
                        update users set 
                        DeezerToken=@DeezerToken
                        where MyEmail=@UserEmail;
            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SettingAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@UserId", user.UserId);
                    myCommand.Parameters.AddWithValue("@DeezerToken", user.DeezerToken);
                    myCommand.Parameters.AddWithValue("@UserEmail", user.MyEmail);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated successfully");
        }
    }
}
