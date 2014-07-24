using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;

public partial class demoupload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpPostedFile file;
        string str = Request.Url.Query;
        for (int i = 0; i < Request.Files.Count; ++i)
        {
            file = Request.Files[i];
        }
        if (!IsPostBack)
        {
            cook.adminJudge();
            ddlFileName.Items.Clear();
            ddlFileName.Items.Add(new ListItem("请选择文件夹", "0"));
            typBin();
        }
    }
    private void typBin()
    {
        string path = op.staValue.path + "uploadFile/";
        string[] strDr = Directory.GetDirectories(path);
        for (int i = 0; i < strDr.Length; i++)
        {
            string dirName = strDr[i].Substring(strDr[i].LastIndexOf("/") + 1);
            if (dirName == "sImg")
                continue;
            ddlFileName.Items.Add(new ListItem(dirName));
        }
    }
}
