   M S B A M L   `   `   `  ����I  EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null[<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkitMicrosoft.Windows.Controls  5       RTM3   -RTM.Tendering1.UI17RegisterParticipationBills   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ced4http://schemas.microsoft.com/expression/2010/drawing     5      Lmyd<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit     5      -   5          N�Name$
  page��5
   Y    N� Title$$ UI17RegisterParticipationBills��6   $	��768��6?   $
��1024��6L   $��0q�6g    N� 
Background 6)   Z� .��5      � -   5        $��
layoutRoot��5   0   $
��1024��6   $	��768��6   $��0q�6%   .+�5   
   �� -   5         ��Name$ border1_Copy1��5   �    J� 	AllowDrop . 
����������	#FF9A9696$��1q�6M    �� CornerRadius$ 0��6a   $	��550��6r   $��Right=�6   $��
0,0,27,137q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��986��6�   �� 5   
   -   5         ��Name$ label22��5      $��0��6   $��0��6,   �� 5   
   -   5        $ border1��5   �    . 
�������$��1q�6L   $ 0��6`   $��472.5��6q   $��Right=�6�   $��0,0,45,183.5q�6�   $	 0.4Q�6�   $��Bottom=�6�   $	��953��6�   ��65   Z� 6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5   8  	   AutoGenerateColumns	 .  
   CanUserAddRows
 .    CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $	��230��6  $��Center=�6     SelectionMode$ Single=�6J  $��1��6a  $��Center=�6n  $��Bottom=�6�   � UseLayoutRounding .  $��142.857,0,58.5,383.5q�6�     
IsReadOnly .  $   HorizontalScrollBarVisibility$ Visible=�6     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        GauranteeNom��,  &System.Windows.Controls.DataGridColumn   Header$ شماره سند��5   V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Number+6V   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ تاریخ ثبت��6)      CellTemplate 5      �� 5      .R�5      +   %Microsoft.Windows.Controls.DatePicker  $��5q�6�      SelectedDate 6-   �� *RegisterDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5        5      $ تاریخ اعتبار��6)    5      �� 5      .R�5        $��5q�6�    6-   �� *ValidityDate+$ TwoWay=�$ PropertyChanged=�6�   5      5         5!      -   5        Bank��$ 
عنوان��5!   R    63   �� *
StockTitle+6R     5"      -	   5        	Price��$ مبلغ��5"   `      
FontFamily$ Tahoma)�6n      FontSize$ 17Q�6�    64   �� *Amount+ �� StringFormat$ N0��6�   5$      �� 5%   
   -
   5        $ label24��5%   �   $$��ثبت اوراق مشارکت��6   $��RightToLeft=�6+   $��	B Nazanin)�6G   $��20(�6^   $��50��6l   $
��Left=�6x   $
��Left=�6�   $��806,71.333,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��166��6  �� 5&   
   -   5         ��Name$ SaveBtn��5&      $��ثبت��6   $��	B Nazanin)�6   $��20(�66   $��32��6D   $
��Left=�6P   $��
26,591,0,0q�6k   $��4��6�   $	��Top=�6�   $��93��6�   $��Normal"�6�   6�   �� 5'   
   -   5        $ 	DeleteBtn��5'   �   $��حذف مورد��6   $��	B Nazanin)�6$   $��20(�6;   $��Normal"�6I   $��32��6]   $��Right=�6i   $��0,352,888,0q�6�   $��2��6�   $	��Top=�6�   $��96��6�   6�   �� 5(   
   -   5        $��label1_Copy1��5(   �   $%��انتخاب پیمانکار :��6   $��RightToLeft=�6,   $��	B Nazanin)�6H   $��20(�6_   $��50��6m   $
��Left=�6y   $��Center=�6�   $��838,107,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��128��6  �� 5)   
   -   5        $��label49��5)   �   $��توضیحات :��6   $��RightToLeft=�6$   $��	B Nazanin)�6@   $��20(�6W   $��50��6e   $
��Left=�6q   $
��Left=�6�   $��888,0,0,341q�6�   $��Bottom=�6�   $��Center=�6�   $��80��6  �� 5*   
   -   5        $��DescriptionTxt��5*   �   $��RightToLeft=�6   $��	B Nazanin)�6.   $��18(�6E   $��Normal"�6S   $��Right=�6g   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $"��142.857,416.722,58.393,183.5q�6�    �� MaxLines$ 5��6�   $��3��6�     �� TextAlignment$
  Left=�6  ! �� TextWrapping$
! Wrap=�6   .  $��Stretch=�6I  $��Stretch=�6e  "" �� VerticalScrollBarVisibility$
" Auto=�6�  # � DataContext# 6�  �� $ �� ElementName$$ dataGrid��% �� Path$% SelectedItem���6�  �� *Description+�� 5+   
   -   5        $��	ChooseCom��5+   �   $��RightToLeft=�6   $��	B Nazanin)�6/   $��20(�6F   $��Normal"�6T   $��33��6h   $��Right=�6t   $��0,116,183,0q�6�   & �� SelectedIndex$& 0��6�   $��0��6�   $	��Top=�6�   $��Center=�6�   $	��203��6  ' �� SelectedValuePath$' ContractorId��6O  ( �� DisplayMemberPath$( CompanyName��6p  5,      5-      