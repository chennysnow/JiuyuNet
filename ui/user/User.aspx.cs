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
using System.Collections.Generic;

public partial class User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cook.userJudge();
        if (!IsPostBack)
        {
            MySqlDal.UserDB user = new MySqlDal.UserDB();
            mo.user model = user.getModel("where userName='" + cook.userJudge() + "'");
            txtName.Text = model.nameC == "0" ? "" : model.nameC;
            txtTel.Text = model.telC=="0"?"":model.telC;
            txtAdd.Text = model.addressC=="0"?"":model.addressC;
            ViewState["id"] = model.id;
            //dal.place place = new dal.place();
            MySqlDal.PlaceDB place = new MySqlDal.PlaceDB();
            dropCountry.Items.Add(new ListItem("Please select","0"));
            List<mo.place> modelList = place.getModelListAll();
            foreach (mo.place mo in modelList)
            {
                dropCountry.Items.Add(new ListItem(mo.nameC,mo.id.ToString()));
                if (mo.nameC == model.countryC)
                    dropCountry.SelectedValue = mo.id.ToString();
            }
            
        }
    }
    op.tipsMessage tips = new op.tipsMessage();
    /// <summary>
    /// 用户信息修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_userInfo_ok_Click(object sender, EventArgs e)
    {
        mo.user model = new mo.user();
        MySqlDal.UserDB user = new MySqlDal.UserDB();
        op.Operation ope = new op.Operation();
        model = user.getModel("where id=" + ViewState["id"].ToString());
        model.nameC = ope.StrEncode(txtName.Text);
        model.telC = ope.StrEncode(txtTel.Text);
        model.addressC = ope.StrEncode(txtAdd.Text);
        model.countryC = dropCountry.SelectedItem.Text;
        user.UpdateModel(model);
        op.staValue.divAlert(Page, "Change successful!", "order.aspx");
    }
   
}
