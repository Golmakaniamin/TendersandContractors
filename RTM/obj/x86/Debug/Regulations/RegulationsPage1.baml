   M S B A M L   `   `   `  ����I  EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null��clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit,Version=3.5.40128.1,Culture=neutral,PublicKeyToken=31bf3856ad364e35Microsoft.Windows.Controls  5
       RTM&    RTM.Regulations.RegulationsPage1   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6dp-http://schemas.microsoft.com/wpf/2008/toolkit   5      �my�clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit,Version=3.5.40128.1,Culture=neutral,PublicKeyToken=31bf3856ad364e35   5
      -   5          N�Name$
  page��5       N� Title$ RegulationsPage1��5
      .��5      � -   5         �Name$ 
layoutRoot��5      .+�5   
   � $��Stretch=�6   $��Center=�6-   $	��768��6H   $
��1024��6U   .+�5      �� -   5        $��Border��5   �   
�������$��1q�6?    �� CornerRadius$ 0��6S   $	��508��6d   $��Right=�6q    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��834��6�   $��
0,0,90,139q�6�   ��6(   Z� ._�5      �� -   5        $��label2��5   #   $��0��6   $��0��61   5      �� 5      -   5        $��Title��5   �   $.��(ثبت و ویرایش آیین نامه��6   $%��/RTM;component/Fonts/#B Nazanin)�65   $��23(�6b   
���   �$��51��6�   $��Right=�6�   $��Center=�6�   $��0,121,105,596q�6�      
TitleLabel#��[  6�   $��Stretch=�6  $��Center=�63  $��Normal"�6U  �� 5      -   5        $��SaveBtn��5   :   $��ثبت��6   $��271,583,0,153q�6#   $	��120��6I   $��10��6U   $
��Left=�6y   �� 5      -   5        $��
ConfirmBtn��5   ,   $��145,583,0,153q�6   $	��120��6>   $��تایید نهایی��6J   $��11��6`   $
��Left=�6�   �� 5      -   5        $��EditBtn��5   =   $��ویرایش��6   $��0,583,507,153q�6&   $	��120��6L   $��Right=�6X   $��9��6t   6�   �� 5      -	   5        $��TypeCom��5   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�63   $��20(�6`   $��32��6n   $��497,185,231,0q�6z    �� SelectedIndex$ 0��6�   $	��Top=�6�   $��Center=�6�   $��Normal"�6�   $��0��6    �� Text 6  ��  �� ElementName$
 page�� �� Path$ CurrentRegulation.Type�.@�5      �� $��
قانون��6   61   �� 5      $��آئين نامه��6   65   �� 5      $��بخشنامه��6   63   �� 5      $��دستورالعمل��6   66   �� 5      $��
نشریه��6   61   5      �� 5      -
   5        $��TitleTxt��5   9   $��32��6   $��271,373,231,0q�6"   $	��Top=�6I   	 � UseLayoutRounding	 .  $��Center=�6{   
 �� TextAlignment$

 Left=�6�    �� MaxLines$ 5��6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��Right=�6�   $��20(�6  $%��/RTM;component/Fonts/#B Nazanin)�6  $��RightToLeft=�6B  $��Normal"�6^  $��5��6r  ��6  �� $
 page��$ CurrentRegulation.Title� �� Mode$ TwoWay=�&   System.Windows.Controls.DataGrid  5      -   5        $
��Grid��5   �      AutoGenerateColumns .  $	��169��63      CanUserAddRows .  $
��Left=�6X   $��271,408,0,0q�6s   $	��Top=�6�   $	��522��6�   $��Center=�6�      SelectionMode$ Single=�6�   $��Center=�6�   $��20(�6  $%��/RTM;component/Fonts/#B Nazanin)�6#  $��RightToLeft=�6P     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns .  $��Normal"�6�  $��8��6�     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ زمان بارگذاري��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� $ AttachedDate�  dateConverter �� 	Converter# [   5       $ توضيحات��6*    6;   �� *	Version+4  .System.Windows.Controls.DataGridTemplateColumn  5"         CellTemplate 5#      �� 5$      .R�5%   "   �� -   5        $��مشاهده��5%   )   $��5q�6:   6E   5&      5(        5)       5*      �� 5+      .R�5,   "   �� -   5        $��حذف��5,   )   $��5q�67   6B   5-      5/      53      �� 54      -   5        $��	BrowseBtn��54   B   $��افزودن فایل��6   $��142,452,762,0q�6+   $	��120��6S   $��30��6_   $	��Top=�6k   $��7��6�   6�   �� 55      -   5        $��GroupCom��55   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�63   $��20(�6`   $��Normal"�6n   $��32��6�   $��497,223,231,0q�6�   $ 0��6�   $	��Top=�6�   $��Center=�6�   $��1��6   6  �� $
 page��$ CurrentRegulation.Group�.@�56      �� $��مناقصات��6   63   �� 57      $��ارزيابي��6   63   �� 58      $��قراردادها��6   65   �� 59      $��
حقوقي��6   61   5:      �� 5;      -   5        $��	ActingCom��5;   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�63   $��20(�6`   $��Normal"�6n   $��497,261,230,475q�6�   $��Center=�6�   $��2��6�    �� DisplayMemberPath$ Title��6�    �� SelectedValuePath$ ChartNodeId��6�   $ 0��6j   �� SelectedValue 6  �� $
 page��$) #CurrentRegulation.ActingReferenceId�6j  �� 5<      -   5        $��ReferenceCom��5<   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�63   $��20(�6`   $��Normal"�6n   $��32��6�   $��497,299,231,0q�6�   $	��Top=�6�   $��Center=�6�   $��3��6�   $ Title��6V  $ IssuingReferenceId��6p  $ 0��6�   6   �� $
 page��$* $CurrentRegulation.IssuingReferenceId�6�  �� 5=      -   5        $��label1��5=   `   $��نوع :��6   $��40��6$   $
��Left=�60   $��799,181,0,0q�6K   $	��Top=�6n   $��20(�6�   $%��/RTM;component/Fonts/#B Nazanin)�6�   $��RightToLeft=�6�   $
��Left=�6�   $��Center=�6�   $	��120��6!  �� 5>      -   5        $��label3��5>   �   $��
گروه :��6   $��RightToLeft=�6%   $%��/RTM;component/Fonts/#B Nazanin)�6A   $��20(�6n   $��41��6|   $
��Left=�6�   $
��Left=�6�   $��799,219,0,0q�6�   $	��Top=�6�   $��Center=�6   $	��120��6"  �� 5?      -   5        $��label4��5?   �   $&�� واحد اقدام کننده :��6   $��RightToLeft=�61   $%��/RTM;component/Fonts/#B Nazanin)�6M   $��20(�6z   $��41��6�   $��Right=�6�   $
��Left=�6�   $��0,256,105,0q�6�   $	��Top=�6�   $��Center=�6  $	��129��6/  �� 5@      -   5        $��label5��5@   �   $$��مرجع صادر کننده :��6   $��RightToLeft=�60   $%��/RTM;component/Fonts/#B Nazanin)�6L   $��20(�6y   $��41��6�   $
��Left=�6�   $
��Left=�6�   $��790,294,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��129��6-  �� 5A      -   5        $��label6��5A   �   $��تاریخ صدور :��6   $��RightToLeft=�6+   $%��/RTM;component/Fonts/#B Nazanin)�6G   $��20(�6t   $��41��6�   $
��Left=�6�   $
��Left=�6�   $��799,333,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��120��6(  �� 5C      -   5        $��label7��5C   �   $�� عنوان :��6   $��RightToLeft=�6'   $%��/RTM;component/Fonts/#B Nazanin)�6C   $��20(�6p   $��41��6~   $
��Left=�6�   $
��Left=�6�   $��799,369,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��120��6$  +   %Microsoft.Windows.Controls.DatePicker  5D      -   5        $��datePicker1��5D   L   $
��Left=�6   $��498,340,0,0q�67   $	��Top=�6_   $��RightToLeft=�6w   $	��296��6�   $��28��6#  $��4��6/     SelectedDate 6�   �� $
 page��$# CurrentRegulation.IssuingDate�6/  �� 5E      -   5        $��
VersionTxt��5E   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�62   $��20(�6_   $��Normal"�6m   $��33.32��6�   $��Right=�6�   $
 Auto=�6�   $��142,413.32,762,0q�6�   $ 5��6�   $��6��6  $

 Left=�6  	 .  $	��Top=�6N  $��Center=�6f  �� 5F      -   5        $��label8��5F   �   $��توضيحات :��6   $��RightToLeft=�6(   $%��/RTM;component/Fonts/#B Nazanin)�6D   $��20(�6q   $��41��6   $
��Left=�6�   $
��Left=�6�   $��145,370,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��117��6%  �� 5G      -   5        $��label9��5G   �   $��(کلمات کلیدی)��6   $��RightToLeft=�6,   $%��/RTM;component/Fonts/#B Nazanin)�6H   $��20(�6u   $��41��6�   $��Right=�6�   $
��Left=�6�   $��0,391,110,0q�6�   $	��Top=�6�   $��Center=�6  $	��106��6*  5H      5I      5J      