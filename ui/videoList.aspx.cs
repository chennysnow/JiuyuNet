﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class videoList : System.Web.UI.Page
{
    public int i = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //dal.products pro = new dal.products();
            MySqlDal.ProductsDB pro = new MySqlDal.ProductsDB();
            List<mo.products> modelList = pro.getModelListWhere("top 15", "");
            repLeftMenu.DataSource = modelList;
            repLeftMenu.DataBind();

            //dal.link link = new dal.link();
            MySqlDal.LinkDB link = new MySqlDal.LinkDB();
            List<mo.link> modelLink = link.getModelListWhere("where typS='video'");
            repVideoList.DataSource = modelLink;
            repVideoList.DataBind();
        }
    }
}