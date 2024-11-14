using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace Victor
{
    /*
    <? xml version="1.0" encoding="UTF-8"?>
    <bookstore>
      <book category = "children" >
        < title lang="en">Harry Potter</title>
        <author>J.K.Rowling</author>
        <year>2005</year>
        <price>29.99</price>
      </book>
      <book category = "web" >
        < title lang= "en" > Learning XML</title>
        <author>Erik T. Ray</author>
        <year>2003</year>
        <price>39.95</price>
      </book>
    </bookstore>

*/
    public class CXml
    {
        private string m_sPath = "";
        private string m_sFilename = "";
        XmlDocument xmlDoc;//= new XmlDocument();

        public void LoadXml(string path)
        {
            string[] folderNames = path.Split('\\');
            string fullPath = string.Empty;
            for (int i = 0; i < folderNames.Length - 1; i++)
            {
                fullPath += folderNames[i] + '\\';
                DirectoryInfo di = new DirectoryInfo(fullPath);
                if (!di.Exists)
                {
                    di.Create();

                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(m_sFilename);
                }                
            }
        }

        /// <summary>
        /// 하위노드 리스트 가져오기
        /// </summary>
        public void Read()
        {
            XmlNodeList allNodes = xmlDoc.SelectNodes("//bookstore//*");
            StringBuilder sb = new StringBuilder();

            foreach (XmlNode node in allNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    sb.Append(node.InnerText);
                }
                else if (node.NodeType == XmlNodeType.Text)
                {
                    sb.Append(node.Value);
                }
                // sb.Append("\n");
                sb.Append(Environment.NewLine);
            }

            //this.result1.Text = sb.ToString();
        }

        /// <summary>
        /// Xml속성 가져오기
        /// </summary>
        public string GetAttribute()
        {
            XmlNode ctg_node = xmlDoc.SelectSingleNode("category");

            // 결과값 : category1
            string ctg_id = ctg_node.Attributes["id"].Value;
            return ctg_id;
        }

        /// <summary>
        /// 노드의 값 가져오기
        /// </summary>
        public string[] GetNode()
        {
            XmlNode name_node = xmlDoc.SelectSingleNode("category/name");
            string[] name_value = new string[2];
            // 결과값 : VS code

            name_value[0] = name_node.InnerText;
            name_value[1] = name_node.ChildNodes[0].InnerText;

            return name_value;
        }

    }
}

