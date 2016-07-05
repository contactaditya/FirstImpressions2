<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudyPage2.aspx.cs" Inherits="FirstImpressions.StudyPage2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<meta name="viewport" content="width=device-width, initial-scale=1.0">

<script type="text/javascript">
    window.location.hash = "no-back-button";
    window.location.hash = "Again-No-back-button";//again because google chrome don't insert first hash into history
    window.onhashchange = function () { window.location.hash = "#"; }
</script>

<script type="text/javascript">
    function initSubmit1() {
        document.getElementById('<%=Submit1.ClientID%>').style.visibility = 'hidden';
    setTimeout("document.getElementById('<%=Submit1.ClientID%>').style.visibility = 'visible'", 1 * 5000);
}
</script>

<script type="text/javascript">
    function initSubmit2() {
        document.getElementById('<%=Submit2.ClientID%>').style.visibility = 'hidden';
        setTimeout("document.getElementById('<%=Submit2.ClientID%>').style.visibility = 'visible'", 2 * 5000);
    }
</script>

<script type="text/javascript">
    function initSubmit3() {
        document.getElementById('<%=Submit3.ClientID%>').style.visibility = 'hidden';
        setTimeout("document.getElementById('<%=Submit3.ClientID%>').style.visibility = 'visible'", 3 * 5000);
    }
</script>

<script type="text/javascript">
    function initSubmit4() {
        document.getElementById('<%=Submit4.ClientID%>').style.visibility = 'hidden';
        setTimeout("document.getElementById('<%=Submit4.ClientID%>').style.visibility = 'visible'", 4 * 5000);
    }
</script>

<br /> <br /> 

<div id="header" runat="server" style="text-align: center">
<div style ="display: inline-block">
<asp:Image ID="Image1" runat="server" style="margin-left: 0px;max-width: 900px;max-height: 400px"/> 
<p><br />Picture 1</p>
</div>
<hr style="border:1px solid black">
</div> 

<div id="header1" runat="server" style="white-space: nowrap">
<div style ="text-align: center; display: inline-block; margin-left: 25px">
<asp:Image ID="Image2" runat="server" style="margin-left: 0px;max-width: 400px;max-height: 400px"/>
<p><br />Picture 1</p>
</div>
<div style ="text-align: center; display: inline-block; margin-left: 25px">
<asp:Image ID="Image3" runat="server" style="margin-left: 0px;max-width: 400px;max-height: 400px"/> 
<p><br />Picture 2</p>
</div>
<hr style="border:1px solid black">
</div> 

<div id="header2" runat="server" style="white-space: nowrap">
<div style ="text-align: center; display: inline-block; margin-left: 25px">
<asp:Image ID="Image4" runat="server" style="margin-left: 0px;max-width: 350px;max-height: 400px"/> 
<p><br />Picture 1</p>
</div>
<div style ="text-align: center; display: inline-block; margin-left: 25px">
<asp:Image ID="Image5" runat="server" style="margin-left: 0px;max-width: 350px;max-height: 400px"/> 
<p><br />Picture 2</p>
</div>
<div style ="text-align: center; display: inline-block; margin-left: 25px">
<asp:Image ID="Image6" runat="server" style="margin-left: 0px;max-width: 350px;max-height: 400px"/> 
<p><br />Picture 3</p>
</div>
<hr style="border:1px solid black">
</div> 

<div id="header3" runat="server" style="white-space: nowrap">
<div style ="text-align: center; display: inline-block; margin-left: 25px">
<asp:Image ID="Image7" runat="server" style="margin-left: 0px; max-width: 250px;max-height: 400px"/> 
<p><br />Picture 1</p>
</div>

<div style ="text-align: center; display: inline-block; margin-left: 25px">
<asp:Image ID="Image8" runat="server" style="margin-left: 0px; max-width: 250px;max-height: 400px"/> 
<p><br />Picture 2</p>
</div>

<div style ="text-align: center; display: inline-block; margin-left: 25px">
<asp:Image ID="Image9" runat="server" style="margin-left: 0px; max-width: 250px;max-height: 400px"/> 
<p><br />Picture 3</p>
</div>

<div style ="text-align: center; display: inline-block; margin-left: 25px">
<asp:Image ID="Image10" runat="server" style="margin-left: 0px; max-width: 250px;max-height: 400px"/> 
<p><br />Picture 4</p>
</div>

<hr style="border:1px solid black">
</div> 

<br /> <br /> 

<div id="condition1" runat="server">

