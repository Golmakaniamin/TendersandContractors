using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTM.Classes.ReportQueries
{
    public class ReportManager
    {
        static string ServerName = @"GIS-SERVER";
        static string DatabaseName = "ratec";
        static string UserID = "ratec";
        static string Password = "ratec";
        public static void SetReportSource(ref ReportClass report)
        {
            ConnectionInfo crConnection = new ConnectionInfo();
            crConnection.ServerName = ServerName;
            crConnection.DatabaseName = DatabaseName;
            crConnection.UserID = UserID;
            crConnection.Password = Password;
            CrystalDecisions.CrystalReports.Engine.Tables tables = report.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                CrystalDecisions.Shared.TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = crConnection;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
        }
        static string LocalServerName = ".";
        static string LocalDatabaseName = "ratec";
        static string LocalUserID = "sa";
        static string LocalPassword = "@dmin";
        public static void SetReportSourceLocal(ref ReportClass report)
        {
            ConnectionInfo crConnection = new ConnectionInfo();
            crConnection.ServerName = LocalServerName;
            crConnection.DatabaseName = LocalDatabaseName;
            crConnection.UserID = LocalUserID;
            crConnection.Password = LocalPassword;
            CrystalDecisions.CrystalReports.Engine.Tables tables = report.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                CrystalDecisions.Shared.TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = crConnection;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
        }
    }
}
