<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/include/master/SiteContainer.Master" CodeBehind="Default.aspx.cs" Inherits="BlackBallArchitecture.Web.Default" %>
<asp:Content ContentPlaceHolderID="Body" runat="server">
	<h1>How this page works</h1>
	<p>
		This website is designed to show end-to-end functionality of the BlackBall Architecture as of April 2011. Debug the solution to
		follow the code through to the database and back. Click the Help button above for instructions and reasoning behind the architecture.
	</p>
	<p>
		<asp:LinkButton runat="server" ID="BtnNew" Text="Click here to create a new person" />
	</p>
	<asp:UpdatePanel runat="server" ID="UPPeople" UpdateMode="Conditional">
	<ContentTemplate>
	<asp:Repeater runat="server" ID="Rpt">
		<HeaderTemplate>
			<h2>Existing People</h2>
			<table class="rpt">
				<tr>
					<th>Name</th>
					<th>Created</th>
				</tr>
		</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td><asp:Literal runat="server" ID="LblName" /></td>
						<td><asp:Literal runat="server" ID="LblCreated" /></td>
					</tr>
				</ItemTemplate>
		<FooterTemplate>
			</table>
		</FooterTemplate>
	</asp:Repeater>
	</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
