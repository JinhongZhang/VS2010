using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Collections.ObjectModel;

namespace WebApplication1.Models
{
    public class CalResult
    {
        public int Number;
        public int CValue;
        public double PreTValue;
        public double TValue;
        public string Shang;
        private MyBaseEntities _db = null;

        public CalResult() { }

        public CalResult(MyBaseEntities db)
        {
            _db = db;
        }

        public List<CalResult> GeustNum()
        {

            var q = (from n in _db.NumTable
                     where n.flag == 0
                     orderby n.StartDate descending, n.Seq descending
                     select n
                     ).FirstOrDefault();
            if (q == null) return null;
            int la1 = q.Num1.Value;
            int la2 = q.Num2.Value;
            int la3 = q.Num3.Value;
            int la4 = q.Num4.Value;
            int la5 = q.Num5.Value;
            int la6 = q.Num6.Value;
            int la7 = q.NumSP.Value;
            int total = la1 + la2 + la3 + la4 + la5 + la6 + la7;
            int total_d1 = la2 + la3 + la4 + la5 + la6 + la7;
            int total_d2 = la1 + la3 + la4 + la5 + la6 + la7;
            int total_d3 = la1 + la2 + la4 + la5 + la6 + la7;
            int total_d4 = la1 + la2 + la3 + la5 + la6 + la7;
            int total_d5 = la1 + la2 + la3 + la4 + la6 + la7;
            int total_d6 = la1 + la2 + la3 + la4 + la5 + la7;
            int total_d7 = la1 + la2 + la3 + la4 + la5 + la6;

            

            string Shang = ((total / la1) - 1) % 10 + "-" + ((total / la2) - 1) % 10 + "-" + ((total / la3) - 1) % 10 + "-" + ((total / la4) - 1) % 10 + "-" + ((total / la5) - 1) % 10 + "-" + ((total / la6) - 1) % 10 + "-" + ((total / la7) - 1) % 10;
            ArrayList result = GetResult(la1, la2, la3, la4, la5, la6, la7, total);
            ArrayList allList = new ArrayList();
            allList = GetStringlist(result, allList);
            result.Sort();

            result = GetResult(la1, la2, la3, la4, la5, la6, la7, total_d1);
            allList = GetStringlist(result, allList);
            result.Sort();

            result = GetResult(la1, la2, la3, la4, la5, la6, la7, total_d2);
            allList = GetStringlist(result, allList);
            result.Sort();

            result = GetResult(la1, la2, la3, la4, la5, la6, la7, total_d3);
            allList = GetStringlist(result, allList);
            result.Sort();

            result = GetResult(la1, la2, la3, la4, la5, la6, la7, total_d4);
            allList = GetStringlist(result, allList);
            result.Sort();

            result = GetResult(la1, la2, la3, la4, la5, la6, la7, total_d5);
            allList = GetStringlist(result, allList);
            result.Sort();

            result = GetResult(la1, la2, la3, la4, la5, la6, la7, total_d6);
            allList = GetStringlist(result, allList);
            result.Sort();

            result = GetResult(la1, la2, la3, la4, la5, la6, la7, total_d7);
            allList = GetStringlist(result, allList);
            result.Sort();

            List<CalResult> list = GetDisTotal(allList);
            list[0].Shang = Shang;

            var m = (from n in _db.NumTable
                     where n.flag == 0 
                     orderby n.StartDate descending, n.Seq descending
                     select n
                     ).Take(10).ToList();
            
            int a1 = 0;
            int a2 = 0;
            int a3 = 0;
            int a4 = 0;
            int a5 = 0;
            int a6 = 0;
            int a7 = 0;
            int a8 = 0;
            int a9 = 0;
            int a10 = 0;
            for (int i = 0; i < m.Count(); i++)
            {
                int cal1 = m[i].Num1.Value;
                int cal2 = m[i].Num2.Value;
                int cal3 = m[i].Num3.Value;
                int cal4 = m[i].Num4.Value;
                int cal5 = m[i].Num5.Value;
                int cal6 = m[i].Num6.Value;
                int cal7 = m[i].NumSP.Value;
                if (cal1 % 10 == 1 || cal2 % 10 == 1 || cal3 % 10 == 1 || cal4 % 10 == 1 || cal5 % 10 == 1 || cal6 % 10 == 1 || cal7 % 10 == 1)
                {
                    a1++;
                }
                if (cal1 % 10 == 2 || cal2 % 10 == 2 || cal3 % 10 == 2 || cal4 % 10 == 2 || cal5 % 10 == 2 || cal6 % 10 == 2 || cal7 % 10 == 2)
                {
                    a2++;
                }
                if (cal1 % 10 == 3 || cal2 % 10 == 3 || cal3 % 10 == 3 || cal4 % 10 == 3 || cal5 % 10 == 3 || cal6 % 10 == 3 || cal7 % 10 == 3)
                {
                    a3++;
                }
                if (cal1 % 10 == 4 || cal2 % 10 == 4 || cal3 % 10 == 4 || cal4 % 10 == 4 || cal5 % 10 == 4 || cal6 % 10 == 4 || cal7 % 10 == 4)
                {
                    a4++;
                 }
                if (cal1 % 10 == 5 || cal2 % 10 == 5 || cal3 % 10 == 5 || cal4 % 10 == 5 || cal5 % 10 == 5 || cal6 % 10 == 5 || cal7 % 10 == 5)
                {
                    a5++;
                }
                if (cal1 % 10 == 6 || cal2 % 10 == 6 || cal3 % 10 == 6 || cal4 % 10 == 6 || cal5 % 10 == 6 || cal6 % 10 == 6 || cal7 % 10 == 6)
                {
                    a6++;
                }
                if (cal1 % 10 == 7 || cal2 % 10 == 7 || cal3 % 10 == 7 || cal4 % 10 == 7 || cal5 % 10 == 7 || cal6 % 10 == 7 || cal7 % 10 == 7)
                {
                    a7++;
                 }
                if (cal1 % 10 == 8 || cal2 % 10 == 8 || cal3 % 10 == 8 || cal4 % 10 == 8 || cal5 % 10 == 8 || cal6 % 10 == 8 || cal7 % 10 == 8)
                {
                    a8++;
                }
                if (cal1 % 10 == 9 || cal2 % 10 == 9 || cal3 % 10 == 9 || cal4 % 10 == 9 || cal5 % 10 == 9 || cal6 % 10 == 9 || cal7 % 10 == 9)
                {
                    a9++;
                }
                if (cal1 % 10 == 0 || cal2 % 10 == 0 || cal3 % 10 == 0 || cal4 % 10 == 0 || cal5 % 10 == 0 || cal6 % 10 == 0 || cal7 % 10 == 0)
                {
                    a10++;
                }

                if (i == 4)
                {
                    list[0].TValue = Math.Round(a1 * 1.0 / 5, 2);
                    list[1].TValue = Math.Round(a2 * 1.0 / 5, 2);
                    list[2].TValue = Math.Round(a3 * 1.0 / 5, 2);
                    list[3].TValue = Math.Round(a4 * 1.0 / 5, 2);
                    list[4].TValue = Math.Round(a5 * 1.0 / 5, 2);
                    list[5].TValue = Math.Round(a6 * 1.0 / 5, 2);
                    list[6].TValue = Math.Round(a7 * 1.0 / 5, 2);
                    list[7].TValue = Math.Round(a8 * 1.0 / 5, 2);
                    list[8].TValue = Math.Round(a9 * 1.0 / 5, 2);
                    list[9].TValue = Math.Round(a10 * 1.0 / 5, 2);
                }
            }

            list[0].PreTValue = Math.Round(a1 * 1.0 / 10, 2);
            list[1].PreTValue = Math.Round(a2 * 1.0 / 10, 2);
            list[2].PreTValue = Math.Round(a3 * 1.0 / 10, 2);
            list[3].PreTValue = Math.Round(a4 * 1.0 / 10, 2);
            list[4].PreTValue = Math.Round(a5 * 1.0 / 10, 2);
            list[5].PreTValue = Math.Round(a6 * 1.0 / 10, 2);
            list[6].PreTValue = Math.Round(a7 * 1.0 / 10, 2);
            list[7].PreTValue = Math.Round(a8 * 1.0 / 10, 2);
            list[8].PreTValue = Math.Round(a9 * 1.0 / 10, 2);
            list[9].PreTValue = Math.Round(a10 * 1.0 / 10, 2);

            return list;
        }

