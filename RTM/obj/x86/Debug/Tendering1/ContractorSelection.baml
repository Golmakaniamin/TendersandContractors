   M S B A M L   `   `   `  ����  RTM(    "RTM.Tendering1.ContractorSelection   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          N� Title$  ContractorSelection��5      .��5
      � $	��768��6   $
��1024��6   .+�5   
   �� -   5        $��border1��5   �   
�������$��1q�6;    �� CornerRadius$ 0��6O   $	��527��6`   $
��Left=�6m   $��123,142,0,0q�6�    J� Opacity$	 0.4Q�6�   $	��Top=�6�   $	��770��6�   ��6$   Z� ._�5      �� -   5        $��label17��5      $��0��6   $��0��6.   $	��Top=�68   $
��Left=�6P   5      �� 5   
   -   5        $��label3��5   �   $ ��انتخاب شرکت ها��6   $��RightToLeft=�6)   $��	B Nazanin)�6E   $��20(�6\   $��41��6j   $
��Left=�6v   $
��Left=�6�   $��765,143,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��116��6  &   System.Windows.Controls.DataGrid  5   
   -   5        $��	DataGrid1��5   t   �� AlternationCount$ 2��6      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .    CanUserReorderColumns .     CanUserResizeRows .  	   CanUserSortColumns	 .  $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6  $	��178��6  $��Center=�6)  
   
IsReadOnly
 . $��143,208,0,0q�6_     SelectionMode$ Single=�6�  $��3��6�  $	��Top=�6�  $��Center=�6�  $
��Left=�6�  $	��458��6�     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  نام شرکت��6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ CompanyName�6J     5      $ نام مديرعامل��6H    6%   �� $ 	CeoFamily�6H     5      $ شناسه ملي��6O    6%   �� $ NationalIdNumber�6O   5      �� 5   
   -   5        $��searchContractor��5   ]   $��
جستجو��6   $��32��6!   $
��Left=�6-   $��704,280,0,0q�6H   $��2��6u   $	��Top=�6�   $��90��6�   6�   �� 5   
   -   5        $��AddBtn��5   :   $��
اضافه��6   $��609,280,325,456q�6!   $��4��6H   $��90��6U   $	��Top=�6`   $
��Left=�6x   6�   �� 5   
   -   5        $��DelBtn��5   4   $��حذف��6   $��609,418,0,0q�6   $��6��6B   $	��Top=�6O   $
��Left=�6g   $��90��6�   6�     5   
   -	   5        $��	DataGrid2��5   _   .   .   .  .   .  	 .  $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $	��178��6  $��Center=�6  
 . $��143,418,0,0q�6J  $ Single=�6p  $��5��6�  $	��Top=�6�  $��Center=�6�  $
��Left=�6�  $	��458��6�   5        5      $  نام شرکت��6J    6%   �� $ CompanyName�6J     5      $ نام مديرعامل��6H    6%   �� $ 	CeoFamily�6H     5      $ شناسه ملي��6O    6%   �� $ NationalIdNumber�6O   5      �� 5    
   -
   5        $��label19��5    �   $��نتایج جستجو :��6   $��RightToLeft=�6(   $��	B Nazanin)�6D   $��20(�6[   $��41��6i   $
��Left=�6u   $
��Left=�6�   $��499,169,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��102��6  �� 5!   
   -   5        $��SocialNumberTxt��5!   �   $��RightToLeft=�6   $��	B Nazanin)�6.   $��20(�6E   $��Normal"�6S   $��32��6g   $
��Left=�6s   $��Right=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��609.333,244,0,0q�6�    �� MaxLines$ 5��6�   $��1��6  $�� ��6    �� TextAlignment$
 Left=�6(   � UseLayoutRounding .  $	��Top=�6W  $��Center=�6o  $��185.111��6�  �� 5"   
   -   5        $��CompanyNameTxt��5"   �   $��RightToLeft=�6   $��	B Nazanin)�6.   $��20(�6E   $��Normal"�6S   $��32��6g   $
��Left=�6s   $��Right=�6�   $
 Auto=�6�   $��609.333,208,0,0q�6�   $ 5��6�   $��0��6  $�� ��6  $
 Left=�6'   .  $	��Top=�6V  $��Center=�6n  $��185.111��6�  �� 5#   
   -   5        $��label13��5#   �   $��شناسه ملی :��6   $��RightToLeft=�6&   $��	B Nazanin)�6B   $��20(�6Y   $��41��6g   $
��Left=�6s   $
��Left=�6�   $��790,239,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��91��6  �� 5$   
   -   5        $��label14��5$   �   $��نام شرکت :��6   $��RightToLeft=�6%   $��	B Nazanin)�6A   $��20(�6X   $��41��6f   $
��Left=�6r   $
��Left=�6�   $��801,205,0,0q�6�   $	��Top=�6�   $��Center=�6�   $��80��6  �� 5%   
   -   5        $��l5��5%   �   $��لیست منتخب :��6   $��RightToLeft=�6'   $��	B Nazanin)�6C   $��20(�6Z   $��41��6h   $
��Left=�6t   $
��Left=�6�   $��499,382,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��102��6
  �� 5&   
   -   5        $��button1��5&   O   $��ثبت��6   $
��Left=�6   $��143,623,0,0q�6:   $��7��6^   $	��Top=�6k   $��90��6�   6�   5'      5(      