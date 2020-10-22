﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SC4Parser.Logging;

namespace SC4CartographerUI
{
    class RichTextBoxLogger : ILogger
    {
        public static readonly Dictionary<LogLevel, string> LogLevelText = new Dictionary<LogLevel, string>
        {
            { LogLevel.Debug, "DEBUG" },
            { LogLevel.Info, "INFO" },
            { LogLevel.Warning, "WARNING" },
            { LogLevel.Error, "ERROR" },
            { LogLevel.Fatal, "FATAL" }
        };

        private RichTextBox richTextBox;

        public RichTextBoxLogger(RichTextBox r)
        {
            richTextBox = r;
            Logger.AddLogOutput(this);
        }

        public void Log(LogLevel level, string format, params object[] args)
        {
            string message = args.Length == 0 ? format : string.Format(format, args);
            message = string.Format("[{0}] [SC4Parser] [{1}] {2}",
                DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss.ff"),
                LogLevelText[level],
                message);

            richTextBox.AppendText(message + "\n");
        }
    }
}
