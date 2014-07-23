using System.Data;
using System.Web.Hosting;
using System.Security.Permissions;
using System.Text;
using System.Web.UI.WebControls;


namespace op
{
    public class ExtTree
    {
        private string _XMLpath;
        private static ExtTree extTree = null;

        public ExtTree()
        {
            string xmlpath = "~/app_data/tree.xml";
            _XMLpath = HostingEnvironment.MapPath(xmlpath);
            FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.Write, _XMLpath);
            permission.Demand();
        }

 

        private DataTable GetAllNodes()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(_XMLpath);
            return ds.Tables[0];
        }

        private DataTable GetAllNodes(string parentid)
        {
            DataTable dt = GetAllNodes();
            DataTable _dt = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["parentid"].ToString() == parentid.ToString())
                    _dt.Rows.Add(dr.ItemArray);
            }

            return _dt;
        }



        public string CreateExtTreeJSON()
        {
            StringBuilder sb = new StringBuilder();
            CreateExtTreeNode(sb);
            string s = sb.ToString();
            return s.Replace("}{", "},{");
        }
        /*
         * Ext Tree JSON 数据部分属性说明：
         * text: 要显示的节点文件
         * id:这个就不用解释了
         * href:链接地址
         * hrefTarget：链接目标框架名称
         * children:子节点 格式：[{节点1},{节点2}...]
         * leaf:当前节点是否为叶子节点。如果为false 则此节点有子节点。
         *                                  否则为true,此节点在无子节点
         * */
        private void CreateExtTreeNode(StringBuilder sb)
        {
            DataTable dt = GetAllNodes("0");
            if (dt.Rows.Count > 0)
            {
                sb.Append("[");
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("{");
                    sb.Append("text:'" + dr["title"].ToString() + "',");
                    sb.Append("id:'node" + dr["id"].ToString() + "'");
                    AddChildrenNode(GetAllNodes(dr["id"].ToString()), sb);
                    sb.Append("}");
                }
            }

            sb.Append("]");
        }

        private void AddChildrenNode(DataTable dt, StringBuilder sb)
        {
            if (dt.Rows.Count > 0)
            {
                sb.Append(",leaf:false,children:[");
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("{");
                    sb.Append("text:'" + dr["title"].ToString() + "',");
                    sb.Append("id:'node" + dr["id"].ToString() + "',");
                    sb.Append("href:'" + dr["url"].ToString() + "',");
                    sb.Append("hrefTarget:'main'");
                    AddChildrenNode(GetAllNodes(dr["id"].ToString()), sb);
                    sb.Append("}");
                }

                sb.Append("]");
            }
            else
                sb.Append(",leaf:true");
        }
    }

    /// <summary>
    /// MenuDAL 的摘要说明
    /// </summary>
    public class MenuDAL
    {
        private string _XMLpath;
        private static MenuDAL dal = null;
        private MenuDAL()
        {
            InitXMLpath();
        }

        public static MenuDAL Current
        {
            get
            {
                if (dal == null)
                    dal = new MenuDAL();

                return dal;
            }
        }

        private void InitXMLpath()
        {
            string xmlpath = "~/app_data/xmlmenus.xml";
            _XMLpath = HostingEnvironment.MapPath(xmlpath);
            FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.Write, _XMLpath);
            permission.Demand();
        }

        private DataTable GetAllMenus()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(_XMLpath);
            return ds.Tables[0];
        }

        private DataTable GetAllMenus(int parentid)
        {
            DataTable dt = GetAllMenus();
            DataTable _dt = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["parentid"].ToString() == parentid.ToString())
                    _dt.Rows.Add(dr.ItemArray);
            }

            return _dt;
        }

        public string CreateHTML()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = GetAllMenus(0);
            DataTable dt2 = null;
            string _tempHtml;
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("{title:'" + dr["title"].ToString() + "',autoScroll:true,border:false,iconCls:'nav',");

                dt2 = GetAllMenus(int.Parse(dr["id"].ToString()));
                if (dt2.Rows.Count > 0)
                {
                    _tempHtml = "<ul class=\"LeftNav\">";
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        _tempHtml += "<li><a target=\"main\" href=\"" + dr2["url"].ToString() + "\"> " + dr2["title"].ToString() + "</a></li>";
                    }

                    if (_tempHtml != "<ul>")
                    {
                        _tempHtml += "</ul>";
                        sb.Append("html:'" + _tempHtml + "'}");
                    }
                    else
                    {
                        sb.Append("html:''}");
                    }
                }
                else
                {
                    sb.Append("html:''}");
                }

                sb.Append(",");
            }

            return sb.ToString().TrimEnd(',');
        }

        public void BoundTree(TreeNodeCollection nodes)
        {
            DataTable dt = GetAllMenus(0);
            TreeNode tn = null;
            DataTable _dt = null;
            TreeNode _tn = null;
            foreach (DataRow dr in dt.Rows)
            {
                tn = new TreeNode();
                tn.Text = dr["title"].ToString();
                tn.Value = dr["id"].ToString();
                //tn.NavigateUrl = "";
                //tn.Target = "main";
                tn.SelectAction = TreeNodeSelectAction.SelectExpand;

                nodes.Add(tn);

                _dt = GetAllMenus(int.Parse(dr["id"].ToString()));
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dt.Rows)
                    {
                        _tn = new TreeNode();
                        _tn.Text = _dr["title"].ToString();
                        _tn.NavigateUrl = _dr["url"].ToString();
                        _tn.Target = "main";
                        _tn.Value = _dr["id"].ToString();
                        _tn.SelectAction = TreeNodeSelectAction.SelectExpand;
                        tn.ChildNodes.Add(_tn);
                    }
                }
            }
        }
    }
}
