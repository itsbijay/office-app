# officeapp
I will be including few MS office apps both VSTO and Office Js Web apps.


## Project 1:  Outlook Protect ##

Outlook addin to help protect users from accidental sending of attachments to external domains from your organisation. 
This also look for any attachments in the email. 

You will need to define your organisation domain name in configuration file.
It will then treat all other domain as external and show alert popup when user click on send button.

1) Configuration stored at OutlookUtility.cs: 

Replace gmail with your own domain value.
private static readonly string ALLOWED_DOMAIN = @"gmail"; // your org domain name.

2) All VSTO application requires code signing, It is recommended that you use your or code signing certificate, alternatly visual studio automatically create and sign cert automatically.


## Project 2:  Office Helper ##

Office Helper Add-ins is a chat utility that provide access of chat utilities from office application.

sharing common configurations (SupportChat.xml), source code (ChatRibbon.cs) and chat icon (Chat.png) file; All common files are stored at common location i.e. $\officehelper-vsto\resource. 

1)	Chat.png: This file is used to display chat icon across all MS office products. (Under Home, Support tab)									
	This file must be in png format, 
	This file must have 74X74 dimension,
	This file name must be chat.png.

To change the image file, you first need to replace this file in this folder repackage the application.

2)	SupportChat.xml: This configuration file is used for button position, button label, new tab label, button tool tip and chat url.

	Refer the documentation for details about this custom UI.
	This xml file must be updated carefully preferably by developer.
	All changes to this file must be thoroughly test again.
	Setup tag attribute to configure support chat https url.

To change the button configurations or chat URL, you should update this file and repackage the application.

3)	ChatRibbon.cs: This is a source file which handles the click event of the Chat button. This is written in C# language. This file handles the logic to open Url in a default browser. Any changes must be recompiled and repackaged.

4)	Additonally for runnign Office application, your application must be signed by codesign private key certificate.. You can use the default signing cert created by IDE.
5)	Install the latest "Microsoft visual studio setup project" from visual studio "Extension-> Manage Extension" section.
