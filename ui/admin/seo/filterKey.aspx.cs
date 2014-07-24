using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_seo_filterKey : System.Web.UI.Page
{
    class fileKey {
        public fileKey() { }
        public string nameC { get; set; }
        public string urlC { get; set; }
    }
    public int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.title = "关键词过滤";
        if (!IsPostBack)
        {
            bin();
        }
    }
    private void bin()
    {
        op.xml xml = new op.xml("allKey");
        string[] str = xml.getAllKey("filterKey").Split('|');
        List<fileKey> modelList = new List<fileKey>();
        for (int i = 0; i < str.Length; i++)
        {
            string[] arr = str[i].Split(',');
            fileKey model = new fileKey();
            model.nameC = arr[0];
            model.urlC = arr[1];
            modelList.Add(model);
        }
        repList.DataSource = modelList;
        repList.DataBind();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        op.xml xml = new op.xml("allKey");
        string[] name = Request.Form.GetValues("nameC");
        string[] url = Request.Form.GetValues("urlC");
        string str = "";
        for (int i = 0; i < name.Length; i++)
        {
            str += name[i]+","+url[i]+"|";
        }
        xml.setAllKey(str.TrimEnd('|'), "filterKey");
        op.staValue.divAlert(Page, "修改成功!",Request.Url.AbsoluteUri);
    }
    protected void btnRun_Click(object sender, EventArgs e)
    {
        switch (dropList.SelectedValue)
        {
            case "newsFilter": newsRun(0); break;
            case "newsFilterCantel": newsRun(1); break;
            case "newsFilterCantelKey": newsRun(2); break;
            case "proFilter": proRun(0); break;
            case "proFilterCantel": proRun(1); break;
            case "proFilterCantelKey": proRun(2); break;
            default: break;
        }
    }
    private void newsRun(int typ)
    {
        //dal.news news = new dal.news();
        dal.NewsDB news = new dal.NewsDB();
        List<mo.news> modelList = news.getModelListWhere("where typS='0'");
        switch (typ)
        {
            case 0:
                for (int i = 0; i < modelList.Count; i++)
                {
                    news.updateContent(filter(modelList[i].contentC, modelList[i].keywordsC), modelList[i].id);
                } break;
            case 1: 
                for (int i = 0; i < modelList.Count; i++)
                {
                    news.updateContent(cantelFilterA(modelList[i].contentC), modelList[i].id);
                }break;
            case 2:
                for (int i = 0; i < modelList.Count; i++)
                {
                    news.updateContent(cantelFilterT(modelList[i].contentC,modelList[i].keywordsC), modelList[i].id);
                }
                break;
        }
        op.staValue.divAlert(Page, "文章操作成功!");
    }
    private void proRun(int typ)
    {
        //dal.products pro = new dal.products();
        dal.ProductsDB pro = new dal.ProductsDB();
        System.Data.DataTable dt = pro.getTable("select preId,contentC,keywordsC  from proInfo");
        switch (typ)
        {
            case 0:
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pro.updateContent(filter(dt.Rows[i]["contentC"].ToString(), dt.Rows[i]["keywordsC"].ToString()), int.Parse(dt.Rows[i]["preId"].ToString()));
                } break;
            case 1:
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pro.updateContent(cantelFilterA(dt.Rows[i]["contentC"].ToString()), int.Parse(dt.Rows[i]["preId"].ToString()));
                } break;
            case 2:
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pro.updateContent(cantelFilterT(dt.Rows[i]["contentC"].ToString(), dt.Rows[i]["keywordsC"].ToString()), int.Parse(dt.Rows[i]["preId"].ToString()));
                }
                break;
        }
        op.staValue.divAlert(Page, "产品操作成功!");
    }
    private string filter(string str,string keywordsC)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(str.ToLower());
        string[] key = Request.Form.GetValues("nameC");
        string[] url = Request.Form.GetValues("urlC");
        
        int count = key.Length;
        int[] keyLen = new int[key.Length];//记录相似度
        char[][] keyChar=new char[key.Length][];//存储所有关键词的字符 

        for(int i=0;i<key.Length;i++)
        {
            keyChar[i]=key[i].ToCharArray();
            url[i]="<a href=\""+url[i]+"\">"+key[i]+"</a>";
            keyLen[i] = 0;
        }
        //加粗
        string[] keywords = keywordsC==""?new string[0]:keywordsC.Split(',');
        int countWords = keywords.Length;
        char[][] wordChar = new char[keywords.Length][];
        int[] wordLen = new int[keywords.Length];
        for (int i = 0; i < keywords.Length; i++)
        {
            wordChar[i] = keywords[i].ToCharArray();
            wordLen[i] = 0;
            keywords[i] = "<strong>" + keywords[i] + "</strong>";
        }

        int leng=sb.Length;
        int ji = 0;//记录增加的字符数
        bool flg = true;//判断是不是包在a标签里
        bool flgWords = true;
        for (int i = 0; i < leng; i++)
        {
            #region 判断有没有在标签内
            if (flg)//判断有没有在a标签里
            {
                if (sb.Length >= (i + ji + 3))
                {
                    string strTem = sb.ToString().Substring(i + ji,3);
                    if (strTem == "<a ")//进入A标签
                    {
                        flg = false;
                        i += 3;//跳过<a 这三个字符
                    }
                }
            }
            else
            {
                if (sb.Length >= (i + ji + 4))
                {
                    string strTem = sb.ToString().Substring(i + ji,4);
                    if (strTem == "</a>")//出A标签
                    {
                        flg = true;
                        i += 4;
                    }
                }
            }
            if (flgWords)//判断有没有在strong标签里
            {
                if (sb.Length >= (i + ji + 8))
                {
                    string strTem = sb.ToString().Substring(i + ji,8);
                    if (strTem == "<strong>")//进入strong标签
                    {
                        flgWords = false;
                        i += 8;//跳过<a 这三个字符
                    }
                }
            }
            else
            {
                if (sb.Length >= (i + ji + 9))
                {
                    string strTem = sb.ToString().Substring(i + ji,9);
                    if (strTem == "</strong>")//出A标签
                    {
                        flgWords = true;
                        i += 9;
                    }
                }
            }
            #endregion
            #region A标签处理
            //a标签查找
            for (int j = 0; j < count; j++)
            {
                ////////////////a标签过滤
                if (sb[i + ji] == keyChar[j][keyLen[j]])//此时sb的长度变了,所以要加上变大的字符数
                {
                    keyLen[j]++;//正确次数
                }
                else
                    keyLen[j] = 0;
                if (keyLen[j] == keyChar[j].Length)//正确次数=关键字长度
                {
                    if (flg)//不在a标签内
                    {
                        sb.Remove(i - keyLen[j] + 1 + ji, keyLen[j]);//移除原来的关键字
                        sb.Insert(i - keyLen[j] + 1 + ji, url[j]);//替换    插入位置=当前搜索位置-关键词长度+变长数
                        ji += url[j].Length - keyLen[j];//增加的长度  等于链接-关键字长度
                    }
                    keyLen[j] = 0;//清空,得以下次匹配
                    keyChar = remove(j, keyChar);
                    count--;
                }
            }
            #endregion
            #region strong标签
            //strong标签查找
            if (keywords.Length > 0)
            {
                for (int j = 0; j < countWords; j++)
                {
                    ////////////////strong标签过滤
                    if (sb[i + ji] == wordChar[j][wordLen[j]])//此时sb的长度变了,所以要加上变大的字符数
                    {
                        wordLen[j]++;//正确次数
                    }
                    else
                        wordLen[j] = 0;
                    if (wordLen[j] == wordChar[j].Length)//正确次数=关键字长度
                    {
                        if (flg)//不在a标签内
                        {
                            sb.Remove(i - wordLen[j] + 1 + ji, wordLen[j]);//移除原来的关键字
                            sb.Insert(i - wordLen[j] + 1 + ji, keywords[j]);//替换    插入位置=当前搜索位置-关键词长度+变长数
                            ji += keywords[j].Length - wordLen[j];//增加的长度  等于<strong>标签长度-关键字长度
                        }
                        wordLen[j] = 0;//清空,得以下次匹配
                        // keyChar = remove(j, keyChar);
                        //  count--;
                    }
                }
            }
            #endregion
        }
        return sb.ToString();
    }
    /// <summary>
    /// 移除已匹配过的关键词
    /// </summary>
    /// <param name="index"></param>
    /// <param name="keyChar"></param>
    /// <returns></returns>
    private char[][] remove(int index, char[][] keyChar)
    {
        char[][] copy = keyChar;
        for (int i = 0; i < keyChar.Length; i++)
        {
            if (i != index)
            {
                copy[i] = keyChar[i];
            }
        }
        return copy;
    }
    private string cantelFilterA(string str)
    {
        string[] key = Request.Form.GetValues("nameC");
        string[] url = Request.Form.GetValues("urlC");
        for(int i=0;i<key.Length;i++)
        {
            string stsd = "<a href=\"" + url[i] + "\">" + key[i] + "</a>";
            str = str.ToLower().Replace("<a href=\""+url[i]+"\">"+key[i]+"</a>",key[i]);
        }
        return str;
    }
    private string cantelFilterT(string str,string title)
    {
        string[] keywords = title == "" ? new string[0] : title.Split(',');
        for (int i = 0; i < keywords.Length; i++)
        {
            str = str.ToLower().Replace("<strong>" + keywords[i] + "</strong>", keywords[i]);
        }
        return str;
    }
}