        private List<CalResult> getTrend(List<CalResult> rList)
        {
            return rList;
        }
        private List<CalResult> GetDisTotal(ArrayList list)
        {
            List<CalResult> rList = new List<Models.CalResult>();
            for (int i = 1; i <= 10; ++i)
            {
                CalResult r = new Models.CalResult();
                r.Number = i;
                r.CValue = 0;
                rList.Add(r);
            }
            foreach (int ss in list)
            {
                if (ss == 1)
                {
                    rList[0].CValue++;
                }
                else if (ss == 2)
                {
                    rList[1].CValue++;
                }
                else if (ss == 3)
                {
                    rList[2].CValue++;
                }
                else if (ss == 4)
                {
                    rList[3].CValue++;
                }
                else if (ss == 5)
                {
                    rList[4].CValue++;
                }
                else if (ss == 6)
                {
                    rList[5].CValue++;
                }
                else if (ss == 7)
                {
                    rList[6].CValue++;
                }
                else if (ss == 8)
                {
                    rList[7].CValue++;
                }
                else if (ss == 9)
                {
                    rList[8].CValue++;
                }

                else if (ss == 0)
                {
                    rList[9].CValue++;
                }
            }

            return rList;
        }

        private ArrayList GetStringlist(ArrayList list, ArrayList result)
        {
            foreach (int ss in list)
            {
                result.Add(ss % 10);
            }
            return result;
        }