Based on the picture/pictures above, what is your impression of the <b>trustworthiness</b> of the person that has posted them? <br /> <br />
                                                                                                                                         
<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
<asp:ListItem Text="Extremely trustworthy" Value="7"></asp:ListItem>
<asp:ListItem Text="Very trustworthy" Value="6"></asp:ListItem>
<asp:ListItem Text="Above average" Value="5"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="4"></asp:ListItem>
<asp:ListItem Text="Below average" Value="3"></asp:ListItem>
<asp:ListItem Text="Not trustworthy" Value="2"></asp:ListItem>
<asp:ListItem Text="Not trustworthy at all" Value="1"></asp:ListItem> 
</asp:RadioButtonList>  <br /> 
<asp:RequiredFieldValidator runat="server" ControlToValidate="RadioButtonList1"
 CssClass="text-danger" ErrorMessage="Please select one option." />

<br /> <br />
 
Based on the picture/pictures above, what is your impression of the <b>creditworthiness</b> of the person that has posted them? <br />
How likely do you think it is that if lent $1,000 at a 10% interest rate by a bank, he or she would pay back the amount in full? <br /> <br />
 
                                                                                                                                                             
<asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
<asp:ListItem Text="Extremely creditworthy" Value="7"></asp:ListItem>
<asp:ListItem Text="Very creditworthy" Value="6"></asp:ListItem>
<asp:ListItem Text="Above average" Value="5"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="4"></asp:ListItem>
<asp:ListItem Text="Below average" Value="3"></asp:ListItem>
<asp:ListItem Text="Not creditworthy" Value="2"></asp:ListItem>
<asp:ListItem Text="Not creditworthy at all" Value="1"></asp:ListItem> 
</asp:RadioButtonList>  <br /> 
<asp:RequiredFieldValidator runat="server" ControlToValidate="RadioButtonList2"
 CssClass="text-danger" ErrorMessage="Please select one option." />

<br /> <br />

<div class="col-md-offset-5 col-md-10">
 <asp:Button runat="server" OnClick="btnSubmit1_Click" ID="Submit1" Text="Submit" CssClass="btn btn-default" /> <br /> <br />
</div>

</div>

<div id="condition2" runat="server">

Based on the picture/pictures above, what is your impression of the <b>trustworthiness</b> of the person that has posted them? <br /> <br />
                                                                                                                                         
<asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
<asp:ListItem Text="Extremely trustworthy" Value="7"></asp:ListItem>
<asp:ListItem Text="Very trustworthy" Value="6"></asp:ListItem>
<asp:ListItem Text="Above average" Value="5"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="4"></asp:ListItem>
<asp:ListItem Text="Below average" Value="3"></asp:ListItem>
<asp:ListItem Text="Not trustworthy" Value="2"></asp:ListItem>
<asp:ListItem Text="Not trustworthy at all" Value="1"></asp:ListItem> 
</asp:RadioButtonList>  <br /> 
<asp:RequiredFieldValidator runat="server" ControlToValidate="RadioButtonList1"
 CssClass="text-danger" ErrorMessage="Please select one option." />

<br /> <br />
 
Based on the picture/pictures above, what is your impression of the <b>creditworthiness</b> of the person that has posted them? <br />
How likely do you think it is that if lent $1,000 at a 10% interest rate by a bank, he or she would pay back the amount in full? <br /> <br />
 
                                                                                                                                                             
<asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
<asp:ListItem Text="Extremely creditworthy" Value="7"></asp:ListItem>
<asp:ListItem Text="Very creditworthy" Value="6"></asp:ListItem>
<asp:ListItem Text="Above average" Value="5"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="4"></asp:ListItem>
<asp:ListItem Text="Below average" Value="3"></asp:ListItem>
<asp:ListItem Text="Not creditworthy" Value="2"></asp:ListItem>
<asp:ListItem Text="Not creditworthy at all" Value="1"></asp:ListItem> 
</asp:RadioButtonList>  <br /> 
<asp:RequiredFieldValidator runat="server" ControlToValidate="RadioButtonList2"
 CssClass="text-danger" ErrorMessage="Please select one option." />

<br /> <br />

<div class="col-md-offset-5 col-md-10">
 <asp:Button runat="server" OnClick="btnSubmit2_Click" ID="Submit2" Text="Submit" CssClass="btn btn-default" /> <br /> <br />
</div>

</div>

<div id="condition3" runat="server">

Based on the picture/pictures above, what is your impression of the <b>trustworthiness</b> of the person that has posted them? <br /> <br />
                                                                                                                                         
<asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
<asp:ListItem Text="Extremely trustworthy" Value="7"></asp:ListItem>
<asp:ListItem Text="Very trustworthy" Value="6"></asp:ListItem>
<asp:ListItem Text="Above average" Value="5"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="4"></asp:ListItem>
<asp:ListItem Text="Below average" Value="3"></asp:ListItem>
<asp:ListItem Text="Not trustworthy" Value="2"></asp:ListItem>
<asp:ListItem Text="Not trustworthy at all" Value="1"></asp:ListItem> 
</asp:RadioButtonList>  <br /> 
<asp:RequiredFieldValidator runat="server" ControlToValidate="RadioButtonList1"
 CssClass="text-danger" ErrorMessage="Please select one option." />

<br /> <br />
 
Based on the picture/pictures above, what is your impression of the <b>creditworthiness</b> of the person that has posted them? <br />
How likely do you think it is that if lent $1,000 at a 10% interest rate by a bank, he or she would pay back the amount in full? <br /> <br />
 
                                                                                                                                                             
<asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
<asp:ListItem Text="Extremely creditworthy" Value="7"></asp:ListItem>
<asp:ListItem Text="Very creditworthy" Value="6"></asp:ListItem>
<asp:ListItem Text="Above average" Value="5"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="4"></asp:ListItem>
<asp:ListItem Text="Below average" Value="3"></asp:ListItem>
<asp:ListItem Text="Not creditworthy" Value="2"></asp:ListItem>
<asp:ListItem Text="Not creditworthy at all" Value="1"></asp:ListItem> 
</asp:RadioButtonList>  <br /> 
<asp:RequiredFieldValidator runat="server" ControlToValidate="RadioButtonList2"
 CssClass="text-danger" ErrorMessage="Please select one option." />

<br /> <br />

<div class="col-md-offset-5 col-md-10">
 <asp:Button runat="server" OnClick="btnSubmit3_Click" ID="Submit3" Text="Submit" CssClass="btn btn-default" /> <br /> <br />
</div>

</div>

<div id="condition4" runat="server">

Based on the picture/pictures above, what is your impression of the <b>trustworthiness</b> of the person that has posted them? <br /> <br />
                                                                                                                                         
<asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
<asp:ListItem Text="Extremely trustworthy" Value="7"></asp:ListItem>
<asp:ListItem Text="Very trustworthy" Value="6"></asp:ListItem>
<asp:ListItem Text="Above average" Value="5"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="4"></asp:ListItem>
<asp:ListItem Text="Below average" Value="3"></asp:ListItem>
<asp:ListItem Text="Not trustworthy" Value="2"></asp:ListItem>
<asp:ListItem Text="Not trustworthy at all" Value="1"></asp:ListItem> 
</asp:RadioButtonList>  <br /> 
<asp:RequiredFieldValidator runat="server" ControlToValidate="RadioButtonList1"
 CssClass="text-danger" ErrorMessage="Please select one option." />

<br /> <br />
 
Based on the picture/pictures above, what is your impression of the <b>creditworthiness</b> of the person that has posted them? <br />
How likely do you think it is that if lent $1,000 at a 10% interest rate by a bank, he or she would pay back the amount in full? <br /> <br />
 
                                                                                                                                                             
<asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
<asp:ListItem Text="Extremely creditworthy" Value="7"></asp:ListItem>
<asp:ListItem Text="Very creditworthy" Value="6"></asp:ListItem>
<asp:ListItem Text="Above average" Value="5"></asp:ListItem>
<asp:ListItem Text="Neutral" Value="4"></asp:ListItem>
<asp:ListItem Text="Below average" Value="3"></asp:ListItem>
<asp:ListItem Text="Not creditworthy" Value="2"></asp:ListItem>
<asp:ListItem Text="Not creditworthy at all" Value="1"></asp:ListItem> 
</asp:RadioButtonList>  <br /> 
<asp:RequiredFieldValidator runat="server" ControlToValidate="RadioButtonList2"
 CssClass="text-danger" ErrorMessage="Please select one option." />

<br /> <br />

<div class="col-md-offset-5 col-md-10">
 <asp:Button runat="server" OnClick="btnSubmit4_Click" ID="Submit4" Text="Submit" CssClass="btn btn-default" /> <br /> <br />
</div>

</div>
   
<br /> <br /><br /> <br /> <br /><br /> <br /> <br /><br /><br /> <br /><br /><br /> <br /><br /><br /> <br /><br /><br /> <br /><br /><br /> <br /><br />

</asp:Content>

