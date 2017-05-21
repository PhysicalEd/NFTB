<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalDialog.ascx.cs" Inherits="BlackBallArchitecture.Web.Controls.ModalDialog" %>
<%@ Register TagPrefix="ctl" TagName="Script" Src="~/Controls/ScriptEditor.ascx" %>

<asp:UpdatePanel ID="UPPopup" runat="server" UpdateMode="Conditional">
    <ContentTemplate>    
    
        <asp:Button ID="BtnShow" runat="server" Text="Popup Button" style="display:none;" />

        <asp:Panel ID="PHWindow" runat="server" CssClass="Popup">
            <div id="PHHeader" runat="server" class="Header">
				<span class="title">
                <asp:PlaceHolder ID="PHHeaderContent" runat="server" />
                <asp:Label runat="server" ID="LblTitle" />
                </span>
                <asp:HyperLink runat="server" CssClass="close" Text="Close" ID="BtnCloseModal2" />
            </div>
            <div class="Content">
                <asp:PlaceHolder ID="PHBody" runat="server" />
                <asp:Panel runat="server" ID="PHCustom" />
            </div>
			<div class="ModalButtons buttons">
				<div class="buttons-secondary">
					<asp:PlaceHolder runat="server" ID="PHButtons" />
					<asp:HyperLink runat="server" CssClass="button secondary" Text="Close" id="BtnCloseModal" />
				</div>
			</div>
        </asp:Panel>

        <ajax:ModalPopupExtender
			 ID="ModalExtender"
			 runat="server" 
			 BackgroundCssClass="jqmOverlay" 
			 TargetControlID="BtnShow" 
			 PopupControlID="PHWindow">
        </ajax:ModalPopupExtender>

    </ContentTemplate>
</asp:UpdatePanel>


<ctl:Script runat="server">
<RunOncePerControl>
var <%=this.JS_NAMESPACE  %> = function(){
		this.$uxPopupPanel = $('#<%=this.PHWindow.ClientID  %>');
		
		var CloseModal = 
			function(){
				var myBehav = $find('<%=this.BehaviourName  %>');
				myBehav.hide();	
				<%= this.OnCloseScript  %>
			}
		
		return{
			Show : function(){
				var myBehav = $find('<%=this.BehaviourName%>');
				myBehav.show();
			},
			
			Hide : function(){
				CloseModal();
			}
		}
	}();
	</RunOncePerControl>
	</ctl:Script>