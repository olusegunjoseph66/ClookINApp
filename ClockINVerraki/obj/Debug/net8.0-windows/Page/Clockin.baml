   M S B A M L   `   `   `  ����I  EClockINVerraki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ClockINVerraki.PageClockINVerraki.Page  5   	   !    ClockINVerraki.Page.Clockin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ClockINVerraki.Page     5   	     � Title$  Clock IN��5   	   $	��450��6   $	��800��6'   .��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��10q�6K   .+�5      �� $��Enter Your ID:��6   $��14(�6.   $��0,0,0,10q�6<   �� 5      -   5        $��UserIdTextBox��5      $	��200��6,   $��30��68   6v   �� 5      -   5        $��ValidationMessage��5      
���  ��$��12(�6B   $��0,10,0,0q�6P   �� 5      -   5        $��StatusTextBlock��5      
��� � �$
��Bold"�6B   $��0,10,0,0q�6T   5#      5$      5%      