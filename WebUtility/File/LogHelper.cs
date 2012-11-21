using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace SNSSolution.Helper
{
    public class LogHelper :IDisposable
    {

        #region 构造方法
        /**//// <summary>
        /// 构造方法
        /// </summary>
        public LogHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            _isDebug = true;
            _logPath = @"c:\";
            init();
        }
        public LogHelper(string Path,bool isDebug)
        {
            _isDebug = IsDebug;
            _logPath = Path;
            init();
        }
        #endregion

        #region Log.PrintLine(string Message)
        /**//// <summary>
        /// PrintLine
        /// </summary>
        /// <param name="Message">要输出的信息</param>
        public void PrintLine(string Message)
        {
            writer.WriteLine(DateTime.Now+"---->"+Message);
            writer.Flush();
        }
        #endregion

        #region Log初始化
        /**//// <summary>
        /// Log初始化
        /// </summary>
        private void init()
        {
            string fileName = LogPath+@"\"+DateTime.Now+".log";
            writer = File.CreateText(fileName);
            //new StreamWriter(LogPath+@"\"+ConvertData.DateTimeConvertToStringNoSpace(DateTime.Now)+".log");
            _isInit = true;
            PrintLine("Start Log ");
        }
        #endregion

        #region Log 的属性
        private string _logPath = "";
        private bool _isDebug = false;

        private StreamWriter writer= null;
        private bool _isInit = false;
        #endregion

        #region Log 的方法
        private string LogPath
        {
            get
            {
                return _logPath;
            }
        }

        private bool IsDebug
        {
            get
            {
                return _isDebug;
            }
        }

        private bool IsInit
        {
            get
            {
                return _isInit;
            }
        }
        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            // TODO:  添加 Log.Dispose 实现
            PrintLine("Log is end ..");
            writer.Close();
        }

        #endregion
    }

}
