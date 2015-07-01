<%@ Page Language="C#"  MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Interceuticals.WebContent.ContactUs" %>
<asp:Content ID="contentCompany" ContentPlaceHolderID="cBody" runat="server">
    
    
    <script language="javascript">

        $(function() {
            $("#ctl00_cBody_btnSend").click(function(e) {
            var url = "iContact.aspx";

            var whereHeard = $("input[name='whereHeard']").val();
            var fname = $("input[name='firstname']").val();
            var lname = $("input[name='lastname']").val();
            var email = $("input[name='email']").val();
            var source = "Interceuticals Contact Form";
            var optin = "1";
            var interest = $("#drp_interest").val();
            var street = $("input[name='address1']").val();
            var city = $("input[name='city']").val();
            var state = $("input[name='state']").val();
            var zip = $("input[name='zip']").val();
            var phone = $("input[name='phone']").val();
            var comments = $("textarea[name='comments']").val();

            
                var _error = 0;
                var _errMessage = "";



                if (whereHeard == "") {
                    _error = 1;
                    _errMessage += "Please enter where you heard about us.\n";
                }
                if (fname == "") {
                    _error = 1;
                    _errMessage += "Please enter your first name.\n";
                }
                if (lname == "") {
                    _error = 1;
                    _errMessage += "Please enter your last name.\n";
                }
                if (email == "") {
                    _error = 1;
                    _errMessage += "Please enter your email address.\n";
                }


                if (phone == "") {
                    _error = 1;
                    _errMessage += "Please enter your phone number.\n";
                }
                if (comments == "") {
                    _error = 1;
                    _errMessage += "Please enter your comments.\n";
                }


                if (_error == 0) {

                    $.ajax({
                        type: "POST",
                        url: url,
                        data: {
                            fname: fname,
                            lname: lname,
                            email: email,
                            optin: optin,
                            source: source,
                            interest: interest,
                            street: street,
                            city: city,
                            state: state,
                            zip: zip,
                            phone: phone
                        }
                    });
                } else {
                    e.preventDefault();
                    alert(_errMessage);
                    return false;
                }
            });
        });
    </script>
    
    <style type="text/css">
       span.sp_required {
  color: #ff0000;
  font-weight: bold;
  font-size: 22px;
}

       span.sp_required_text {
  color: #ff0000;
  font-weight: bold;
  font-size: 14px;
}
    </style>
    

<table cellpadding="0" cellspacing="0" border="0">
      <td width="20" valign="top"><img src="/interceuticals/images/interceuticals/whiteheader.gif" width="20" height="43"></td>
      <td width="388" valign="top">
        <p><img src="/interceuticals/images/interceuticals/contactusheader.gif" width="388" height="43"></p>
        <p>All customer information is confidential.</p>
          <div class="dv_inter_contact_form" runat="server" id="dv_inter_contact_form">
        <p> <b>If you have any questions or comments, please email us. We will respond
          as soon as possible. Thank you.</b> </p>
        <p>(Please enter the following information.) <span class="sp_required">*</span><span class="sp_required_text"> required fields</span></p>
          <!-- <form action="comments.asp" method="post">-->
          <table width="380" border="0">
            <tr>
              <td width="97" align="right"><b>Where did you hear about us:</b></td><td style="vertical-align:top"><span class="sp_required">*</span></td>
              <td width="273"><input type="text" name="whereHeard" size="40" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>Email Address:</b></td><td style="vertical-align:top"><span class="sp_required">*</span></td>
              <td width="273"><input type="text" name="email" size="40" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>First Name:</b></td><td style="vertical-align:top"><span class="sp_required">*</span></td>
              <td width="273"><input type="text" name="firstname" size="40" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>Last Name:</b></td><td style="vertical-align:top"><span class="sp_required">*</span></td>
              <td width="273"><input type="text" name="lastname" size="40" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>Company:</b></td><td>&nbsp;</td>
              <td width="273"><input type="text" name="company" size="40" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right" valign="top"><b>Street Address:</b></td><td>&nbsp;</td>
              <td width="273"><input type="text" name="address1" size="40" />
                  <br />
                  <input type="text" name="address2" size="40" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>City:</b></td><td>&nbsp;</td>
              <td width="273"><input type="text" name="city" size="40" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>State:</b></td><td>&nbsp;</td>
              <td width="273"><input type="text" name="state" size="2" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>Zip Code:</b></td><td>&nbsp;</td>
              <td width="273"><input type="text" name="zip" size="10" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>Country:</b></td><td>&nbsp;</td>
              <td width="273"><input type="text" name="country" size="30" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>Phone:</b></td><td style="vertical-align:top"><span class="sp_required">*</span></td>
              <td width="273"><input type="text" name="phone" size="18" />
              </td>
            </tr>
            <tr>
              <td width="97" align="right"><b>Subject:</b></td><td>&nbsp;</td>
              <td width="273"><input type="text" name="subject" size="40" />
              </td>
            </tr>
              <tr>
              <td width="97" align="right" valign="top">&nbsp;</td><td>&nbsp;</td>
              <td width="273"><select id="drp_interest" name="drp_interest">
                      <option value="Both"> - Which Product(s) Are You Interested In? - </option>
                      <option value="Both">Both Products</option>
                      <option value="BetterMan">Better Man</option>
                      <option value="BetterWoman">Better Woman</option>
                  </select>
              </td>
            </tr>
            <tr>
              <td width="97" align="right" valign="top"><b>Comments:</b></td><td style="vertical-align:top"><span class="sp_required">*</span></td>
              <td width="273"><textarea name="comments" rows="5" cols="30" wrap="wrap"></textarea>
              </td>
            </tr>
            <tr><td>&nbsp;</td>
              <td colspan="2"><div align="right">
                  
                  <asp:Button ID="btnSend" Text="Send it Now!" runat="server" 
                      onclick="btnSend_Click"/>
                  <input type="reset" name="Reset" value="Reset" />
              </div></td>
            </tr>
          </table>
       </div>
           <div class="dv_inter_contact_form_thanks" runat="server" id="dv_inter_contact_form_thanks" Visible="false">
               <p> <b>Thank You! Your Request has been sent.</b> </p>
               </div>
        <p>&nbsp;</p>
</table>
</asp:Content>