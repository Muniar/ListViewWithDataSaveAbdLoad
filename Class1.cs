using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyListViewItems
{
    public class MyListViewItemslass: System.Windows.Forms.ListView 
    {
        public MyListViewItemslass()
        {
            myFileFilterString = "列表数据文件(*.lst)|*.lst";
        }

        public MyListViewItemslass(string FileFilterString)
        {
            myFileFilterString = FileFilterString;
        }

        string myFileFilterString;


        public void SaveData()
        {
            if(this.Items.Count>=0)
            {
                string tmpStr = "";
                for (int i = 0; i < this.Items.Count; i++)
                {
                    for (int j = 0; j < this.Columns.Count; j++)
                    {
                        tmpStr += this.Items[i].SubItems[j].Text + ",";
                    }
                }

                System.Windows.Forms.SaveFileDialog o = new System.Windows.Forms.SaveFileDialog();
                o.Filter = myFileFilterString;
                if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using(System.IO.StreamWriter sw = new System.IO.StreamWriter(o.FileName, false))
                    {
                        sw.Write(tmpStr);
                    } 
                } 
            }
        }

        public void SaveData(string filename)
        {
            if (this.Items.Count >= 0)
            {
                string tmpStr = "";
                for (int i = 0; i < this.Items.Count; i++)
                {
                    for (int j = 0; j < this.Columns.Count; j++)
                    {
                        tmpStr += this.Items[i].SubItems[j].Text + ",";
                    }
                }
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, false))
                {
                    sw.Write(tmpStr);
                }

                //System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, false);
                //sw.Write(tmpStr);
                //sw.Close();
                //sw.Dispose();
                //sw = null;
            }
        }

        public void LoadData(string filename)
        {
            string tmpStr = ""; 

            using (System.IO.StreamReader sw = new System.IO.StreamReader(filename))
            {
                tmpStr = sw.ReadToEnd();
            } 

            string[] tmpSplitStr = tmpStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tmpSplitStr.Length / this.Columns.Count; i++)
            {
                System.Windows.Forms.ListViewItem item1 = new System.Windows.Forms.ListViewItem();
                item1.Text = tmpSplitStr[this.Columns.Count * i];
                for (int j = 1; j < this.Columns.Count; j++)
                {
                    item1.SubItems.Add(tmpSplitStr[this.Columns.Count * i + j]);
                }
                this.Items.Add(item1);
            }
        }

        public void LoadData()
        {
            System.Windows.Forms.OpenFileDialog o = new System.Windows.Forms.OpenFileDialog();
            o.Filter = myFileFilterString;
            if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                System.IO.StreamReader sr = new System.IO.StreamReader(o.FileName);
                string tmpStr = sr.ReadLine();
                sr.Close();
                sr.Dispose();
                sr = null;

                string[] tmpSplitStr = tmpStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tmpSplitStr.Length / this.Columns.Count; i++)
                {
                    System.Windows.Forms.ListViewItem item1 = new System.Windows.Forms.ListViewItem();
                    item1.Text = tmpSplitStr[this.Columns.Count * i];
                    for (int j = 1; j < this.Columns.Count; j++)
                    {
                        item1.SubItems.Add(tmpSplitStr[this.Columns.Count * i + j]);
                    }
                    this.Items.Add(item1);
                }
            }
        }
    }
}
