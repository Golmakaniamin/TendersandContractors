   M S B A M L   `   `   `  ����I  EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null[<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkitMicrosoft.Windows.Controls  5       RTM   RTM.Tendering1.Tazmin   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Lmyd<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit     5      6my-http://schemas.microsoft.com/wpf/2008/toolkit   5	      -   5          N� Title$  Tazmin��5	      $��Center=�6_   $��Center=�6|   .��5
      � -   5         �Name$ 
layoutRoot��5
   +   $	��768��6   $
��1024��6   .+�5   
   � $��Center=�6   $��Center=�6*   $��0q�6G   .+�5      �� -   5        $��border1_Copy1��5   �    J� 	AllowDrop . 
����������	#FF9A9696$��1q�6Q    �� CornerRadius$ 0��6e   $	��584��6v   $
��Left=�6�   $��94,95,90,20q�6�    J� Opacity$	 0.4Q�6�   $	��Top=�6�   $	��826��6�   �� 5      -   5        $��border1��5   �    . 
�������$��1q�6P   $ 0��6d   $	��532��6u   $
��Left=�6�   $��111,128,90,20q�6�   $	 0.4Q�6�   $	��Top=�6�   $	��793��6�   ��69   Z� 6�   &   System.Windows.Controls.DataGrid  5      -   5        $��dataGrid��5   y     AutoGenerateColumns .     CanUserAddRows .    CanUserReorderColumns .     CanUserResizeRows .  	   CanUserSortColumns	 . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $��162.896��6�   $��Center=�6  $
   HorizontalScrollBarVisibility$
 Visible=�6%     
IsReadOnly .  $��123.333,177,0,0q�6`     SelectionMode$ Single=�6�  $��2��6�   � UseLayoutRounding .  $	��Top=�6�  $��Center=�6�  $
��Left=�6  $��773.667��6     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ نوع سند تضمین��6q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Type+   warrantyConverter �� 	Converter# [  6q     5      -   5        GauranteeNom��$# شماره ضمانتنامه��5   Z      FontSize$ 17Q�6s    6?   �� *Number+6s   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $&  ارزيابي رقم تضمین��6I    6.   �� *Status+6I   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ تاریخ ثبت��6-      CellTemplate 5      �� 5      .R�5   "   +   %Microsoft.Windows.Controls.DatePicker  $��5q�6�      SelectedDate 61   �� *RegisterDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5        5!      -   5        Bank��$ نام بانک��5!   T    67   �� *
BankName+6T     5$      -   5        	Price��$ مبلغ��5$   d      
FontFamily$ Tahoma)�6r   $ 12Q�6�    68   �� *Amount+ �� StringFormat$ N0��6�     5%      $ بارگذاري��6-    5&      �� 5'      .R�5(   "   �� -	   5        $��بارگذاري��5(   )   $��5q�6<   6H   5)      5+        5,      $ مشاهده��6-    5-      �� 5.      .R�5/   "   �� -
   5        $��مشاهده��5/   )   $��5q�6:   6F   50      52        53      $ حذف��6-    54      �� 55      .R�56   "   �� -   5        $��حذف��56   )   $��5q�67   6B   57      59      5;      �� 5<      -   5        $��label24��5<   �   $"��ثبت پاکات تضمین��6   $��RightToLeft=�6.   $��	B Nazanin)�6J   $��20(�6a   $��50��6o   $
��Left=�6{   $
��Left=�6�   $��
751,88,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��164��6   �� ContentStringFormat$ '��6!  �� 5=      -   5        $��label1_Copy1��5=   �   $%��انتخاب پیمانکار :��6   $��RightToLeft=�60   $��	B Nazanin)�6L   $��20(�6c   $��50��6q   $
��Left=�6}   $��Center=�6�   $��774,128,90,20q�6�   $	��Top=�6�   $��Center=�6�   $	��128��6!  �� 5>      -   5        $��SaveBtn��5>   �   $��ثبت��6   $��	B Nazanin)�6#   $��20(�6:   $��Normal"�6H   $��32��6\   $
��Left=�6h   $��
123,0,0,51q�6�   $��15��6�   $��Bottom=�6�   $	��116��6�   6�   �� 5?      -   5        $��	DeleteBtn��5?   �   $��حذف ضمانتنامه��6   $��	B Nazanin)�6-   $��20(�6D   $��Normal"�6R   $��33��6f   $
��Left=�6r   $��123,138,90,20q�6�   $��1��6�   $	��Top=�6�   $	��102��6�   6�   �� 5@      -   5        $��	ChooseCom��5@   �    �� DisplayMemberPath$ CompanyName��6   $��RightToLeft=�67   $��	B Nazanin)�6S   $��20(�6j   $��Normal"�6x   $��33��6�   $
��Left=�6�   $��246,138,90,20q�6�    �� SelectedIndex$ 0��6�    �� SelectedValuePath$ ContractorId��6�   $��0��6  $	��Top=�6  $��Center=�63  $	��532��6U  6a  � 5A      -   5        $��	WarranyDC��5A   3   $��123.333,340,113,88.898q�6    � DataContext 6D   ��  �� ElementName$ dataGrid�� �� Path$ SelectedItem�.+�5B      �� -   5          ��Name$  label49��5B   �   $��توضیحات :��6   $��RightToLeft=�6,   $��	B Nazanin)�6H   $��20(�6_   $��50��6m   $
��Left=�6y   $
��Left=�6�   $��690.667,146,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��80��6  �� 5C      -   5        ! ��Name$! DescriptionTxt��5C   �   $��RightToLeft=�6   $��	B Nazanin)�67   $��18(�6N   $��Normal"�6\   $��Right=�6p   $" �� HorizontalScrollBarVisibility$
" Auto=�6�   $��	0,186,0,0q�6�   # �� MaxLines$# 5��6�   $��14��6�   $ �� TextAlignment$
$ Left=�6  % �� TextWrapping$
% Wrap=�60   .  $	��Top=�6^  $��Stretch=�6v  "& �� VerticalScrollBarVisibility$
& Auto=�6�  $
��Left=�6�  $��768.348��6�  $��84.102��6�  ��6�   �� *Description+6�  �� 5D      -   5        $  l1��5D   �   $&�� * شماره سند تضمین :��6   $��RightToLeft=�66   $��	B Nazanin)�6R   $��20(�6i   $��50��6w   $
��Left=�6�   $
��Left=�6�   $��616.667,38,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��153��6  �� 5E      -   5        $! 	NumberTxt��5E     $��RightToLeft=�63   $��	B Nazanin)�6O   $��20(�6f   $��Normal"�6t   $��31��6�   $
��Left=�6�   $��Right=�6�   $
" Auto=�6�   $��489.556,49,0,0q�6�   $# 5��6  $��5��6/  $
$ Left=�6=  $
% Wrap=�6R   .  $	��Top=�6�  $��Center=�6�  $��131.913��6�  ��6   �� *Number+6�  �� 5F      -   5        $  l2��5F   �   $��* تاریخ ثبت :��6   $��RightToLeft=�60   $��	B Nazanin)�6L   $��20(�6c   $��50��6q   $
��Left=�6}   $
��Left=�6�   $��
389,38,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��98��6  �� 5G      -   5        $  l3��5G   �   $��* مبلغ تضمین :��6   $��RightToLeft=�61   $��	B Nazanin)�6M   $��20(�6d   $��50��6r   $
��Left=�6~   $
��Left=�6�   $��
130,38,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��117��6  �� 5H      -   5        $! PriceTxt��5H     $��RightToLeft=�63   $��Tahoma)�6O   $��13(�6c   $��Normal"�6q   $��31��6�   $
��Left=�6�   $��Right=�6�   $
" Auto=�6�   $��7,49,0,0q�6�   $# 5��6  $��7��6%  $
$ Left=�62  $
% Wrap=�6G   .  $	��Top=�6u  $��Center=�6�  $��131.636��6�  ��6   �� *Amount+ 6  �� $ {0:N0}���� 5I      -   5        $  label4��5I   �   $��تاریخ اعتبار :��6   $��RightToLeft=�61   $��	B Nazanin)�6M   $��20(�6d   $��50��6r   $
��Left=�6~   $
��Left=�6�   $��
397,78,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��89��6  �� 5J      -   5        $  l4��5J   �   $��* نام بانک :��6   $��RightToLeft=�6/   $��	B Nazanin)�6K   $��20(�6b   $��50��6p   $
��Left=�6|   $
��Left=�6�   $��680.667,77,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��89��6  �� 5K      -   5        $! BankName��5K     $��RightToLeft=�65   $��	B Nazanin)�6Q   $��20(�6h   $��Normal"�6v   $��31��6�   $
��Left=�6�   $��Right=�6�   $
" Auto=�6�   $��
491,87,0,0q�6�   $# 5��6  $��8��6,  $
$ Left=�6:  $
% Wrap=�6O   .  $	��Top=�6}  $��Center=�6�  $��131.636��6�  ��6   �� *
BankName+6�  �� 5L      -   5        $  label6��5L   �   $��نام شعبه :��6   $��RightToLeft=�6-   $��	B Nazanin)�6I   $��20(�6`   $��50��6n   $
��Left=�6z   $
��Left=�6�   $��
169,77,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��77��6  �� 5M      -   5        $! 	BranchTxt��5M     $��RightToLeft=�67   $��	B Nazanin)�6S   $��20(�6j   $��Normal"�6x   $��31��6�   $
��Left=�6�   $��Right=�6�   $
" Auto=�6�   $��7,87,0,0q�6�   $# 5��6  $��10��6-  $
$ Left=�6;  $
% Wrap=�6P   .  $	��Top=�6~  $��Center=�6�  $��131.636��6�  ��6   �� *
BankBranch+6�  �� 5N      -   5        $  label7��5N   �   $��نام شهر :��6   $��RightToLeft=�6,   $��	B Nazanin)�6H   $��20(�6_   $��50��6m   $
��Left=�6y   $
��Left=�6�   $��678.667,115,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��89��6  �� 5O      -   5        $! CityTxt��5O     $��RightToLeft=�6   $��	B Nazanin)�66   $��20(�6M   $��Normal"�6[   $��31��6o   $��Right=�6{   $��Right=�6�   $
" Auto=�6�   $��0,125,151.031,0q�6�   $# 5��6�   $��12��6  $
$ Left=�6>  $
% Wrap=�6S   .  $	��Top=�6�  $��Center=�6�  $��131.636��6�  ��6$  �� *
BankCity+6�  �� 5P      -    5        $  label8��5P   �   $��عنوان :��6   $��RightToLeft=�6*   $��	B Nazanin)�6F   $��20(�6]   $��50��6k   $
��Left=�6w   $
��Left=�6�   $��410,115,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��77��6  �� 5Q      -!   5        $! TitleTxt��5Q   �   $��RightToLeft=�6   $��	B Nazanin)�66   $��20(�6M   $��Normal"�6[   $��31��6o   $
��Left=�6{   $��Right=�6�   $
" Auto=�6�   $��	7,125,0,0q�6�   $# 5��6�   $��13��6  $
$ Left=�6:  $
% Wrap=�6O   .  $	��Top=�6}  $��Center=�6�  $	��384��6�  ��6  �� *
StockTitle+6�    5R      -"   5        '  Name$' RegDate��5R   �   $��RightToLeft=�6l   $��31��6�   $
��Left=�6�   $��
255,49,0,0q�6�   (   Text$( انتخاب تاريخ��6�   $	��Top=�6�   $	��132��6   $��6��6   6    �� *RegisterDate+$ PropertyChanged=�6    5S      -#   5        $' 	ValidDate��5S   �   $��RightToLeft=�6k   $��31��6�   $
��Left=�6�   $��
255,87,0,0q�6�   $( انتخاب تاريخ��6�   $	��Top=�6�   $��131.636��6  $��9��6   6    �� *ValidityDate+$ PropertyChanged=�6  �� 5T      -$   5        $  l5��5T   �   $��* نوع سند :��6   $��RightToLeft=�6.   $��	B Nazanin)�6J   $��20(�6a   $��50��6o   $
��Left=�6{   $��Center=�6�   $��683.667,0,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��90��6  �� 5U      -%   5        ) ��Name$) DocType��5U   �   $ Title��6   $ ID��65   $��RightToLeft=�6m   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $��33��6�   $��
0,10,151,0q�6�   $ 0��6�   $��3��6  $	��Top=�6  $��Center=�6+  $��Right=�6M  $	��132��6i  * �� SelectedValue* 6L   �� *Type+5W      �� 5X      -&   5        $  label10��5X   �   $*��$* ارزیابی رقم تضمین :��6   $��RightToLeft=�68   $��	B Nazanin)�6T   $��20(�6k   $��50��6y   $
��Left=�6�   $��Center=�6�   $��	330,0,0,0q�6�   $	��Top=�6�   $��Center=�6   $	��162��6"  �� 5Y      -'   5        + ��Name$+ 	checkBox1��5Y   t   $��16��69   $
��Left=�6E   $��
303,19,0,0q�6`   $	��Top=�6�   $��15��6�   $��4��6�   , d� 	IsChecked, 6   �� *Status+6�   5Z      �� 5[      -(   5        $��SesionRecordAddBtn��5[   �   $'��!بارگذاری صورتجلسه��6   $��	B Nazanin)�61   $��20(�6H   $��Normal"�6V   $��32��6j   $
��Left=�6v   $��
606,0,0,51q�6�   $��17��6�   $��Bottom=�6�   $	��140��6�   6�   �� 5\      -)   5        $��PrintBtn��5\   �   $!��پرینت صورتجلسه��6   $��	B Nazanin)�6.   $��20(�6E   $��Normal"�6S   $��32��6g   $
��Left=�6s   $��751,616,90,20q�6�   $��16��6�   $	��Top=�6�   $	��140��6�   6�   �� 5]      -*   5        $��OpenFileBtn��5]   �   $#��مشاهده صورتجلسه��6   $��	B Nazanin)�6/   $��20(�6F   $��Normal"�6T   $��32��6h   $
��Left=�6t   $��
461,0,0,51q�6�   $��18��6�   $��Bottom=�6�   $	��140��6�   6�   �� 5^      -+   5        $��DelBtn��5^   �   $��حذف صورتجلسه��6   $��	B Nazanin)�6,   $��20(�6C   $��Normal"�6Q   $��32��6e   $��Right=�6q   $��
0,0,554,51q�6�   $��19��6�   $��Bottom=�6�   $	��140��6�   6�   5_      5`      5a      