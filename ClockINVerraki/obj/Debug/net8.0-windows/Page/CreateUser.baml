   M S B A M L   `   `   `  ����I  EClockINVerraki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClockINVerraki.PageClockINVerraki.Page  5   	   $    ClockINVerraki.Page.CreateUser   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ClockINVerraki.Page     5   	     � Title$  
CreateUser��5   	   $	��450��6   $	��600��6)   .��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5&   
   �� $��
FirstName:��6   $��0��6&   $��0��63   $��3q�6C   $��Center=�6N   �� 5'   
   -   5        $��FNameTextBox��5'      $��0��6&   $��1��63   $��30,10,10,30q�6C   $��40��6X   $	��250��6d   �� 5)   
   $��	LastName:��6   $��1��6%   $��0��62   $��3q�6B   $��Center=�6M   �� 5*   
   -   5        $��LNameTextBox��5*      $��1��6&   $��1��63   $��30,10,10,30q�6C   $��40��6X   $	��250��6d   �� 5-   
   $��Select Department:��6   $��2��6.   $��0��6;   $��3q�6K   $��Center=�6V   �� 5/   
   -   5         ��Name$ DepartmentcomboBox��5/      $��2��60   $��1��6=   $	��120��6M   $��40��6Y   $��30,10,10,30q�6e    �� DisplayMemberPath$
 Name��6|    �� SelectedValuePath$ Id��50      $
��Left=�6V    �� SelectedValue 6+   �� *SelectedItemId+6V   �� 53   
   $��
TakePhoto:��6   $��3��6&   $��0��63   $��3q�6C   $��Center=�6N   �� 57   
   -   5        $��
WebcamFeed��57      $��3��6"   $��1��6/   $	��120��6?   $��30,10,10,30q�6M   �� 5:   
   -   5        $��ShutdownButton��5:      $��Close WebCam��6'   $	��100��6\   $��4��6h   $��0��6u   $��20,10,10,30q�6�   �� 5<   
   -   5        $��CaptureAndSave��5<   "   $��Submit��6   $��4��68   $��0��6E   $��2��6U   $��30,10,10,30q�6i   $��Center=�6~   6�   �� 5>   
   $&�� Press Ctrl+X to close the webcam��6   $��16(�6<   $
��Bold"�6J   $��5��6\   $��0��6i   $��30,10,10,30q�6y   5J      5K      