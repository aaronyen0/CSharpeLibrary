using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace FileOpenTool
{
    public static class DialogControl
    {
        public static string GetFilePath()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
            }
            return null;
        }

        public static string GetFolderPath()
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    return fbd.SelectedPath;
                }
            }
            return null;
        }

        public static string SetFileName()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
                {
                    return sfd.FileName;
                }
            }
            return null;
        }
    }
}