        private ArrayList GetResult(int la1, int la2, int la3, int la4, int la5, int la6, int la7, int total)
        {
            int fenzi1 = total / la1;
            int fenzi2 = total / la2;
            int fenzi3 = total / la3;
            int fenzi4 = total / la4;
            int fenzi5 = total / la5;
            int fenzi6 = total / la6;
            int fenzi7 = total / la7;
            int fenmu1 = total % la1;
            int fenmu2 = total % la2;
            int fenmu3 = total % la3;
            int fenmu4 = total % la4;
            int fenmu5 = total % la5;
            int fenmu6 = total % la6;
            int fenmu7 = total % la7;

            int p1 = la1 + fenzi1 - fenmu1;
            int p2 = la2 + fenzi2 - fenmu2;
            int p3 = la3 + fenzi3 - fenmu3;
            int p4 = la4 + fenzi4 - fenmu4;
            int p5 = la5 + fenzi5 - fenmu5;
            int p6 = la6 + fenzi6 - fenmu6;
            int p7 = la7 + fenzi7 - fenmu7;

            Item item1 = new Item();
            item1.Kbs = p1;
            item1.Fenzi = fenzi1;
            item1.Fenmu = fenmu1;

            Item item2 = new Item();
            item2.Kbs = p2;
            item2.Fenzi = fenzi2;
            item2.Fenmu = fenmu2;
            Item item3 = new Item();
            item3.Kbs = p3;
            item3.Fenzi = fenzi3;
            item3.Fenmu = fenmu3;
            Item item4 = new Item();
            item4.Kbs = p4;
            item4.Fenzi = fenzi4;
            item4.Fenmu = fenmu4;
            Item item5 = new Item();
            item5.Kbs = p5;
            item5.Fenzi = fenzi5;
            item5.Fenmu = fenmu5;
            Item item6 = new Item();
            item6.Kbs = p6;
            item6.Fenzi = fenzi6;
            item6.Fenmu = fenmu6;
            Item item7 = new Item();
            item7.Kbs = p7;
            item7.Fenzi = fenzi7;
            item7.Fenmu = fenmu7;
            item1.Old = la1;
            item2.Old = la2;
            item3.Old = la3;
            item4.Old = la4;
            item5.Old = la5;
            item6.Old = la6;
            item7.Old = la7;
            Collection<Item> list = new Collection<Item>();
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Add(item4);
            list.Add(item5);
            list.Add(item6);
            list.Add(item7);


            return GetGuessResult(list);

        }

