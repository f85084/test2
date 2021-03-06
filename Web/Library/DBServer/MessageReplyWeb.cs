﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class MessageWeb
    {
        string connectionString =
        ConfigurationManager.ConnectionStrings["WebContext"].ConnectionString;

        public IEnumerable<Message> Messages
        {
            get;
            set;
        }

        DateTime dt = DateTime.Now; //現在時間 

        #region 讀取
        public IEnumerable<Message> GetMessages()
        {
            List<Message> messages = new List<Message>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Message message = new Message();
                    message.Id = Convert.ToInt32(rdr["Id"]);
                    message.UserId = Convert.ToInt32(rdr["UserId"]);
                    message.UserName = rdr["UserName"].ToString();
                    message.Context = rdr["Context"].ToString();
                    message.CreatDate = Convert.ToDateTime(rdr["CreatDate"]);
                    messages.Add(message);
                }
            }
            return messages;
        }
        #endregion


        #region 新增留言
        public void AddMessage(Message message)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddMessage", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sqlParamUserId = new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = message.UserId
                };
                cmd.Parameters.Add(sqlParamUserId);

                SqlParameter sqlParamUserName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = message.UserName
                };
                cmd.Parameters.Add(sqlParamUserName);

                SqlParameter sqlParamContext = new SqlParameter
                {
                    ParameterName = "@Context",
                    Value = message.Context
                };
                cmd.Parameters.Add(sqlParamContext);

                SqlParameter sqlParamCreatDate = new SqlParameter
                {
                    ParameterName = "@CreatDate",
                    Value = dt
                };
                cmd.Parameters.Add(sqlParamCreatDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region 新增留言
        public void SaveMessage(Message message)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveMessage", con)
                {
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter sqlParamUserId = new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = message.UserId
                };
                cmd.Parameters.Add(sqlParamUserId);

                SqlParameter sqlParamUserName = new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = message.UserName
                };
                cmd.Parameters.Add(sqlParamUserName);

                SqlParameter sqlParamContext = new SqlParameter
                {
                    ParameterName = "@Context",
                    Value = message.Context
                };
                cmd.Parameters.Add(sqlParamContext);

                SqlParameter sqlParamCreatDate = new SqlParameter
                {
                    ParameterName = "@CreatDate",
                    Value = dt
                };
                cmd.Parameters.Add(sqlParamCreatDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        public void DeleteMessage(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteMessage", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParamId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(sqlParamId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}