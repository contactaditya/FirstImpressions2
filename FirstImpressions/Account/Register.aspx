<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FirstImpressions.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>The idea here is to ask the same questions of lots of different people, and see how similar or different the answers are. To learn anything from the answers, one needs to have a sense of how similar or different the people are whose answers one is comparing. So please fill in answers to the following questions, and then click "Register". This information will be stored and will help us describe the diversity of the population being sampled, but won't be associated with your name or reported in association with your responses in the following section.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
          <div class="form-group">
              <br /> 
            <asp:Label runat="server" AssociatedControlID="txtGender" CssClass="col-md-2 control-label">Gender</asp:Label>
              <div class="col-md-10">
                <asp:DropDownList ID="txtGender" runat="server">
                  <asp:ListItem Selected="True" Value="Female"> Female </asp:ListItem>
                  <asp:ListItem Value="Male"> Male </asp:ListItem>                  
               </asp:DropDownList>
            </div>
         </div>
       <div class="form-group">
           <br /> 
         <asp:Label runat="server" AssociatedControlID="txtAge" CssClass="col-md-2 control-label">Age</asp:Label>
         <div class="col-md-10">
            <asp:TextBox runat="server" ID="txtAge" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAge"
                 CssClass="text-danger" ErrorMessage="Age field is required." />
             <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtAge" 
                 CssClass="text-danger" ErrorMessage="Please enter a number." ValidationExpression="\d+"></asp:RegularExpressionValidator>
         </div>
       </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="col-md-2 control-label">User name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <br />
                <asp:Button runat="server" OnClick="btnRegister_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
     <br /> <br /><br /> <br /> <br /><br /> <br /> <br /><br /><br /> <br /><br /><br /> <br /><br /><br /> <br /><br /><br /> <br /><br /><br /> <br /><br />
</asp:Content>
