using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;


namespace WebUtility.Helper
{
    public class XMLObject
    {
        //����Ϊ��һ���ܵľ�̬��
        
        #region ��ȡXML��DataSet
        /**//**************************************************
         * ��������:GetXml(string XmlPath)
         * ����˵��:��ȡXML��DataSet
         * ��    ��:XmlPath:xml�ĵ�·��
         * ʹ��ʾ��:
         *          using EC; //���������ռ�
         *          string xmlPath = Server.MapPath("/EBDnsConfig/DnsConfig.xml"); //��ȡxml·��
         *          DataSet ds = EC.XmlObject.GetXml(xmlPath); //��ȡxml��DataSet��
         ************************************************/
        /**//// <summary>
        /// ����:��ȡXML��DataSet��
        /// </summary>
        /// <param name="XmlPath">xml·��</param>
        /// <returns>DataSet</returns>
        public static DataSet GetXml(string XmlPath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(@XmlPath);
            return ds;
        }
        #endregion

        #region ��ȡxml�ĵ�������һ���ڵ�
        /**//**************************************************
         * ��������:ReadXmlReturnNode(string XmlPath,string Node)
         * ����˵��:��ȡxml�ĵ�������һ���ڵ�:������һ���ڵ�
         * ��    ��: XmlPath:xml�ĵ�·��;Node ���صĽڵ����� 
         * ��Ӧ��Xml:<?xml version="1.0" encoding="utf-8" ?>
         *           <root>
         *               <dns1>ns1.everdns.com</dns1>
         *          </root>
         * ʹ��ʾ��:
         *          using EC; //���������ռ�
         *          string xmlPath = Server.MapPath("/EBDnsConfig/DnsConfig.xml"); //��ȡxml·��
         *          Response.Write(XmlObject.ReadXmlReturnNode(xmlPath, "mailmanager"));
         ************************************************/
        /**//// <summary>
        /// ��ȡxml�ĵ�������һ���ڵ�:������һ���ڵ�
        /// </summary>
        /// <param name="XmlPath">xml·��</param>
        /// <param name="NodeName">�ڵ�</param>
        /// <returns></returns>
        public static string ReadXmlReturnNode(string XmlPath,string Node)
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(@XmlPath);
            XmlNodeList xn = docXml.GetElementsByTagName(Node);
            return xn.Item(0).InnerText.ToString();           
        }
        #endregion

