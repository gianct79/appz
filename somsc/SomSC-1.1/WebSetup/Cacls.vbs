'
' Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
'
' Do not re-use without permission.
'

Dim customData, targetFolder, iisVersion, account, retCode, oShell, oFso

customData = Split(Session.Property("CustomActionData"), ",")

'MsgBox customData(0)
'MsgBox customData(1)

targetFolder = Trim(customData(0)) & "App_Data"
iisVersion = Trim(customData(1))

If iisVersion = "#7" Then
  account = "IIS_IUSRS"
ElseIf iisVersion = "#6" Then
  account = "IIS_WPG"
Else
  account = "Everyone"
End If

'MsgBox account

Set oShell = CreateObject("Wscript.Shell")
Set oFso = CreateObject("Scripting.FileSystemObject")

If oFso.FolderExists(targetFolder) Then
  retCode = oShell.Run("cacls.exe " & targetFolder & " /C /E /T /G " & account & ":C ", 2, True)
End If

Set oFso = Nothing
Set oShell = Nothing
