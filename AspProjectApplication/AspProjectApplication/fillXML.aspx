<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fillXML.aspx.cs" Inherits="AspProjectApplication.FillXml" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <center><h1><font color="white" > Попълване на данните за XML документа </font></h1>
                <p>
                    <asp:Label ID="submitResult_Lable" runat="server" Text="Label" ForeColor="Azure" Font-Italic="true"></asp:Label>
                    &nbsp;&nbsp;</p></center>


                    <center><font color="maroon">ДАННИ ЗА ПОРОДАТА КЪМ FIF</font></center>
                <center><table border="1">
                <tr>
               <td><asp:Label ID="Label1" runat="server">*Съкращение на породата:</asp:Label></td><td><asp:TextBox
               ID="standartNumber_Input" runat="server" autocomplete="off" 
                       AutoCompleteType="Disabled"></asp:TextBox> <asp:Label ID="Label4" runat="server" Text="Label" Font-Size="XX-Small">Пример:"EXO"  </asp:Label>&nbsp;<asp:Label 
                       ID="standratNumberStatus_Label" runat="server"></asp:Label>
            </td>
            </tr>
                   
                <tr><td>  
               <asp:Label ID="Label2" runat="server" >*Група в която попада породата:</asp:Label></td><td>
                   <asp:TextBox ID="groupInput" runat="server" autocomplete="off" ></asp:TextBox><asp:Label ID="Label3" runat="server" Text="Label" Font-Size="XX-Small">Пример:"A" , Валидни групи:A-D  </asp:Label>
                   <asp:Label ID="groupStatus_Label" runat="server"></asp:Label></td>
                   </tr>
            
               
               <tr>
               <td><asp:Label ID="Label35" runat="server" >Име на групата:</asp:Label></td><td><asp:TextBox
               ID="groupDescrInput" runat="server" TextMode="MultiLine" 
                       autocomplete="off"></asp:TextBox></td>
               </tr>
                
                <tr>
                <td><asp:Label ID="Label5" runat="server" >*Категория, в която попада породата:</asp:Label></td>
                  <td>  <asp:TextBox
               ID="sectionInput" runat="server" autocomplete="off"></asp:TextBox><asp:Label ID="Label6" runat="server" Text="Label" Font-Size="XX-Small">Пример:"1" *  </asp:Label>
                    <asp:Label ID="sectionStatus_Label" runat="server"></asp:Label></td>
            </tr>
            

            <tr>
            <td>
               <asp:Label ID="Label36" runat="server" >Характеристика на категорията:</asp:Label></td><td><asp:TextBox
               ID="sectionDescrInput" runat="server" TextMode="MultiLine" 
                       autocomplete="off"></asp:TextBox></td>

            </tr>
            
            <tr>
            <td>
               <asp:Label ID="Label9" runat="server" >Име на породата:</asp:Label></td>
                   <td><asp:TextBox
               ID="breedNameInput" runat="server" autocomplete="off"></asp:TextBox></td>
            </tr>
            </table> </center>

            <center><font color="maroon">ДАННИ ЗА ДЪРЖАВАТА ОСНОВАТЕЛКА</font></center>
            <center><table border="1">
            <tr>
               <td><asp:Label ID="Label7" runat="server" >*Код на държавата основателка:</asp:Label></td><td><asp:TextBox
               ID="countryCodeInput" runat="server" autocomplete="off" 
                       AutoCompleteType="Disabled"></asp:TextBox><asp:Label ID="Label8" runat="server" Text="Label" Font-Size="XX-Small">Пример:"GER" за Germany  </asp:Label>
                   <asp:Label ID="countryCodeStatus_Label" runat="server"></asp:Label></td>
            </tr>
            
            <tr>
               <td><asp:Label ID="Label10" runat="server" >Столица на държавата основателка:</asp:Label></td><td>
                   <asp:TextBox
               ID="countryCapitalInput" runat="server" autocomplete="off"></asp:TextBox></td>

            </tr>
            
            <tr>
               <td><asp:Label ID="Label11" runat="server" >Официален език на държавата основателка:</asp:Label></td>
                   <td><asp:TextBox
               ID="officialLanguageInput" runat="server" autocomplete="off"></asp:TextBox></td>
            </tr>
            
            <tr>
            <td><asp:Label ID="Label12" runat="server" >Часова зона на държавата основателка:</asp:Label></td><td><asp:DropDownList
                       ID="timeZoneInput" runat="server">
                   <asp:ListItem>UTC/GMT  +1 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +2 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +3 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +4 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +5 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +6 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +7 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +8 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +9 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +10 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +11 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  +12 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -1 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -2 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -3 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -4 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -5 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -6 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -7 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -8 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -9 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -10 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  -11 hours</asp:ListItem>
                   <asp:ListItem>UTC/GMT  No Offset</asp:ListItem>
                   </asp:DropDownList></td>
               
               </tr>
               

               <tr>
               <td><asp:Label ID="Label13" runat="server" >Валута на държавата основателка:</asp:Label></td>
                   <td><asp:TextBox
               ID="currencyInput" runat="server" autocomplete="off"></asp:TextBox></td>
               </tr>
               

               <tr>
               <td><asp:Label ID="Label14" runat="server" >Име на държавата основателка:</asp:Label></td>
                   <td><asp:TextBox
               ID="countryNameInput" runat="server" autocomplete="off"></asp:TextBox></td>
               </tr>
               

               <tr>
               <td><asp:Label ID="Label15" runat="server" >Континент в който попада държавата:</asp:Label></td><td>
                   <asp:DropDownList
                       ID="countryContinent_DropDownListInput" runat="server">
                   <asp:ListItem>Северна Америка</asp:ListItem>
                   <asp:ListItem>Южна Америка</asp:ListItem>
                   <asp:ListItem>Европа</asp:ListItem>
                   <asp:ListItem>Азия</asp:ListItem>
                   <asp:ListItem>Антарктида</asp:ListItem>
                   <asp:ListItem>Африка</asp:ListItem>
                   <asp:ListItem>Австралия</asp:ListItem>
                   </asp:DropDownList></td>
               </tr>
               

               <tr>
               <td><asp:Label ID="Label16" runat="server" >Тип на държавното управление:</asp:Label></td><td>
                   <asp:TextBox
               ID="governmentTypeInput" runat="server" autocomplete="off"></asp:TextBox></td>

               </tr>
               
               <tr>
               <td><asp:Label ID="Label17" runat="server" >Година на обявяване на стандрата на породата:</asp:Label></td><td>
                   <asp:TextBox
               ID="yearEstablishedInput" runat="server" autocomplete="off"></asp:TextBox>
                   <asp:Label ID="yearEstablishedStatus_Label" runat="server"></asp:Label></td>
               </tr>
               </table></center>

               <center><font color="maroon">ОПИСАНИЕ НА ВЪНШНИЯ ВИД НА ПРЕДСТАВИТЕЛИТЕ НА ТАЗИ ПОРОДА</font></center>
               <center><table border ="1">
               <tr>
               <td><asp:Label ID="Label18" runat="server" >Форма на главата на котката:</asp:Label></td>
                   <td><asp:TextBox
               ID="headFormInput" runat="server" Height="59px" TextMode="MultiLine" Width="251px" 
                       autocomplete="off"></asp:TextBox></td>
               
               </tr>

               
               <tr>
               <td><asp:Label ID="Label19" runat="server" >Характер на котката:</asp:Label></td>
                   <td><asp:TextBox
               ID="persInput" runat="server" Height="59px" TextMode="MultiLine" Width="251px" 
                       autocomplete="off"></asp:TextBox></td>
               </tr>
               
               <tr>
               <td><asp:Label ID="Label20" runat="server" >Уши на котката:</asp:Label></td>
                   <td><asp:TextBox
               ID="earsInput" runat="server" Height="59px" TextMode="MultiLine" Width="251px" 
                       autocomplete="off"></asp:TextBox></td>
               </tr>
               

               <tr>
               <td><asp:Label ID="Label21" runat="server" >Очи на котката:</asp:Label></td>
                  <td> <asp:TextBox
               ID="eyesInput" runat="server" Height="59px" TextMode="MultiLine" Width="251px" 
                       autocomplete="off"></asp:TextBox></td>
               </tr>
               

               <tr>
               <td><asp:Label ID="Label22" runat="server" >Опашка на котката:</asp:Label></td>
                   <td><asp:TextBox
               ID="tailInput" runat="server" Height="59px" TextMode="MultiLine" Width="251px" 
                       autocomplete="off"></asp:TextBox></td>
              </tr>
              

                <tr><td><asp:Label ID="Label23" runat="server" Text="Label">Тип окраска:</asp:Label></td></tr>
                <tr>
                <td><asp:Label ID="Label24" runat="server" >Първа разнивидност:</asp:Label></td><td>
                   <asp:TextBox
               ID="primaryColorInput" runat="server" Height="22px" TextMode="SingleLine" 
                Width="251px" autocomplete="off"></asp:TextBox></td>
                </tr>
                

                <tr>
                <td><asp:Label ID="Label25" runat="server" >Втора разнивидност:</asp:Label></td>
                   <td><asp:TextBox ID="secondaryColorInput" runat="server" Width="253px" 
                autocomplete="off"></asp:TextBox></td>
                </tr>
                

                <tr>
                <td><asp:Label ID="Label26" runat="server" >Предпочитан цвят:</asp:Label></td>
                   <td><asp:TextBox
               ID="preferedColorInput" runat="server" Height="22px" TextMode="SingleLine" 
                Width="262px" autocomplete="off"></asp:TextBox></td>
                </tr>
                

                <tr>
                <td><asp:Label ID="Label27" runat="server" >Козина на котката:</asp:Label></td>
                   <td><asp:TextBox
               ID="furInput" runat="server" Height="59px" TextMode="MultiLine" Width="251px" 
                        autocomplete="off"></asp:TextBox></td>
                </tr>
                

                <tr>
                <td><asp:Label ID="Label28" runat="server" >Връзка към изображение на представител на породата:</asp:Label></td>
                   <td><asp:TextBox
                       ID="imageInput" runat="server" autocomplete="off"></asp:TextBox><asp:Label ID="Label29" runat="server" Text="Label" Font-Size="XX-Small">Пример:"https://skydrive.live.com/redir?resid=6F26B1E0D6CF648E!315"</asp:Label></td>
                </tr>
                


                <tr><td><asp:Label ID="Label30" runat="server" Text="Label">Размери при тази порода:</asp:Label></td></tr>
                <tr>
                <td><asp:Label ID="Label31" runat="server" Text="Label">Мъжки:</asp:Label></td><td><asp:TextBox ID="malesSizeInput" runat="server" autocomplete="off"></asp:TextBox></asp:Label></td>
                </tr>
                

                <tr> 
                 
                 <td><asp:Label ID="Label32" runat="server" Text="Label">Женски:</asp:Label></td><td><asp:TextBox ID="femalesSizeInput" runat="server" autocomplete="off"></asp:TextBox></asp:Label></td>

                </tr>

               
                </table></center>

        <center><asp:Button ID="submitXmlButton" runat="server" Text="Създаване и Добавяне" 
                onclick="submitXmlButton_Click" />
            <br />
            <br />
            <asp:TextBox ID="errorsLog_TextBox" runat="server" ReadOnly="True" 
                TextMode="MultiLine"></asp:TextBox>
            </center>

                <footer>
  <p>Всички полета със звездичка(*) са задължителни.</p>
  <p>Препоръчително е данните да бъдат попълнени на български език.</p>
</footer>

    </div>
    </form>
</body>
</html>



