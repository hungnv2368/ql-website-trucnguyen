﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_TaiKhoan
    {
        public string IDUser { get; set; }
       
        public string Password { get; set; }
        public int Quyen { get; set; }
        public DTO_TaiKhoan(DataRow row)
        {
            this.IDUser = row["UserName"].ToString();
            this.Password = row["Password"].ToString();
            this.Quyen = (int)row["Quyen"];
        }

        public DTO_TaiKhoan(string iDUser, string password, int quyen)
        {
            this.IDUser = iDUser;
            this.Password = password;
            this.Quyen = quyen;

        }
    }
}
