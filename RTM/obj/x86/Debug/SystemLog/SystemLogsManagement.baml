   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RTMRTM  5	   �   (    "RTM.SystemLog.SystemLogsManagement   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ced4http://schemas.microsoft.com/expression/2010/drawing     5      6my-http://schemas.microsoft.com/wpf/2008/toolkit  5	   v   my1clr-namespace:RTM  6�   -   5          N�Name$  SystemLogManagement��5	   N    N� Title$ SystemLogManagement��6   $	��768��64   $
��1024��6A   $��0q�6k    N� 
Background 6   Z�  � 	Resources 5
        RTM.DateConverter   DateConverter1��%   &	          5   
   6   5      .��5      � -   5        $��
layoutRoot��5   0   $
��1024��6   $	��768��6   $��0q�6%   .+�5   
   �� -   5         ��Name$ border1_Copy1��5   �    J� 	AllowDrop . 
����������	#FF9A9696$��1q�6M    �� CornerRadius$ 0��6a   $	��638��6r   $��Right=�6   $��	0,0,18,59q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��986��6�   �� 5   
   -   5         ��Name$ label22��5      $��0��6   $��0��6,   $��521,384,503,384q�66   �� 5   
   -   5        $ border1��5   �    . 
�������$��1q�6L   $ 0��6`   $	��547��6q   $��Right=�6~   $��
0,0,36,109q�6�   $	 0.4Q�6�   $��Bottom=�6�   $	��953��6�   ��65   Z� 6�   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 datagrid��5   8  
   AutoGenerateColumns
 .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $	��441��6  $��Center=�6     SelectionMode$ Single=�6J  $��4��6a  $��Center=�6n  $��Bottom=�6�   � UseLayoutRounding .  $��49.962,0,48.501,124q�6�     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Date��,  &System.Windows.Controls.DataGridColumn   Header$ 
تاریخ��5   {   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ��  �� Path$
 Date�  dateConverter �� 	Converter# [ 6{     5      -   5        
SubSys��$ زیر سیستم��5   �    65   �� *	Subsystem+  subsystemConverter# [ 6�     5      -	   5        OperationType��$ نوع عملیات��5   {    66   �� *Type+  actionConverter# [ 6{     5      -
   5        LastName��$( "نام خانوادگی کاربر��5   N    61   �� *
LastName+6N     5      -   5        	FirstName��$ نام کاربر��5   V    68   �� *	FirstName+6V     5      -   5        	Title��$ سمت��5   N    64   �� *Title+6N     5      $ نام دستگاه��6B    6&   �� *	Machine+6B   5      �� 5   
   -   5        $ label24��5   �   $+��%مدیریت لاگ های سیستم��6   $��RightToLeft=�6/   $��	B Nazanin)�6K   $��20(�6b   $��50��6p   $
��Left=�6|   $
��Left=�6�   $��815,71.333,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��166��6  �� 5   
   -   5         ��Name$ PrintBtn��5      $��چاپ��6   $��	B Nazanin)�6   $��20(�66   $��32��6D   $
��Left=�6P   $��
35,665,0,0q�6k   $��5��6�   $	��Top=�6�   $��93��6�   $��Normal"�6�   6�   �� 5    
   -   5        $��label1_Copy1��5    �   $��زیر سیستم :��6   $��RightToLeft=�6&   $��	B Nazanin)�6B   $��20(�6Y   $��50��6g   $
��Left=�6s   $��Center=�6�   $��847,112,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��128��6  �� 5!   
   -   5        $��SubsystemCom��5!   �   $��RightToLeft=�6   $��	B Nazanin)�6/   $��20(�6F   $��Normal"�6T   $��33��6h   $��Right=�6t   $��0,121,168,0q�6�    �� SelectedIndex$ -1��6�   $��0��6�   $	��Top=�6�   $��Center=�6�   $	��203��6  .@�5"      �� $��مناقصات��6   �� 5#      $��قرارداد ها��6   �� 5$      $��آیین نامه ها��6   �� 5%      $!��مدیریت کاربران��6   5&      �� 5(   
   -   5        $��label1��5(   �   $��بازه زمانی :��6   $��RightToLeft=�6'   $��	B Nazanin)�6C   $��20(�6Z   $��50��6h   $
��Left=�6t   $��Center=�6�   $��519,109,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��128��6  +  %Microsoft.Windows.Controls.DatePicker  5)   
   -   5        $��Date1DP��5)   p   $��RightToLeft=�6   $��27��64   $
��Left=�6@   $��424,122,0,0q�6[   $��1��6   $	��Top=�6�   $	��109��6�     5*   
   -   5        $��Date2DP��5*   p   $��RightToLeft=�6   $��27��64   $
��Left=�6@   $��261,122,0,0q�6[   $��2��6   $	��Top=�6�   $	��109��6�   �� 5+   
   -   5        $��label2��5+   �   $
��تا��6   $��RightToLeft=�6   $��	B Nazanin)�69   $��20(�6P   $��50��6^   $
��Left=�6j   $��Center=�6�   $��379,109,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��34��6  �� 5,   
   -   5        $��button2��5,   �   $��
نمایش��6   $��	B Nazanin)�6!   $��20(�68   $��Normal"�6F   $��32��6Z   $
��Left=�6f   $��
50,122,0,0q�6�   $��3��6�   $	��Top=�6�   $��93��6�   6�   �� 5-   
   -   5        $��label3��5-   �   $��نام کاربر :��6   $��RightToLeft=�6&   $��	B Nazanin)�6B   $��20(�6Y   $��50��6g   $
��Left=�6s   $��Center=�6�   $��854,151,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��128��6  �� 5.   
   -   5        $��UserCom��5.   �    �� DisplayMemberPath$ Family��6    �� SelectedValuePath$ UserId��6.   $��RightToLeft=�6I   $��	B Nazanin)�6e   $��20(�6|   $��Normal"�6�   $��33��6�   $��Right=�6�   $��0,160,168,0q�6�   $ -1��6�   $��0��6�   $	��Top=�6
  $��Center=�6"  $	��203��6D  5/      50      51      