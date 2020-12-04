using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Axioma.Celebrity.Fitness;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.IO;
using System.Drawing.Drawing2D;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;


namespace RockStar.Training
{ 
    public class Utils
    {
      
        // test comment, new comment, fork comment 2ez4rst- clone signature commnet,
        // add new comment from new bracnh to try pull request
        /// <summary>
        /// get Student image URL
        /// </summary>
        /// <returns></returns>
        public string get_Student_Image_URL()
        {            
            SqlConnection myConnection = new SqlConnection(Partner.configConnection);
            DataTable dtprofile = new DataTable();
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }

                dtprofile.Clear();
                command.Connection = myConnection;
                myConnection.Open();
                command.CommandText = "SELECT [document] " +
                                      "FROM Platform.[document] with (nolock)" +
                                      "WHERE code in (@memberImg)";
                command.Parameters.Add("@memberImg", SqlDbType.NVarChar).Value = "member image";
                adapter.SelectCommand = command;
                adapter.Fill(dtprofile);
            }

            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
                return "";
            }
            finally
            {
                myConnection.Close();
            }

            if (dtprofile.Rows.Count != 0)
            {
                return dtprofile.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// get student image
        /// </summary>
        /// <param name="Img_member_Url"></param>
        /// <param name="member_RGP"></param>
        /// <returns></returns>
        public string get_Student_Image(string Img_member_Url, string member_RGP)
        {           

            //check di cached folder sudah ada image apa belum
            string pathx = "";
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "\\TempImage\\" + member_RGP.Trim() + ".jpg";

            if (File.Exists(basePath))
            {
                return basePath;
            }
            else
            {
                if (!string.IsNullOrEmpty(Img_member_Url.Trim()))
                {
                    //apabila pada saat jalan program, dan dengan iseng org menghapus folder tersebut, untuk sekarang masi blum dipakai
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\TempImage"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\TempImage");
                        di.Attributes = FileAttributes.Hidden;
                    }
                    //klo ada gambar, ga masuk fungsi ini. makanya disini langsung dicopy. beda dengan tap member !!
                    string path_ = Img_member_Url.Trim() + "\\" + member_RGP.Trim() + ".jpg";
                    if (File.Exists(path_))
                    {
                        string file = member_RGP.Trim() + ".jpg";
                        string source = Img_member_Url.Trim();
                        string target = AppDomain.CurrentDomain.BaseDirectory + "\\TempImage";
                        string sourceFile = System.IO.Path.Combine(source, file);
                        string destFile = System.IO.Path.Combine(target, file);
                        System.IO.File.Copy(sourceFile, destFile, true);

                        pathx = AppDomain.CurrentDomain.BaseDirectory + "\\TempImage\\" + member_RGP.Trim() + ".jpg";

                    }
                    else if (!File.Exists(path_))
                    {
                        pathx = "";
                    }
                }
                else
                {
                    pathx = "";
                }
                return pathx;
            }
        }

        /// <summary>
        /// get .dll version
        /// </summary>
        /// <returns></returns>
        public static string getVersion()
        {
            System.Reflection.Assembly cur_assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo cur_assembly_FileVer = System.Diagnostics.FileVersionInfo.GetVersionInfo(cur_assembly.Location);
            Version cur_assemblyVer = new Version(cur_assembly_FileVer.FileVersion);

            return "ver." + cur_assemblyVer.ToString();
        }


     

        public static void create_Img_Cached()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory + "\\TempImage";
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
            if (!Directory.Exists(dir))
            {
                DirectoryInfo di = Directory.CreateDirectory(dir);
                di.Attributes = FileAttributes.Hidden;
            }
        }

        /// <summary>
        /// print preview
        /// </summary>
        /// <param name="gridControl"></param>
        /// <param name="gridView"></param>
        /// <param name="title"></param>
        public static void printView(GridControl gridControl, GridView gridView, String title)
        {
            PrintingSystem ps = new PrintingSystem();
            //====set visibility secara koding====
            //ps.SetCommandVisibility(PrintingSystemCommand.Open, CommandVisibility.None);

            //buat componen print
            PrintableComponentLink pcl = new PrintableComponentLink(ps);
            pcl.Component = gridControl;
            pcl.CreateDocument();

            form_Print pr = new form_Print(gridView);
            //printcontrol pada form print12, modifier public untuk ambils setting dari PS
            pr.printControl1.PrintingSystem = ps;
            pr.Text = " Print Preview - " + title + "";
            pr.Show();
        }

        /// <summary>
        /// saving File
        /// </summary>
        /// <param name="gridControl"></param>
        public static void saveFile(GridControl gridControl)
        {
            SaveFileDialog save = new SaveFileDialog();
            //buat ekstensi file save manual           
            save.Filter = "Microsoft Excel WorkBook|*.xls";
            if (save.ShowDialog() != DialogResult.Cancel)
            {
                //select nama file dan tampung              
                string exportFilePath = save.FileName;
                gridControl.ExportToXls(exportFilePath);
                DialogResult openfile = MessageBox.Show("Do you wish to open the file now", "Axioma Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (openfile == DialogResult.Yes)
                {
                    //buat open file
                    System.Diagnostics.Process.Start(exportFilePath);
                }
            }
        }

        public static string getIPAddress()
        {
            string ip = "";
            System.Net.IPAddress[] localIPs = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());
            foreach (System.Net.IPAddress addr in localIPs)
            {
                if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = addr.ToString();
                }
            }
            return ip;
        }

    }


   
}