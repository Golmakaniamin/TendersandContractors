   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RTMRTM  5      &     RTM.Tenderingg.Web_DocContractor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5       myclr-namespace:RTM     5        N� Title$  Web_DocContractor��6   .��5	      � $	��768��6!   $
��1024��6.   ��6   Z� .+�5
   
   �� -   5        $��Border��5
   �   ���	#FFA0A0A0$��1q�6?    �� CornerRadius$ 0��6S   $	��667��6d   $
��Left=�6q   $��	24,54,0,0q�6�    J� Opacity$	 0.4Q�6�   $	��Top=�6�   $	��976��6�   ��6(   Z� ._�5      �� -   5        $��label2��5      $��0��6   $��0��6-   $
��Left=�67   $	��Top=�6R   5      �� 5   
   -   5        $��Title��5     $L��Fلیست دریافت اسناد از سامانه خود اظهاری��6   $%��/RTM;component/Fonts/#B Nazanin)�6A   $��23(�6n   $��Normal"�6|   
���   �$��51��6�   $
��Left=�6�   $��Center=�6�   $��
682,55,0,0q�6�      
TitleLabel#��[  6  $	��Top=�63  $��Center=�6K  �� 5   
   -   5        $��	SearchBtn��5   �   $��
جستجو��6)   $��	B Nazanin)�69   $��20(�6P   $��Normal"�6^   $��40��6r   $��569,114,0,0q�6~   $��1��6�   $	��Top=�6�   $
��Left=�6�   $	��110��6�   �� 5   
   -   5        $��TenderNumberTxt��5      $��RightToLeft=�6   $��Arial)�6.   $��20(�6A   $��Normal"�6O   $��39.974��6c   $
��Left=�6s   $��Right=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��684.617,114.143,0,0q�6�    �� MaxLines$ 5��6�   $��0��6   �� TextAlignment$
 Left=�6j   �� TextWrapping$
 Wrap=�6   � UseLayoutRounding .  $	��Top=�6�  $��Center=�6�  $	��188��6�  ��6$  ��  �� ElementName$
 page��	 �� Path$#	 CurrentTender.TenderingNumber�6�  �� 5   
   -   5        $��label9��5   �   $��شماره مناقصه :��6   $��RightToLeft=�6)   $��	B Nazanin)�6E   $��20(�6\   $��50��6j   $
��Left=�6v   $��Center=�6�   $��858,110,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��150��6  &   System.Windows.Controls.DataGrid  5   
   -   5        $��	DataGrid1��5   b  
   AutoGenerateColumns
 .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $	��302��6  $��Center=�6     
IsReadOnly . $��38,368.667,0,0q�6J     SelectionMode$ Single=�6s  $��2��6�   .  $	��Top=�6�  $��Center=�6�  $
��Left=�6�  $��948.383��6     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Cntrctr��,  &System.Windows.Controls.DataGridColumn   Header$ نام شرکت��5   �      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *contractorId+  companyNameConverter �� 	Converter# [ 6�     5      -	   5        	SocialNom��$  شناسه ملی شرکت��5   �    .  68   �� *contractorId+  companySNConverter# [ 6�     5       . $3 -آخرین تاریخ دانلود اسناد��67    6Y   �� $
	 date�  dateConverter# [ 5      �� 5   
   -
   5        $��PrintBtn��5   z   $��چاپ��6   $��	B Nazanin)�6    $��20(�67   $��Normal"�6E   $��40��6Y   $��189,670,0,0q�6e   $��3��6�   $	��Top=�6�   $
��Left=�6�   $	��114��6�   $y�Hidden=�6�       RTM.TenderingHeaderControl  5   
   -   5          Name$ Header��5   S   $
��Left=�6$   $��
38,163,0,0q�6?   $	��Top=�6c   $	��948��6{   �� 5   
   -   5        $��Print��5   �   $��چاپ گزارش��6   $��	B Nazanin)�6%   $��20(�6<   $��Normal"�6J   $��40��6^   $
��Left=�6j   $��
38,675,0,0q�6�   $��1��6�   $	��Top=�6�   $	��110��6�   6�   5      5      