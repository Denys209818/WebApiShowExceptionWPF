   M S B A M L   `   `   `  ����K  GWPF.ErrorService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPF.ErrorServiceWPF.ErrorService  5   	   "    WPF.ErrorService.ErrorWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPF.ErrorService     5   	   -   5          � Title$  Помилка!!!��5   	   $	��250��6   $	��400��6)    � 	Resources 5	       
  labels �� 
TargetType �� Property �� Value��%z   &	        �� 5
   
   " ��6   .�5      ��  � ��
 �  ��6+   �� 5       � ��$
 Bold"�6+   5      5      .��5      � .+�5   
   �� .+�5      � $��Center=�6   .+�5      �� $��Center=�6   #���   65   $��Код помилки:��6V   �� 5      $��Center=�6   ��65   �� *Status+5      &   System.Windows.Controls.DataGrid  5      -   5        $��dgError��5   .      CanUserAddRows$ False��6   "   VerticalScrollBarVisibility$
 Auto=�6=   $	��200��6`      AutoGenerateColumns$ False��6m      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Помилка��6)   
   
Foreground

 �  ��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   �� *Error+5      5      5      5      