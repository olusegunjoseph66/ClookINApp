   M S B A M L   `   `   `  ����I  EClockINVerraki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClockINVerraki.PageClockINVerraki.Page  5   	   %    ClockINVerraki.Page.ViewDetails   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ClockINVerraki.Page     5   	     � Title$  View Profile��5   	   $	��450��6   $	��800��6+    J� InputBindings 5
      �� 5   
   
 �� Key$ P��6    �� 	Modifiers$ Controlf�6    �� Command 61   �� *PrintCommand+.��5      � -   5         �Name$ MainGrid��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5$   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��10q�6K   5)      �� 52   
   -   5        $��	LogoImage��52      $��2��6!   $��30,10,10,30q�6/   $��40��6D   $	��250��6P   $��Center=�6\   $��Uniform=�6w   �� 55   
   -   5        $��UserPictureImage��55      $��3��6(   $��30,10,10,10q�66   $��80��6K   $	��350��6W   $��Center=�6c   $��Uniform=�6~   �� 57   
   -   5        $��	IDTextBox��57      $�� ��6   $��4��6-   $��	80,0,0,10q�6:   $��38��6M   $	��200��6Y   $��Center=�6e   $��35(�6�   $
��Bold"�6�   �� 58   
   -   5        $��FirstNameTextBox��58      $�� ��6   $��5��64   $��	120,0,0,0q�6A   $��20��6T   $	��200��6`   �� 59   
   -   5        $��LastNameTextBox��59      $�� ��6   $��6��63   $��	120,0,0,0q�6@   $��30��6S   $	��200��6_   $��Center=�6k   5;      5=      