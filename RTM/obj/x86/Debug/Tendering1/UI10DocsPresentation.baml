   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RTMRTM  5   �   )    #RTM.Tendering1.UI10DocsPresentation   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6my-http://schemas.microsoft.com/wpf/2008/toolkit  5   K   my1clr-namespace:RTM  6�   -   5        $
��page��5   ?     N� Title$  UI10DocsPresentation��6   $
��1024��6   $	��768��6/   .��5	      � -   5         �Name$ 
layoutRoot��5	   +   $	��768��6   $
��1024��6   .+�5
   
   � $	��768��6   $
��1024��6   .+�5      �� -   5         ��Name$ border2_Copy��5   �    J� 	AllowDrop . 
����������	#FF9A9696$��1q�6Q    �� CornerRadius$ 0��6e   $��Right=�6v   $��
0,72,15,60q�6�    J� Opacity$	 0.4Q�6�   $	��990��6�   ._�5      �� -   5         ��Name$ label2��5   #   $��0��6   $��0��63   5      �� 5      $��19,72,15,68q�6   .��5      �  � RowDefinitions 5      �� 5      $��9* �6(   �� 5      $
��784* �6(   .+�5      �� -   5        $ label1��5   �   $��ارائه اسناد��6   $��RightToLeft=�62   $��	B Nazanin)�6N   $��20(�6e   $��Right=�6s   $
��Left=�6�   $��0,8,18,0q�6�   $��Center=�6�   $��72��6�   $	��Top=�6   �� 5      -   5        $ border1_Copy��5   �    . 
�������$��1q�6X   $ 0��6l   $
��Left=�6}   $��	8,264,0,0q�6�   $	 0.4Q�6�   $	��950��6�   $	��Top=�6�   $	��464��6�   $��2��6   ��6A   Z� 6   �� 5      -   5        $ label6_Copy��5   �   $��پیمانکاران :��6   $��RightToLeft=�63   $��	B Nazanin)�6O   $��20(�6f   $��Right=�6t   $
��Left=�6�   $��
0,264,31,0q�6�   $��Center=�6�   $��79��6�   $	��Top=�6  �� 5      -   5        $ label9_Copy��5   �   $��شناسه ملی :��6   $��RightToLeft=�62   $��	B Nazanin)�6N   $��20(�6e   $
��Left=�6s   $
��Left=�6�   $��838,335,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��95��6  �� 5      -	   5        $ label10_Copy��5   �   $��نام پیمانکار :��6   $��RightToLeft=�65   $��	B Nazanin)�6Q   $��20(�6h   $
��Left=�6v   $
��Left=�6�   $��838,297,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��95��6  �� 5      -
   5         ��Name$ CompanyNameTxt��5     $��RightToLeft=�6   $��	B Nazanin)�6:   $��20(�6Q   $��Normal"�6_   $��Right=�6s   $��Right=�6�   $	 �� HorizontalScrollBarVisibility$
	 Auto=�6�   
 �� 
IsReadOnly
 .  $��0,299.336,138.332,0q�6�    �� MaxLines$ 5��6  $��0��6,  $�� ��69   �� TextAlignment$
 Left=�6A   �� TextWrapping$
 Wrap=�6V   � UseLayoutRounding .  $	��Top=�6�  $��Center=�6�  " �� VerticalScrollBarVisibility$ Hidden=�6�  $��139.5��6�  �� 5      -   5        $ SocialNumberTxt��5     $��RightToLeft=�6   $��	B Nazanin)�6:   $��20(�6Q   $��Normal"�6_   $��Right=�6s   $��Right=�6�   $
	 Auto=�6�   
 .  $��0,337.336,138.332,0q�6�   $ 5��6  $��1��6-  $�� ��6:  $
 Left=�6B  $
 Wrap=�6W   .  $	��Top=�6�  $��Center=�6�  $ Hidden=�6�  $��139.5��6�  �� 5      -   5         ��Name$ AddCntrctrBtn��5   �   $��
اضافه��6   $��	B Nazanin)�6-   $��17(�6D   $��Normal"�6R   $��Right=�6f   $��0,381,173,0q�6�   $��3��6�   $	��104��6�   $��34.201��6�   $	��Top=�6�   6�   �� 5      -   5        $ CntrctrSearchBtn��5   �   $��
جستجو��6   $��	B Nazanin)�6-   $��17(�6D   $��Normal"�6R   $��Right=�6f   $��
0,381,63,0q�6�   $��2��6�   $	��104��6�   $��34.201��6�   $	��Top=�6�   6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 	dataGrid3��5   O     AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $��Center=�6  $��26,299.447,0,0q�67     SelectionMode$ Single=�6b  $��5��6y   .  $��Center=�6�     
IsReadOnly . $��172.106��6�  $	��Top=�6  $
��Left=�6%  $	��662��6@     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  نام شرکت��62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   ��  �� Path$ CompanyName�  5       $ نام مديرعامل��62    6H   �� $ 	CeoFamily�  5!      $ شناسه ملي��62    6E   �� $ NationalIdNumber�5#      �� 5$      -   5        $ label13_Copy��5$   �   $��نتایج جستجو :��6   $��RightToLeft=�64   $��	B Nazanin)�6P   $��20(�6g   $
��Left=�6u   $
��Left=�6�   $��581,264,0,0q�6�   $��Center=�6�   $	��134��6�   $	��Top=�6  �� 5%      -   5        $ SaveBtn��5%   �   $��ثبت��63   $��	B Nazanin)�6A   $��20(�6X   $��Normal"�6f   $��32��6z   $
��Left=�6�   $��27,7,0,0q�6�   $��8��6�   $	��Top=�6�   $	��109��6�   $��1��6�   �� 5&      -   5        $ DeleteCntrctrBtn��5&   �   $��حذف��6<   $��	B Nazanin)�6J   $��20(�6a   $��Normal"�6o   $��32��6�   $��Right=�6�   $��0,7,40,0q�6�   $��7��6�   $	��Top=�6�   $��86��6�   $��1��6    5'      -   5        $ 	dataGrid4��5'   K   .   .   .   .   .   . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $��Center=�6  $��
26,477,0,0q�67  $ Single=�6^  $��6��6u   .  $��Center=�6�  $	��Top=�6�  $��193.327��6�   .  $
��Left=�6"  $	��907��6=  $   HorizontalScrollBarVisibility$ Visible=�6I   5(        5)      $ نام شرکت��6�      
IsReadOnly .  62   �� *ContractorId+   companyNameConverter  �� 	Converter#  [  6�     5*      $ شناسه ملي��6�    .  62   �� *ContractorId+  companySNConverter#  [ 6�     5+      $, &نام نماينده پیمانکار��6c    62   �� *ContractorRepresentativeName+6c     5,      -   5        DraftNumberColumn��$ شماره فیش��5,   u    6N   �� *PaymentDraftNumber+6u     5-      -   5        BankNameColumn��$ نام بانک��5-   g    6J   �� *
BankName+6g     5.      -   5        DraftAmountColumn��$ مبلغ فیش��5.   ~   !   
FontFamily$! Tahoma)�6�    6M   �� *DraftAmount+" �� StringFormat$" N0��6�   4  .System.Windows.Controls.DataGridTemplateColumn  5/      $ بارگذاري��65   #   CellTemplate# 50   "   �� 51   &   .R�52   *   �� -   5        $��بارگذاري��52   1   $��5q�6D   6P   53   '   55        56      $ مشاهده��65   # 57   "   �� 58   &   .R�59   *   �� -   5        $��مشاهده��59   1   $��5q�6B   6N   5:   '   5<        5=      $ حذف��65   # 5>   "   �� 5?   &   .R�5@   *   �� -   5        $��حذف��5@   1   $��5q�6?   6J   5A   '   5C      5E      �� 5F      -   5        $ RefreshCntrctrBtn��5F   �   $��تازه سازی��6   $��	B Nazanin)�61   $��17(�6H   $��Normal"�6V   $��Right=�6j   $��0,421,116,0q�6�   $��4��6�   $	��104��6�   $��34.201��6�   $	��Top=�6�   6�       RTM.TenderingHeaderControl  5G      -   5        $  Name$$ Header��5G   ^   $
��Left=�61   $��8,56,0,0q�6L   $	��Top=�6n   5H      5I      5J      5K      5L      