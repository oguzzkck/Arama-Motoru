<%@ Page Language="C#" AutoEventWireup="true" CodeFile="siteSiralama.aspx.cs" Inherits="siteSiralama" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Site Sıralama</title>
    <style type="text/css">
        #grad1 {
            height: 40%;
            background: red; /* For browsers that do not support gradients */
            background: linear-gradient(white, black); /* Standard syntax (must be last) */
        }
        form{
            max-width:700px;
            margin:10px auto 0 auto;
            height:800px;
        }
        .buton{
            -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
            border-radius: 8px;
        }

        .buton:hover{
            background-color: #4278B6;
            color: white;
        }
        .sonuc{
            margin: 30px 0 0 0;
        }
        
        .header-icon {
            margin:60px auto 0 auto;
        }
        .search-webpage{
            margin:50px 0 0 0 ;
        }
        .search-key {
            margin: 30px 0 0 0;
        }
        footer {
            position: fixed;
            bottom: 0px;
            left: 0px;
            width: 100%;
            height: 50px;
            padding:15px;
            background-color: #111111;
            color:white;
            text-align:center;
        }
}
    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css" integrity="sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb" crossorigin="anonymous"/>
</head>
<body id="grad1">
    <form id="form1" runat="server">
        <nav class="nav nav-pills nav-fill">
          <a class="nav-item nav-link" href="index.aspx">Anahtar Kelime Saydırma</a>
          <a class="nav-item nav-link" href="sayfaSiralama.aspx">Sayfa (URL) Sıralama</a>
          <a class="nav-item nav-link active" href="siteSiralama.aspx">Site Sıralama</a>
          <a class="nav-item nav-link" href="semantikAnaliz.aspx">Semantik Analiz</a>
        </nav>
        
        <div class="header-icon">
            
            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/gorsel.png" />

        </div>

        <div class="search-webpage">

            <asp:Label ID="Label1" runat="server" Text="Arama yapmak istediğiniz URL giriniz"></asp:Label>

            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Width="680px" BorderStyle="Outset" Height="25px" ></asp:TextBox>

        </div>
        <div class="search-key">

            <asp:Label ID="Label2" runat="server" Text="Arama yapmak istediğiniz kelimeyi giriniz"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Width="535px" BorderStyle="Outset" Height="25px"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Height="29px" Text="ARA" Width="105px" CssClass="buton" OnClick="Button1_Click" />

        </div>

        <div class="sonuc">
            <asp:ListBox ID="ListBox6" runat="server" Height="115px" Width="152px" SelectionMode="Multiple" AutoPostBack="True"></asp:ListBox>
            <asp:ListBox ID="ListBox7" runat="server" Height="115px" Width="152px" SelectionMode="Multiple" AutoPostBack="True"></asp:ListBox>
            <asp:ListBox ID="ListBox8" runat="server" Height="115px" Width="377px" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="ListBox8_SelectedIndexChanged"></asp:ListBox>
            

            <asp:ListBox ID="ListBox1" runat="server" Height="115px" Width="686px" Visible="False"></asp:ListBox>
            <asp:ListBox ID="ListBox2" runat="server" Height="115px" Width="152px" SelectionMode="Multiple" Visible="False"></asp:ListBox>
            <asp:ListBox ID="ListBox3" runat="server" Height="115px" Width="152px" SelectionMode="Multiple" Visible="False"></asp:ListBox>
            <asp:ListBox ID="ListBox4" runat="server" Height="115px" Width="152px" SelectionMode="Multiple" Visible="False"></asp:ListBox>
            <asp:ListBox ID="ListBox5" runat="server" Height="115px" Width="152px" SelectionMode="Multiple" Visible="False"></asp:ListBox>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        </div>
     
        <footer>
         @2017 Oğuz Koçak - 150201177 \t Mehmet Emin Arslan - 150201127
        </footer>   
    </form>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
</body>
</html>
