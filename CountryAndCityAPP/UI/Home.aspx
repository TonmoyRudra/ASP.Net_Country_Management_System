<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CountryAndCityAPP.UI.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="../Scripts/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wholepage">
            <div class="Header">
                <h1> Country City Information Management System</h1>
            </div>

            <div class="Menu">
                <ul class="menuUl">
                    <li><a class="active" href="Home.aspx">&nbsp &nbsp &nbsp &nbsp Home &nbsp &nbsp &nbsp &nbsp</a></li>
                    <li><a href="CountryEntryUI.aspx">&nbsp &nbsp Country Entry &nbsp &nbsp</a></li>
                    <li><a href="CityEntryUI.aspx">&nbsp &nbsp City Entry &nbsp &nbsp</a></li>
                    <li><a href="ViewCountriesUI.aspx">&nbsp &nbsp View Countries &nbsp &nbsp</a></li>
                    <li><a href="ViewCitiesUI.aspx">&nbsp &nbsp View Cites &nbsp &nbsp</a></li>
                    
                </ul>
            </div>

            <div class="Body">
                <table style="border-style: solid; border-color: white; border-width: 2px; margin: 50px auto; border-radius: 10px; background: #3B5998; width: 750px;">
                            <tr>
                                <td class="auto-style1 td1">Project NO</td>
                                <td class="td2">:   Project-01</td>
                            </tr>
                            <tr>
                                <td class="auto-style1 td1">Project Name</td>
                                <td class="td2">:   Country City Information Management System</td>
                            </tr>
                            <tr>
                                <td class="auto-style1 td1 ">Group Name</td>
                                <td class="td2">:   IIUC CODERS</td>
                            </tr>
                            <tr>
                                <td class="auto-style1 td1 ">Member Name</td>
                                <td style="color: white; font-size: 15px;">:   128297- Kazi Shoaib
                                        <br />
                                    :   122481- Tonmoy Rudra
                                        <br />
                                    :   128797- Shaon Dey
                                        <br />
                                    :   129871- Talat Mahmud Sourave</td>
                            </tr>
                            <tr>
                                <td class="auto-style1 td1">Batch NO</td>
                                <td class="td2">:   DN-20</td>
                            </tr>

                        </table>
                        <p style="font-weight: bold; text-align: center; background: #6EA93B; width: 428px; margin: 50px auto; border-radius: 10px; font-size: 18px;">
                            
                            Web App Development - Dot Net
                                <br />
                            Skill for Employment Investment Program Batch-20<br />
                            BASIS Institute of Technology & Management (BITM)
                                
                        </p>

            </div>

            <div class="footer">
                <h2>Developed by IIUC CODERS </h2>
            </div>

        </div>
    </form>
</body>
</html>
