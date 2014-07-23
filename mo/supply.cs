using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mo
{
  public  class supply
    { 
     public supply(){}
     public int id { get; set; }
     public string  sname { get; set; }
     public string  contactus { get; set; }
     public string phone  { get; set; }
     public string address  { get; set; }
     public string  mail { get; set; }
     public string  agentyp { get; set; }//(改为:自动添加字段 的ID)
     public string  abrand { get; set; }//代理品牌(改为:自动添加字段 的名称)
     public string  Banks { get; set; }
     public string  account { get; set; }
     public string  raddress { get; set; }
     public string rcontact  { get; set; }
     public string  rphone { get; set; }
     public string  times { get; set; }
     public string  note1 { get; set; }//传真
     public string  note2 { get; set; }
     public string  note3 { get; set; }
     public string note4 { get; set; }

    }
}


