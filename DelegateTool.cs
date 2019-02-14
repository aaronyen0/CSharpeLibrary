using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;//記得把WinForm.dll加入專案中

namespace DelegateTool
{
    public static class WinFormDelegate
    {
        /**
         * [引數]
         * 1.用text代表取代內文
         * 2.用str代表繼續往下寫
         */

        delegate void LblTextCB(Label lbl, string text);
        delegate void TxtWriteCB(TextBox txt, string str);
        delegate void RtbWriteCB(RichTextBox rtb, string str);

        public static void LblText(Label lbl, string str)
        {
            if (lbl == null)
            {
                return;
            }
            if (lbl.InvokeRequired)
            {
                LblTextCB handle = new LblTextCB(LblText);
                lbl.Invoke(handle, lbl, str);
            }
            else
            {
                lbl.Text = str;
            }
        }

        public static void TxtWrite(TextBox txt, string str)
        {
            if (txt == null)
            {
                return;
            }
            if (txt.InvokeRequired)
            {
                TxtWriteCB handle = new TxtWriteCB(TxtWrite);
                txt.Invoke(handle, txt, str);
            }
            else
            {
                txt.AppendText(str);
            }
        }

        public static void RtbWrite(RichTextBox rtb, string str)
        {
            if (rtb == null)
            {
                return;
            }
            if (rtb.InvokeRequired)
            {
                RtbWriteCB handle = new RtbWriteCB(RtbWrite);
                rtb.Invoke(handle, rtb, str);
            }
            else
            {
                rtb.AppendText(str);
            }
        }

        public static void RtbWrite(RichTextBox rtb, String format, params object[] args)
        {
            if (rtb == null)
            {
                return;
            }
            if (rtb.InvokeRequired)
            {
                RtbWriteCB handle = new RtbWriteCB(RtbWrite);
                rtb.Invoke(handle, rtb, String.Format(format, args));
            }
            else
            {
                rtb.AppendText(String.Format(format, args));
            }
        }

        public static void RtbWrite_Limit(RichTextBox rtb, string str)
        {
            int line, tmpStart, tmpEnd;
            if (rtb == null)
            {
                return;
            }

            if (rtb.InvokeRequired)
            {
                RtbWriteCB handle = new RtbWriteCB(RtbWrite_Limit);
                rtb.Invoke(handle, rtb, str);
            }
            else
            {
                line = rtb.Lines.Length;
                if (line > 0x400)
                {
                    tmpStart = rtb.GetFirstCharIndexFromLine(0); // 第一行第一個字符的索引
                    tmpEnd = rtb.GetFirstCharIndexFromLine(0x200); //第n/2行第一個字符的索引
                    rtb.Text = rtb.Text.Remove(tmpStart, tmpEnd);
                }
                rtb.AppendText(str);
            }
        }

        public static void RtbWrite_Limit(RichTextBox rtb, String format, params object[] args)
        {
            int line, tmpStart, tmpEnd;
            if (rtb == null)
            {
                return;
            }

            if (rtb.InvokeRequired)
            {
                RtbWriteCB handle = new RtbWriteCB(RtbWrite_Limit);
                rtb.Invoke(handle, rtb, String.Format(format, args));
            }
            else
            {
                line = rtb.Lines.Length;
                if (line > 0x400)
                {
                    tmpStart = rtb.GetFirstCharIndexFromLine(0); // 第一行第一個字符的索引
                    tmpEnd = rtb.GetFirstCharIndexFromLine(0x200); //第n/2行第一個字符的索引
                    rtb.Text = rtb.Text.Remove(tmpStart, tmpEnd);
                }
                rtb.AppendText(String.Format(format, args));
            }
        }
    }
}
