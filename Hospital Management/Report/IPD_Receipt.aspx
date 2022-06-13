<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IPD_Receipt.aspx.cs" Inherits="Hospital_Management.Report.IPD_Receipt" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" />
                    <div class="row">
           <div class="col-sm-12">
                <iframe src="" id="iframe_Application_No" runat="server" style="width:1000px; height:800px; margin-left:70px "> </iframe>
           </div>           
                </div>
    </div>



        <%-- <div style="margin-left:300px;">
            <CR:CrystalReportViewer ID="CrystalReportViewer1"  ToolPanelView="None" runat="server" AutoDataBind="true" />
        </div>--%>
    </form>
</body>
</html>
