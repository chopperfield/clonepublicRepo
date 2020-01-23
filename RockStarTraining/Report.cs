using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace RockStar.Training
{
    public partial class Report : Form
    {
        string trainingUsage;
        public Report(string trainingUsage)
        {
            InitializeComponent();
            this.trainingUsage = trainingUsage;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                ReportViewer reportViewer1 = new ReportViewer();
                this.Controls.Add(reportViewer1);
                reportViewer1.Dock = DockStyle.Fill;

                reportViewer1.ProcessingMode = ProcessingMode.Remote;
                

                ServerReport serverReport = reportViewer1.ServerReport;

                // Get a reference to the default credentials  
                System.Net.ICredentials credentials =
                    System.Net.CredentialCache.DefaultCredentials;

                // Get a reference to the report server credentials  
                ReportServerCredentials rsCredentials =
                    serverReport.ReportServerCredentials;

                // Set the credentials for the server report  
                rsCredentials.NetworkCredentials = credentials;

                // Set the report server URL and report path  
                serverReport.ReportServerUrl =
                    new Uri("http://192.168.1.27/reportserver/");
                serverReport.ReportPath =
                    "/HcRockstar/HC_TrainingUsage";
                
                //// Create the sales order number report parameter  
                ReportParameter reportParam1 = new ReportParameter();
                reportParam1.Name = "pCounter";
                reportParam1.Values.Add(trainingUsage);
                ReportParameter reportParam2 = new ReportParameter();
                reportParam2.Name = "pWordsEn";
                reportParam2.Values.Add(null);
                ReportParameter reportParam3 = new ReportParameter();
                reportParam3.Name = "pWordsId";
                reportParam3.Values.Add(null);

                reportViewer1.ShowParameterPrompts = false;

                // Set the report parameters for the report  
                reportViewer1.ServerReport.SetParameters(
                    new ReportParameter[] { reportParam1, reportParam2, reportParam3 });
                reportViewer1.Name = "Training End Usage";
                reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
