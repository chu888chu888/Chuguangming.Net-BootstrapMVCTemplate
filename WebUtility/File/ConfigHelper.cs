using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Reflection;
namespace WebUtility.Helper
{

    public enum ConfigFileType
    {
        WebConfig,
        AppConfig
    }
    /// <summary>
    /// ConfigHelper 的摘要说明
    /// </summary>

    public class ConfigHelper
    {

        public string docName = String.Empty;
        private XmlNode node = null;
        private int _configType;

        public int ConfigType
        {
            get { return _configType; }
            set { _configType = value; }
        }

        #region SetValue
        public bool SetValue(string key, string value)
        {
            XmlDocument cfgDoc = new XmlDocument();
            loadConfigDoc(cfgDoc);
            // retrieve the appSettings node   
            node = cfgDoc.SelectSingleNode("//appSettings");
            if (node == null)
            {
                throw new InvalidOperationException("appSettings section not found");
            }
            try
            {
                // XPath select setting "add" element that contains this key       
                XmlElement addElem = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");
                if (addElem != null)
                {
                    addElem.SetAttribute("value", value);
                }
                // not found, so we need to add the element, key and value   
                else
                {
                    XmlElement entry = cfgDoc.CreateElement("add");
                    entry.SetAttribute("key", key);
                    entry.SetAttribute("value", value);
                    node.AppendChild(entry);
                }
                //save it   
                saveConfigDoc(cfgDoc, docName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region saveConfigDoc
        private void saveConfigDoc(XmlDocument cfgDoc, string cfgDocPath)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(cfgDocPath, null);
                writer.Formatting = Formatting.Indented;
                cfgDoc.WriteTo(writer);
                writer.Flush();
                writer.Close();
                return;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region removeElement
        public bool removeElement(string elementKey)
        {
            try
            {
                XmlDocument cfgDoc = new XmlDocument();
                loadConfigDoc(cfgDoc);
                // retrieve the appSettings node  
                node = cfgDoc.SelectSingleNode("//appSettings");
                if (node == null)
                {
                    throw new InvalidOperationException("appSettings section not found");
                }
                // XPath select setting "add" element that contains this key to remove      
                node.RemoveChild(node.SelectSingleNode("//add[@key='" + elementKey + "']"));
                saveConfigDoc(cfgDoc, docName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region modifyElement
        public bool modifyElement(string elementKey)
        {
            try
            {
                XmlDocument cfgDoc = new XmlDocument();
                loadConfigDoc(cfgDoc);
                // retrieve the appSettings node  
                node = cfgDoc.SelectSingleNode("//appSettings");
                if (node == null)
                {
                    throw new InvalidOperationException("appSettings section not found");
                }
                // XPath select setting "add" element that contains this key to remove      
                node.RemoveChild(node.SelectSingleNode("//add[@key='" + elementKey + "']"));
                saveConfigDoc(cfgDoc, docName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region loadConfigDoc
        private XmlDocument loadConfigDoc(XmlDocument cfgDoc)
        {
            // load the config file   
            if (Convert.ToInt32(ConfigType) == Convert.ToInt32(ConfigFileType.AppConfig))
            {
                docName = ((Assembly.GetEntryAssembly()).GetName()).Name;
                docName += ".exe.config";
            }
            else
            {
                docName = HttpContext.Current.Server.MapPath("~/Web.Config");

            }
            cfgDoc.Load(docName);
            return cfgDoc;
        }
        #endregion
    }

}
