<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="True" Inherits="LongRunningTask.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 96px; POSITION: absolute; TOP: 56px" runat="server"
				Width="656px" Height="96px"></asp:Label>
			<asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 96px; POSITION: absolute; TOP: 168px" runat="server"
				Width="128px" Text="Start Task" onclick="Button1_Click"></asp:Button>
			<asp:Label id="Label2" style="Z-INDEX: 103; LEFT: 256px; POSITION: absolute; TOP: 16px" runat="server"
				Width="360px" Font-Names="Arial" Font-Size="Large">Long Running Task Demo</asp:Label>
		</form>
	</body>
</HTML>