        #region ��������,����һ��DataSet
        /**//**************************************************
         * ��������:GetXmlData(string xmlPath, string XmlPathNode)
         * ����˵��:��������,���ص�ǰ�ڵ�������¼��ڵ�,��䵽һ��DataSet��
         * ��    ��:xmlPath:xml�ĵ�·��;XmlPathNode:��ǰ�ڵ��·��
         * ʹ��ʾ��:
         *          using EC; //���������ռ�
         *          string xmlPath = Server.MapPath("/EBDomainConfig/DomainConfig.xml"); //��ȡxml·��
         *          DataSet ds = new DataSet();
         *          ds = XmlObject.GetXmlData(xmlPath, "root/items");//��ȡ��ǰ·��
         *          this.GridView1.DataSource = ds;
         *          this.GridView1.DataBind();
         *          ds.Clear();
         *          ds.Dispose();
         * Xmlʾ��:
         *         <?xml version="1.0" encoding="utf-8" ?>
         *            <root>
         *              <items name="xinnet">
         *                <url>http://www.paycenter.com.cn/cgi-bin/</url>
         *                <port>80</port>
         *              </items>
         *            </root>
         ************************************************/
        /// <summary>
        /// ��������,���ص�ǰ�ڵ�������¼��ڵ�,��䵽һ��DataSet��
        /// </summary>
        /// <param name="xmlPath">xml�ĵ�·��</param>
        /// <param name="XmlPathNode">�ڵ��·��:���ڵ�/���ڵ�/��ǰ�ڵ�</param>
        /// <returns></returns>
        public static DataSet GetXmlData(string xmlPath, string XmlPathNode)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);
            DataSet ds = new DataSet();
            StringReader read = new StringReader(objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds;        
        }


        #endregion

        #region ����Xml�ڵ�����
        /**//**************************************************
         * ��������:XmlNodeReplace(string xmlPath,string Node,string Content)
         * ����˵��:����Xml�ڵ�����
         * ��    ��:xmlPath:xml�ĵ�·��;Node:��ǰ�ڵ��·��;Content:����
         * ʹ��ʾ��:
         *          using EC; //���������ռ�
         *          string xmlPath = Server.MapPath("/EBDomainConfig/DomainConfig.xml"); //��ȡxml·��
         *          XmlObject.XmlNodeReplace(xmlPath, "root/test", "56789");  //���½ڵ�����
         ************************************************/
        /**//// <summary>
        /// ����Xml�ڵ�����
        /// </summary>
        /// <param name="xmlPath">xml·��</param>
        /// <param name="Node">Ҫ�������ݵĽڵ�:�ڵ�·�� ���ڵ�/���ڵ�/��ǰ�ڵ�</param>
        /// <param name="Content">�µ�����</param>
        public static void XmlNodeReplace(string xmlPath,string Node,string Content)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);
            objXmlDoc.SelectSingleNode(Node).InnerText = Content;
            objXmlDoc.Save(xmlPath);
            
        }

        #endregion

        #region ɾ��XML�ڵ�ʹ˽ڵ��µ��ӽڵ�
        /**//**************************************************
         * ��������:XmlNodeDelete(string xmlPath,string Node)
         * ����˵��:ɾ��XML�ڵ�ʹ˽ڵ��µ��ӽڵ�
         * ��    ��:xmlPath:xml�ĵ�·��;Node:��ǰ�ڵ��·��;
         * ʹ��ʾ��:
         *          using EC; //���������ռ�
         *          string xmlPath = Server.MapPath("/EBDomainConfig/DomainConfig.xml"); //��ȡxml·��
         *          XmlObject.XmlNodeDelete(xmlPath, "root/test");  //ɾ����ǰ�ڵ�
         ************************************************/
        /**//// <summary>
        /// ɾ��XML�ڵ�ʹ˽ڵ��µ��ӽڵ�
        /// </summary>
        /// <param name="xmlPath">xml�ĵ�·��</param>
        /// <param name="Node">�ڵ�·��</param>
        public static void XmlNodeDelete(string xmlPath,string Node)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);
            string mainNode = Node.Substring(0, Node.LastIndexOf("/"));
            objXmlDoc.SelectSingleNode(mainNode).RemoveChild(objXmlDoc.SelectSingleNode(Node));
            objXmlDoc.Save(xmlPath);
        }

        #endregion

        #region ����һ���ڵ�ʹ˽ڵ���ֽڵ�
        /**//**************************************************
         * ��������:XmlInsertNode(string xmlPath, string MailNode, string ChildNode, string Element,string Content)
         * ����˵��:����һ���ڵ�ʹ˽ڵ���ֽڵ�
         * ��    ��:xmlPath:xml�ĵ�·��;MailNode:��ǰ�ڵ��·��;ChildNode:�²���Ľڵ�;Element:����ڵ���ӽڵ�;Content:�ӽڵ������
         * ʹ��ʾ��:
         *          using EC; //���������ռ�
         *          string xmlPath = Server.MapPath("/EBDomainConfig/DomainConfig.xml"); //��ȡxml·��
         *          XmlObject.XmlInsertNode(xmlPath, "root/test","test1","test2","��������");  //����һ���ڵ�ʹ˽ڵ���ֽڵ�
         * ���ɵ�XML��ʽΪ
         *          <test>
         *               <test1>
         *                    <test2>��������</test2>
         *                </test1>
         *            </test>
         ************************************************/
        /**//// <summary>
        /// ����һ���ڵ�ʹ˽ڵ���ֽڵ�
        /// </summary>
        /// <param name="xmlPath">xml·��</param>
        /// <param name="MailNode">��ǰ�ڵ�·��</param>
        /// <param name="ChildNode">�²���ڵ�</param>
        /// <param name="Element">����ڵ���ӽڵ�</param>
        /// <param name="Content">�ӽڵ������</param>
        public static void XmlInsertNode(string xmlPath, string MailNode, string ChildNode, string Element,string Content)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);
            XmlNode objRootNode = objXmlDoc.SelectSingleNode(MailNode);
            XmlElement objChildNode = objXmlDoc.CreateElement(ChildNode);
            objRootNode.AppendChild(objChildNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objChildNode.AppendChild(objElement);
            objXmlDoc.Save(xmlPath);
        }

        #endregion

        #region ����һ�ڵ�,��һ����
        /**//**************************************************
         * ��������:XmlInsertElement(string xmlPath, string MainNode, string Element, string Attrib, string AttribContent, string Content)
         * ����˵��:����һ�ڵ�,��һ����
         * ��    ��:xmlPath:xml�ĵ�·��;MailNode:��ǰ�ڵ��·��;Element:�²���Ľڵ�;Attrib:��������;AttribContent:����ֵ;Content:�ڵ������
         * ʹ��ʾ��:
         *          using EC; //���������ռ�
         *          string xmlPath = Server.MapPath("/EBDomainConfig/DomainConfig.xml"); //��ȡxml·��
         *         XmlObject.XmlInsertElement(xmlPath, "root/test", "test1", "Attrib", "����ֵ", "�ڵ�����");  //����һ�ڵ�,��һ����
         * ���ɵ�XML��ʽΪ
         *          <test>
         *              <test1 Attrib="����ֵ">�ڵ�����</test1>
         *          </test>
         ************************************************/
        /**//// <summary>
        /// ����һ�ڵ�,��һ����
        /// </summary>
        /// <param name="xmlPath">Xml�ĵ�·��</param>
        /// <param name="MainNode">��ǰ�ڵ�·��</param>
        /// <param name="Element">�½ڵ�</param>
        /// <param name="Attrib">��������</param>
        /// <param name="AttribContent">����ֵ</param>
        /// <param name="Content">�½ڵ�ֵ</param>
        public static void XmlInsertElement(string xmlPath, string MainNode, string Element, string Attrib, string AttribContent, string Content)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.SetAttribute(Attrib, AttribContent);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
            objXmlDoc.Save(xmlPath);
        }

        #endregion

        #region ����һ�ڵ㲻������
        /**//**************************************************
         * ��������:XmlInsertElement(string xmlPath, string MainNode, string Element, string Content)
         * ����˵��:����һ�ڵ㲻������
         * ��    ��:xmlPath:xml�ĵ�·��;MailNode:��ǰ�ڵ��·��;Element:�²���Ľڵ�;Content:�ڵ������
         * ʹ��ʾ��:
         *          using EC; //���������ռ�
         *          string xmlPath = Server.MapPath("/EBDomainConfig/DomainConfig.xml"); //��ȡxml·��
         *          XmlObject.XmlInsertElement(xmlPath, "root/test", "text1", "�ڵ�����");  //����һ�ڵ㲻������
         * ���ɵ�XML��ʽΪ
         *          <test>
         *                  <text1>�ڵ�����</text1>
         *          </test>
         ************************************************/
        public static void XmlInsertElement(string xmlPath, string MainNode, string Element, string Content)
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load(xmlPath);
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
            objXmlDoc.Save(xmlPath);
        }

        #endregion
       

        //���봴���������ʹ�õ���

        private bool _alreadyDispose = false;
        private XmlDocument xmlDoc=new XmlDocument();   

        private XmlNode xmlNode;
        private XmlElement xmlElem;    

        #region �������͹�
        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (_alreadyDispose) return;
            if (isDisposing)
            {
               //
            }
            _alreadyDispose = true;
        }
        #endregion

        #region IDisposable ��Ա

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region ����xml�ĵ�
        /**//**************************************************
         * ��������:XmlObject
         * ����˵��:����xml�ĵ�        
         * ʹ��ʾ��:
         *          using EC; //���������ռ�
         *          string xmlPath = Server.MapPath("test.xml");
         *          XmlObject obj = new XmlObject();
         *          �������ڵ�
         *          obj.CreateXmlRoot("root");
         *          // �����սڵ�
         *          //obj.CreatXmlNode("root", "Node");
         *          //����һ����ֵ�Ľڵ�
         *          //obj.CreatXmlNode("root", "Node", "��ֵ�Ľڵ�");
         *          //����һ���������ԵĽڵ�
         *          //obj.CreatXmlNode("root", "Node", "Attribe", "����ֵ");
         *          //����һ��������������ֵ�Ľڵ�
         *          //obj.CreatXmlNode("root", "Node", "Attribe", "����ֵ", "Attribe2", "����ֵ2");
         *          //����һ��������ֵ�Ľڵ�ֵ�Ľڵ�
         *          // obj.CreatXmlNode("root", "Node", "Attribe", "����ֵ","�ڵ�ֵ");
         *          //�ڵ�ǰ�ڵ�������������ֵ�Ľڵ�
         *          obj.CreatXmlNode("root", "Node", "Attribe", "����ֵ", "Attribe2", "����ֵ2","�ڵ�ֵ");
         *          obj.XmlSave(xmlPath);
         *          obj.Dispose();        
         ************************************************/


        #region ����һ��ֻ�������͸��ڵ��XML�ĵ�
        /**//// <summary>
        /// ����һ��ֻ�������͸��ڵ��XML�ĵ�
        /// </summary>
        /// <param name="root"></param>
        public void CreateXmlRoot(string root)
        {
          //����XML����������
            xmlNode = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmlDoc.AppendChild(xmlNode);
            //����һ����Ԫ��
            xmlElem = xmlDoc.CreateElement("", root, "");
            xmlDoc.AppendChild(xmlElem);

        }
        #endregion

        #region �ڵ�ǰ�ڵ��²���һ���սڵ�ڵ�
        /**//// <summary>
        /// �ڵ�ǰ�ڵ��²���һ���սڵ�ڵ�
        /// </summary>
        /// <param name="mainNode">��ǰ�ڵ�·��</param>
        /// <param name="node">�ڵ�����</param>
        public void CreatXmlNode(string mainNode,string node)
        {
            XmlNode MainNode = xmlDoc.SelectSingleNode(mainNode);
            XmlElement objElem = xmlDoc.CreateElement(node);            
            MainNode.AppendChild(objElem);
        }
        #endregion

        #region �ڵ�ǰ�ڵ����һ������ֵ�Ľڵ�
        /**//// <summary>
        ///  �ڵ�ǰ�ڵ����һ������ֵ�Ľڵ�
        /// </summary>
        /// <param name="mainNode">��ǰ�ڵ�</param>
        /// <param name="node">�½ڵ�</param>
        /// <param name="content">�½ڵ�ֵ</param>
        public void CreatXmlNode(string mainNode, string node, string content)
        {
            XmlNode MainNode = xmlDoc.SelectSingleNode(mainNode);
            XmlElement objElem = xmlDoc.CreateElement(node);
            objElem.InnerText = content;
            MainNode.AppendChild(objElem);
        }
        #endregion

       #region �ڵ�ǰ�ڵ�Ĳ���һ����������ֵ�Ľڵ�
        /**//// <summary>
        /// �ڵ�ǰ�ڵ�Ĳ���һ����������ֵ�Ľڵ�
        /// </summary>
        /// <param name="MainNode">��ǰ�ڵ��·��</param>
        /// <param name="Node">�½ڵ�</param>
        /// <param name="Attrib">�½ڵ���������</param>
        /// <param name="AttribValue">�½ڵ�����ֵ</param>
        public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue)
        {
            XmlNode mainNode = xmlDoc.SelectSingleNode(MainNode);
            XmlElement objElem = xmlDoc.CreateElement(Node);
            objElem.SetAttribute(Attrib, AttribValue);
            mainNode.AppendChild(objElem);
        }       
        #endregion

     #region ����һ��������ֵ�Ľڵ�ֵ�Ľڵ�
        /**//// <summary>
        /// ����һ��������ֵ�Ľڵ�ֵ�Ľڵ�
        /// </summary>
        /// <param name="MainNode">��ǰ�ڵ��·��</param>
        /// <param name="Node">�ڵ�����</param>
        /// <param name="Attrib">��������</param>
        /// <param name="AttribValue">����ֵ</param>
        /// <param name="Content">�ڵ㴫��</param>
        public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue,string Content)
        {
            XmlNode mainNode = xmlDoc.SelectSingleNode(MainNode);
            XmlElement objElem = xmlDoc.CreateElement(Node);
            objElem.SetAttribute(Attrib, AttribValue);
            objElem.InnerText = Content;
            mainNode.AppendChild(objElem);
        }       
        #endregion      

        #region �ڵ�ǰ�ڵ�Ĳ���һ������2������ֵ�Ľڵ�
        /**//// <summary>
        ///  �ڵ�ǰ�ڵ�Ĳ���һ������2������ֵ�Ľڵ�
        /// </summary>
        /// <param name="MainNode">��ǰ�ڵ��·��</param>
        /// <param name="Node">�ڵ�����</param>
        /// <param name="Attrib">��������һ</param>
        /// <param name="AttribValue">����ֵһ</param>
        /// <param name="Attrib2">�������ƶ�</param>
        /// <param name="AttribValue2">����ֵ��</param>
        public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue,string Attrib2,string AttribValue2)
        {
            XmlNode mainNode = xmlDoc.SelectSingleNode(MainNode);
            XmlElement objElem = xmlDoc.CreateElement(Node);
            objElem.SetAttribute(Attrib, AttribValue);
            objElem.SetAttribute(Attrib2, AttribValue2);
            mainNode.AppendChild(objElem);
        }
        #endregion

       #region �ڵ�ǰ�ڵ������������ԵĽڵ�
        /**//// <summary>
        ///  �ڵ�ǰ�ڵ������������ԵĽڵ�
        /// </summary>
        /// <param name="MainNode">��ǰ�ڵ��·��</param>
        /// <param name="Node">�ڵ�����</param>
        /// <param name="Attrib">��������һ</param>
        /// <param name="AttribValue">����ֵһ</param>
        /// <param name="Attrib2">�������ƶ�</param>
        /// <param name="AttribValue2">����ֵ��</param>
        /// <param name="Content">�ڵ�ֵ</param>
        public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue, string Attrib2, string AttribValue2,string Content)
        {
            XmlNode mainNode = xmlDoc.SelectSingleNode(MainNode);
            XmlElement objElem = xmlDoc.CreateElement(Node);
            objElem.SetAttribute(Attrib, AttribValue);
            objElem.SetAttribute(Attrib2, AttribValue2);
            objElem.InnerText = Content;
            mainNode.AppendChild(objElem);
        }
        #endregion

        #region ����Xml
        /**//// <summary>
        /// ����Xml
        /// </summary>
        /// <param name="path">����ĵ�ǰ·��</param>
        public void XmlSave(string path)
        {
            xmlDoc.Save(path);
        }

        #endregion

        #endregion

    }
}