        private ArrayList GetGuessResult(Collection<Item> list)
        {
            ArrayList resultList = new ArrayList();
            for (int i = 0; i < list.Count - 1; i++)
            {

                if (list[i].Fenzi == list[i].Fenmu)
                {
                    if (list[i].Fenzi != 0)
                    {
                        resultList.Add(list[i].Fenzi);
                    }
                    if ((list[i].Fenzi + list[i].Fenmu) < 50)
                    {
                        resultList.Add(list[i].Fenzi + list[i].Fenmu);
                    }
                    resultList.Add(list[i].Old);
                    if ((list[i].Old + list[i].Fenzi) < 50)
                    {
                        resultList.Add(list[i].Old + list[i].Fenzi);
                    }
                    if (list[i].Old != list[i].Fenzi)
                    {
                        resultList.Add(list[i].Old - list[i].Fenzi);
                    }
                }
                for (int j = i + 1; j < list.Count; j++)
                {

                    if (list[i].Kbs == list[j].Kbs)
                    {
                        if ((list[i].Fenzi + list[j].Fenzi) < 50)
                        {
                            resultList.Add(list[i].Fenzi + list[j].Fenzi);
                        }
                        if (list[i].Fenzi == list[j].Fenzi)
                        {
                            if (list[i].Fenzi != 0)
                            {
                                resultList.Add(list[i].Fenzi);
                            }
                        }
                        else
                        {
                            if (list[i].Fenzi != list[j].Fenzi)
                            {
                                resultList.Add(Math.Abs(list[i].Fenzi - list[j].Fenzi));
                            }
                        }
                        if ((list[i].Fenmu + list[j].Fenmu) < 50)
                        {
                            if ((list[i].Fenmu + list[j].Fenmu) != 0)
                            {
                                resultList.Add(Math.Abs(list[i].Fenmu + list[j].Fenmu));
                            }
                        }

                        if (list[i].Fenmu == list[j].Fenmu && list[i].Fenmu != 0)
                        {
                            resultList.Add(list[i].Fenmu);
                        }
                        else
                        {
                            if (list[i].Fenmu != list[j].Fenmu)
                            {
                                resultList.Add(Math.Abs(list[i].Fenmu - list[j].Fenmu));
                            }
                        }
                        if ((list[i].Fenzi + list[j].Fenzi + list[i].Fenmu + list[j].Fenmu) < 50)
                        {
                            resultList.Add(list[i].Fenzi + list[j].Fenzi + list[i].Fenmu + list[j].Fenmu);
                        }

                        if ((list[i].Fenzi + list[j].Fenzi + list[i].Fenmu + list[j].Fenmu - list[i].Kbs) > 0 && (list[i].Fenzi + list[j].Fenzi + list[i].Fenmu + list[j].Fenmu - list[i].Kbs) < 50)
                        {
                            resultList.Add(list[i].Fenzi + list[j].Fenzi + list[i].Fenmu + list[j].Fenmu - list[i].Kbs);
                        }
                        if (list[i].Fenzi + list[j].Fenzi > list[i].Fenmu + list[j].Fenmu)
                        {
                            resultList.Add(list[i].Fenzi + list[j].Fenzi - (list[i].Fenmu + list[j].Fenmu));
                        }
                        if (list[i].Fenzi == list[j].Fenmu && list[i].Fenmu == list[j].Fenzi)
                        {
                            resultList.Add(list[i].Fenzi);
                            resultList.Add(list[i].Fenmu);
                            if ((list[i].Fenzi + list[i].Fenmu) < 50)
                            {
                                resultList.Add(list[i].Fenzi + list[i].Fenmu);
                            }
                            if (list[i].Fenzi != list[i].Fenmu)
                            {
                                resultList.Add(Math.Abs(list[i].Fenzi - list[i].Fenmu));
                            }
                        }
                    }
                }
            }
            return resultList;
        }


    }

    public class Item
    {
        private int kbs;

        public int Kbs
        {
            get { return kbs; }
            set { kbs = value; }
        }
        private int fenzi;

        public int Fenzi
        {
            get { return fenzi; }
            set { fenzi = value; }
        }
        private int fenmu;

        public int Fenmu
        {
            get { return fenmu; }
            set { fenmu = value; }
        }
        private int old;

        public int Old
        {
            get { return old; }
            set { old = value; }
        }
    }
}