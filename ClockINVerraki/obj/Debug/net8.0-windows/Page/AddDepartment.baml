   M S B A M L   `   `   `  ����I  EClockINVerraki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClockINVerraki.PageClockINVerraki.Page  5   	   '    !ClockINVerraki.Page.AddDepartment   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ClockINVerraki.Page     5   	     � Title$  Add New Department��5   	   $	��450��6$   $	��800��61   .��5	      � .+�5
   
   �� -   5        $��NameTextBox��5
      $	��200��6%   $��30��61   $��10q�6=   $	��Top=�6J   �� 5   
   -   5        $��ItemsListBox��5      $
{�True��6&   $��10,100,10,10q�67    �� DisplayMemberPath$
 Name��6M   �� 5   
   -   5        $��DeleteDepartment��5   +   $��Delete Selected��6   $	��150��6C   $��30��6O   $��Bottom=�6[   $��10q�6v   6�   �� 5   
   -   5         ��Name$ CreateDepartment��5      $��Add Department��6+   $
��Left=�6c   $��
540,20,0,0q�6~   $	��Top=�6�   5      5      