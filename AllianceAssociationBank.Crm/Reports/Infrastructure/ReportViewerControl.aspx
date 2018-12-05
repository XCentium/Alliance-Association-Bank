<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewerControl.aspx.cs" Inherits="AllianceAssociationBank.Crm.Reports.Infrastructure.ReportViewerControl" Async="true" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            margin: 0px; 
            padding: 0px;
        }

        /* Set report viewer height to 100% */
        html,body,form,#div1 {
            height: 100%; 
        }

        #ReportViewer1_ctl13 {
            overflow-x: hidden !important;
            overflow-y: auto !important;
        }

        /* Center report area inside of report viewer */
        #VisibleReportContentReportViewer1_ctl13 > div > table {
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
