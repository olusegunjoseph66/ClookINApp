   M S B A M L   `   `   `  ���� I  EClockINVerraki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClockINVerraki.PageClockINVerraki.Page  $    ClockINVerraki.Page.CreateUser   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:ClockINVerraki.Page       � Title$  
CreateUser��$	��450��$	��600��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto �.+��� $��
FirstName:��$��0��$��0��$��3q�$��Center=��� -   $��FNameTextBox��$��0��$��1��$��30,10,10,30q�$��40��$	��250���� $��	LastName:��$��1��$��0��$��3q�$��Center=��� -   $��LNameTextBox��$��1��$��1��$��30,10,10,30q�$��40��$	��250���� $��Select Department:��$��2��$��0��$��3q�$��Center=��� -    ��Name$ DepartmentcomboBox��$��2��$��1��$	��120��$��40��$��30,10,10,30q� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id��$
��Left=� �� SelectedValue �� *SelectedItemId+�� $��
TakePhoto:��$��3��$��0��$��3q�$��Center=��� -   $��
WebcamFeed��$��3��$��1��$	��120��$��30,10,10,30q��� -   $��ShutdownButton��$��Close WebCam��$	��100��$��4��$��0��$��20,10,10,30q��� -   $��CaptureAndSave��$��Submit��$��4��$��0��$��2��$��30,10,10,30q�$��Center=��� $&�� Press Ctrl+X to close the webcam��$��16(�$
��Bold"�$��5��$��0��$��30,10,10,30q