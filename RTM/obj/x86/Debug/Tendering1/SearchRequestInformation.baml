   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RTMRTM  5   i   -    'RTM.Tendering1.SearchRequestInformation   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6I   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   @d2http://schemas.microsoft.com/expression/blend/2008     6�   Ced4http://schemas.microsoft.com/expression/2010/drawing     6  :Custom-http://schemas.microsoft.com/wpf/2008/toolkit  6D  myclr-namespace:RTM  5   i   -   5          N�Name$
  page��5   P    N� Title$
 UI25��6   $	��768��66   $
��1024��6C   $��0q�6^    N� 
Background 6    Z� .��5   
   � $	��768��6   $��10,10,-10,-10q�6   $
��1024��63   .+�5   
   �� -   5         ��Name$ border3��5   �    J� 	AllowDrop . 
����������	#FF9A9696$��1q�6M    �� CornerRadius$ 0��6a   $	��580��6r   $��Right=�6   $��
0,0,20,140q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��989��6�   ._�5      �� -   5         ��Name$ label48��5      $��0��6   $��0��6-   5	      �� 5
   
   -   5        $ border1��5
   �    . 
����������	#FF9A9696$��1q�6M   $ 0��6a   $	��304��6r   $��Right=�6   $��
0,0,30,402q�6�   $	 0.4Q�6�   $��Bottom=�6�   $	��967��6�   ._�5      �� -   5        $ label1��5      $��0��6   $��0��6/   5      �� 5   
   -   5        $ label5��5      $��0��6   $��0��6+   $��504,424,520,344q�65   �� 5   
   -   5        $ label6��5   �   $7��1جستجوی اطلاعات درخواست ها :��6   $��RightToLeft=�66   $��	B Nazanin)�6R   $��20(�6i   $��50��6w   $
��Left=�6�   $
��Left=�6�   $��
769,53,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��218��6  �� 5   
   -   5         ��Name$ 	SearchBtn��5   }   $��
جستجو��6   $��	B Nazanin)�6!   $��20(�68   $��Normal"�6F   $��40��6Z   $��536,148,378,0q�6f   $��3��6�   $	��Top=�6�   $��Center=�6�   6�   �� 5   
   -	   5        $��	ReqNomTxt��5   <  $��RightToLeft=�6S   $��	B Nazanin)�6o   $��20(�6�   $��Normal"�6�   $��31��6�   $
��Left=�6�   $��Right=�6�   $	 �� HorizontalScrollBarVisibility$
	 Auto=�6�   $��660.5,93.5,0,0q�6  
 �� MaxLines$
 5��6/  $��0��6M   �� TextAlignment$
 Left=�6[   �� TextWrapping$
 Wrap=�6p   � UseLayoutRounding .  $	��Top=�6�  $��Center=�6�  $	��188��6�  ��6   ��  �� ElementName$
 page�� �� Path$ CurrentReq.RequestNumber�6�  �� 5   
   -
   5        $��label7��5   �   $!��شماره درخواست :��6   $��RightToLeft=�6*   $��	B Nazanin)�6F   $��20(�6]   $��50��6k   $
��Left=�6w   $��Center=�6�   $��
844,84,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��150��6  �� 5   
   -   5        $��label9��5   �   $��عنوان پروژه :��6   $��RightToLeft=�6(   $��	B Nazanin)�6D   $��20(�6[   $��50��6i   $��Right=�6u   $��Center=�6�   $��
0,116,42,0q�6�   $	��Top=�6�   $��Center=�6�   $��97��6  �� 5   
   -   5        $��label10��5   �   $"��تاریخ درخواست : ��6   $��RightToLeft=�6+   $��	B Nazanin)�6G   $��20(�6^   $��50��6l   $��Right=�6x   $��Center=�6�   $��
0,148,30,0q�6�   $	��Top=�6�   $��Center=�6�   $	��150��6  �� 5   
   -   5        $��TitleTxt��5   4  $��RightToLeft=�6R   $��	B Nazanin)�6n   $��20(�6�   $��Normal"�6�   $
��Left=�6�   $��Right=�6�   $
	 Auto=�6�   $��660.5,127.5,0,609.5q�6
  $
 5��6'  $��1��6D  $
 Left=�6R  $
 Wrap=�6g   .  $��Center=�6�  $	��188��6�  ��6   �� $
 page��$ CurrentReq.ProjectTitle�6�  +  %Microsoft.Windows.Controls.DatePicker  5   
   -   5        $��DateDP��5   �   $��RightToLeft=�6[   $��27��6w   $��660,161,176,579q�6�   $��2��6�      Text 6   �� $
 page��$ CurrentReq.RequestDate�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $
��Grid��5   T     AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $��148.333��6  $��Center=�6  $��52.5,0,0,421.5q�6<     SelectionMode$ Single=�6`  $��4��6w   .  $��Bottom=�6�  $��Center=�6�  $
��Left=�6�  $	��903��6�     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ شماره درخواست��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *RequestNumber+  5      $ عنوان پروژه��6%    6:   �� *ProjectTitle+  5      $ محل اجرا��6%    68   �� *
Location+  5      $ تاریخ درخواست��6%    6=   �� $ RequestDate�   dateConverter �� 	Converter# [  5      �� 5   
   -   5        $��button2��5   }   $��ویرایش��6   $��	B Nazanin)�6"   $��20(�69   $��Normal"�6G   $��39��6[   $��27,578,889,0q�6g   $��5��6�   $	��Top=�6�   6�       RTM.TenderingHeaderControl  5   
   -   5          Name$ Header��5   S   $
��Left=�6$   $��
28,372,0,0q�6?   $	��Top=�6c   5       5"      