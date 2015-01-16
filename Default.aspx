<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Automated_Live_Chat_Demo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Automated Live Chat Demo</title>
</head>
<body style="background-image:url(background.jpg)">
    <form id="form1" runat="server">
        <div>
        </div>
        <script type="text/javascript">
            (function () {
                var scriptElement = document.createElement('script');
                scriptElement.type = 'text/javascript';
                scriptElement.async = true;
                scriptElement.src = 'http://localhost:50977/ChatService.aspx?Get=Script';
                (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(scriptElement);
            })();
        </script>
    </form>
</body>
</html>
