'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Email. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Email
Imports Aspose.Email.Mail

Namespace DeliveryNotifications
	Public Class Program
		Public Shared Sub Main(ByVal args() As String)
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			'Create an instance MailMessage class
			Dim msg As New MailMessage()

			'Setting Delivery Notification 
			msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess


			'use MailMessage properties like specify sender, recipient and message
			msg.To = "asposetest123@gmail.com"
			msg.From = "newcustomeronnet@gmail.com"
			msg.Subject = "Test Email"
			msg.Body = "Hello World!"


			'Create an instance of SmtpClient class
			Dim client As SmtpClient = GetSmtpClient()

			Try
				'Client.Send will send this message
				client.Send(msg)
                'Message sent successfully
				System.Console.WriteLine("Message sent")

			Catch ex As System.Exception
				System.Diagnostics.Trace.WriteLine(ex.ToString())
			End Try

		End Sub

		Private Shared Function GetSmtpClient() As SmtpClient
			Dim client As New SmtpClient("smtp.gmail.com", 587, "asposetest123@gmail.com", "F123456f")
			client.SecurityMode = SmtpSslSecurityMode.Explicit
			client.EnableSsl = True

			Return client
		End Function
	End Class
End Namespace