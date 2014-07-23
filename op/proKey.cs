using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace op
{
    public class proKey
    {
        public  proKey(){}
        /// <summary>
        /// 返回 20项 与标题匹配的数据
        /// </summary>
        /// <param name="arr">标题</param>
        /// <param name="moLi">数据表</param>
        /// <returns></returns>
        public List<mo.products> stringInof(string title, List<mo.products> modelList)
        {
            List<mo.products> moLi = new List<mo.products>();
            string[] arr = title.Split(' ');
            int count = 0, index = 0 ;
            for (int i = modelList.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (modelList[i].nameC.IndexOf(arr[j]) >= 0)
                    {
                        count++;//权重值
                    }
                }
                if (count == 0)
                {
                    if (i <=20)//如果不足20项 则不筛选了
                        if (moLi.Count - 20 < 0)//如果搜索出来的不足20项
                        {
                            if (i == 20 - moLi.Count)//不足的项是否就等于生剩于的项
                            {
                                while (i>=0)
                                {
                                    moLi.Add(modelList[i]);
                                    moLi[index++].sortC = 0;
                                    i--;
                                }
                                    break;
                            }
                        }
                   // i--;//移除一项要调整索引
                }
                else
                {
                    moLi.Add(modelList[i]);
                    moLi[index++].sortC = count;//下标加1
                    count = 0;
                }

            }
            var p = from m in moLi orderby m.sortC descending select m;
            List<mo.products> s = new List<mo.products>();
            count = 20;
            foreach (var a in p)//按权重排序
            {
                if (count > 0)
                {
                    count--;
                    s.Add(a);
                }
                else
                    break;
            }
            return s;
        }
        /// <summary>
        /// 返回 20项 与标题匹配的数据
        /// </summary>
        /// <param name="arr">标题</param>
        /// <param name="moLi">数据表</param>
        /// <returns></returns>
        public List<mo.proInfo> strKey_info(string title, List<mo.proInfo> modelList)
        {
            List<mo.proInfo> moLi = new List<mo.proInfo>();
            string[] arr = title.Split(' ');
            int count = 0, index = 0;
            for (int i = modelList.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (modelList[i].nameC.IndexOf(arr[j]) >= 0)
                    {
                        count++;//权重值
                    }
                }
                if (count == 0)
                {
                    if (i <= 20)//如果不足20项 则不筛选了
                        if (moLi.Count - 20 < 0)//如果搜索出来的不足20项
                        {
                            if (i == 20 - moLi.Count)//不足的项是否就等于生剩于的项
                            {
                                while (i >= 0)
                                {
                                    moLi.Add(modelList[i]);
                                    moLi[index++].sortC = 0;
                                    i--;
                                }
                                break;
                            }
                        }
                    // i--;//移除一项要调整索引
                }
                else
                {
                    moLi.Add(modelList[i]);
                    moLi[index++].sortC = count;//下标加1
                    count = 0;
                }

            }
            var p = from m in moLi orderby m.sortC descending select m;
            List<mo.proInfo> s = new List<mo.proInfo>();
            count = 20;
            foreach (var a in p)//按权重排序
            {
                if (count > 0)
                {
                    count--;
                    s.Add(a);
                }
                else
                    break;
            }
            return s;
        }
    }
}
