   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RTMRTM  5
      "    RTM.Tendering1.UI5TenderDocs   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ced4http://schemas.microsoft.com/expression/2010/drawing     5       myclr-namespace:RTM     5
      -   5          N�Name$
  page��5	   D    N� Title$	 UI5��6   $	��768��6$   $
��1024��64   $��0q�6R    N� 
Background 6   Z� .��5      � -   5         �Name$ 
layoutRoot��5   +   $	��768��6   $
��1024��6   .+�5   
   � $
��1024��6   $	��768��6   $��0q�6)   .+�5      �� -   5         ��Name$ border1_Copy1��5   �    J� 	AllowDrop . 
����������	#FF9A9696$��1q�6Q    �� CornerRadius$ 0��6e   $	��450��6v   $��Right=�6�   $��
0,0,16,170q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��989��6�   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$
 Grid��5   S  	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     
IsReadOnly .    CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6
  $��180.429��6  $��Center=�6/     SelectionMode$ Single=�6a  $��4��6x  $��Center=�6�  $��Bottom=�6�   � UseLayoutRounding .  $��0,0,40,185.5q�6�  $��Right=�6�  $	��741��6     Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
عنوان��6-      MinWidth$	 170Q�6<      
IsReadOnly .     CellTemplate 5      �� 5      .R�5   "   �� $��	DocTitles��6+    �� DisplayMemberPath$ Title��6<    �� SelectedValuePath$ DocumentIndex��6V   {�.   �� SelectedValue 6x   ��  �� Path$ DocumentIndex� �� Mode$ TwoWay=���6�   �� $ DocTypes� �� RelativeSource �� *FindAncestor+ �� AncestorType" N�6!  5      5      0  *System.Windows.Controls.DataGridTextColumn  5       . $ زمان بارگذاري��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� $ AttachedDate�   dateConverter �� 	Converter# [    5      $ توضيحات��6)    6:   �� $ Version�$ TwoWay=�  5      $ مشاهده��6-    5      �� 5      .R�5   "   �� -   5        $��مشاهده��5   )   $��5q�6:   6F   5      5         5!      $ حذف��6-    5"      �� 5#      .R�5$   "   �� -   5        $��حذف��5$   )   $��5q�67   6B   5%      5'      5)      �� 5*      -   5          ��Name$  label22��5*      $��0��6   $��0��60   $��520,462,504,306q�6:   �� 5+      -   5        $  label24��5+   �   $��اسناد مناقصه��6   $��RightToLeft=�6+   $��	B Nazanin)�6G   $��20(�6^   $��50��6l   $
��Left=�6x   $
��Left=�6�   $��890,148,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��95��6      RTM.TenderingHeaderControl  5,      -	   5        !  Name$! Header��5,   W   $
��Left=�6(   $��
34,194,0,0q�6C   $	��Top=�6g   $	��193��6   �� 5-      -
   5        $��
AddFileBtn��5-   �   $"��افزودن فایل سند��6   $��	B Nazanin)�6/   $��20(�6F   $��Normal"�6T   $��32��6h   $��Right=�6t   $��0,474,855,0q�6�   $��2��6�   $	��Top=�6�   $	��132��6�   6�   �� 5.      -   5        $��button2��5.   p   $��  تازه سازي��6   $��	B Nazanin)�6+   $��20(�6B   $��Normal"�6P   $��32��6d   $��3��6   $	��132��6�   $
��Left=�6�   $��
37,511,0,0q�6�   $	��Top=�6�   6�   �� 5/      -   5        $��
VersionTxt��5/   �   $��RightToLeft=�6   $��	B Nazanin)�62   $��20(�6I   $��Normal"�6W   $��31��6k   $
��Left=�6w   $��Right=�6�   $" �� HorizontalScrollBarVisibility$
" Auto=�6�   $��37,439.225,0,0q�6�   # �� MaxLines$# 5��6�   $��1��6  $�� ��6  $ �� TextAlignment$
$ Left=�6&  % �� TextWrapping$
% Wrap=�6;   .  $	��Top=�6i  $��Center=�6�  $	��132��6�  �� 50      -   5        $��DocTypesCom��50   �   $��RightToLeft=�6   $��	B Nazanin)�63   $��20(�6J   $��Normal"�6X   $��33��6l   $
��Left=�6x   $��
37,401,0,0q�6�   & �� SelectedIndex$& 0��6�   $��0��6�   $	��Top=�6�   $��Center=�6�   $	��133��6  $ Title��6  $ DocumentIndex��69  �� 51      -   5        $��label1��51   �   $��نوع سند :��6   $��RightToLeft=�6(   $��	B Nazanin)�6D   $��20(�6[   $��50��6i   $
��Left=�6u   $
��Left=�6�   $��164,393,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��74��6  �� 52      -   5        $��label2��52   �   $��توضیحات :��6   $��RightToLeft=�6(   $��	B Nazanin)�6D   $��20(�6[   $��50��6i   $
��Left=�6u   $
��Left=�6�   $��158,430,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��85��6  53      54      55      