   M S B A M L   `   `   `  ����I  EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null[<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkitMicrosoft.Windows.Controls  5       RTM&    RTM.Tenderingg.Evaluation2Search   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Kdp<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit     5        N� Title$  Evaluation2Search��5	      $	��768��62   $
��1024��6?    N� 
Background 6   Z� .��5      � $
��1024��6   $	��768��6   ��6%   Z� .+�5   
   �� -   5        $��Border��5   �   
�������$��1q�6;    �� CornerRadius$ 0��6O   $	��600��6`   $��Right=�6m   $��
0,0,140,81q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��743��6�   ��6$   Z� ._�5      �� -   5        $��label2��5      $��0��6   $��0��6-   5      �� 5   
   -   5        $��Title��5      $C��=جستجوی جلسات کمیته فنی و بازرگانی��6   $%��/RTM;component/Fonts/#B Nazanin)�6<   $��23(�6i   $��Normal"�6w   
���   �$��51��6�   $��Right=�6�   $��Center=�6�   $��0,80,140,637q�6�      
TitleLabel#��[  6  $��Stretch=�61  $��Center=�6M  �� 5   
   -   5        $��OpenBtn��5   8   $��مشاهده��6   $��0,644,493,92q�6"   $��9��6G   $	��120��6T   $��Right=�6v   �� 5   
   -   5        $��	SearchBtn��5   T   $��
جستجو��6   $��Right=�6!   $��0,255,616,481q�6=   $��6��6e   $	��120��6r   6~   &   System.Windows.Controls.DataGrid  5   
   -   5        $
��Grid��5   ~     AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .    CanUserReorderColumns .     CanUserResizeRows .  	   CanUserSortColumns	 .  $��RightToLeft=�6�   $%��/RTM;component/Fonts/#B Nazanin)�6�   $��20(�6�   $��Normal"�6	  $	��345��6  $
��Left=�6*  $��Center=�6E  $��163,293,0,0q�6i  
   SelectionMode$
 Single=�6�  $��8��6�  $	��Top=�6�  $��Center=�6�  $	��701��6�     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ عنوان جلسه��6&   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$ Title�  5      $  شماره مناقصه��6&    6=   �� $ TenderingNumber�  5      $   شماره فراخوان��6&    6>   �� $ NoticeNumber�4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $  وضعيت ثبت��6*    6>   �� $ PermanentRecord�5      +   %Microsoft.Windows.Controls.DatePicker  5   
   -   5        $��
datepicker��5   M   $��588,141,263,599q�6   $��RightToLeft=�61   $��0��6_   �� 5   
   -   5        $��	NumberTxt��5     $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6.   $��20(�6[   $��Normal"�6i   $��32��6}   $
��Left=�6�   $��Right=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��587.667,177.667,0,0q�6�    �� MaxLines$ 5��6	  $��2��6'  $�� ��64   �� TextAlignment$
 Left=�6<   � UseLayoutRounding .  $	��Top=�6k  $��Center=�6�  $��173.105��6�  �� 5   
   -	   5        $��label1��5   �   $��شماره مناقصه :��6   $��RightToLeft=�6)   $%��/RTM;component/Fonts/#B Nazanin)�6E   $��20(�6r   $��40��6�   $��Right=�6�   $
��Left=�6�   $��0,173,160,0q�6�   $	��Top=�6�   $��Center=�6  $	��100��6'  �� 5   
   -
   5        $��TitleTxt��5     $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6.   $��20(�6[   $��Normal"�6i   $��32��6}   $
��Left=�6�   $��Right=�6�   $
 Auto=�6�   $��162.667,216.667,0,0q�6�   $ 5��6	  $��4��6&  $�� ��63  $
 Left=�6;   .  $	��Top=�6j  $��Center=�6�  $	��598��6�  �� 5   
   -   5        $��label3��5   �   $��عنوان :��6   $��RightToLeft=�6"   $%��/RTM;component/Fonts/#B Nazanin)�6>   $��20(�6k   $��40��6y   $
��Left=�6�   $��807,211,160,0q�6�   $	��Top=�6�   $��Center=�6�   �� 5   
   -   5        $��
RefreshBtn��5   <   $��تازه سازی��6   $��162,255,0,481q�6%   $��7��6N   $	��120��6[   $
��Left=�6�   �� 5    
   -   5        $��EditBtn��5    S   $��ویرایش��6   $
��Left=�6"   $��285,644,0,92q�6=   $��10��6b   $	��120��6p   6|   �� 5!   
   -   5        $��label4��5!   �   $��از تاریخ :��6   $��RightToLeft=�6%   $%��/RTM;component/Fonts/#B Nazanin)�6A   $��20(�6n   $��40��6|   $
��Left=�6�   $��794,133,160,0q�6�   $	��Top=�6�   $��Center=�6�     5"   
   -   5        $��datePicker1��5"   M   $��RightToLeft=�6   $��301,141,550,599q�64   $��1��6`   �� 5#   
   -   5        $��label5��5#   �   $��تا تاریخ :��6   $��RightToLeft=�6%   $%��/RTM;component/Fonts/#B Nazanin)�6A   $��20(�6n   $��40��6|   $
��Left=�6�   $��519,133,443,0q�6�   $	��Top=�6�   $��Center=�6�   �� 5$   
   -   5        $��	NoticeNum��5$     $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6.   $��20(�6[   $��Normal"�6i   $��32��6}   $
��Left=�6�   $��Right=�6�   $
 Auto=�6�   $��300.667,177.667,0,0q�6�   $ 5��6	  $��3��6'  $�� ��64  $
 Left=�6<   .  $	��Top=�6k  $��Center=�6�  $	��175��6�  �� 5%   
   -   5        $��label6��5%   �   $!��شماره فراخوان :��6   $��RightToLeft=�6*   $%��/RTM;component/Fonts/#B Nazanin)�6F   $��20(�6s   $��40��6�   $��Right=�6�   $
��Left=�6�   $��0,173,439,0q�6�   $	��Top=�6�   $��Center=�6  $	��110��6(  �� 5&   
   -   5        $��PrintBtn��5&   V   $��چاپ گزارش��6   $
��Left=�6%   $��161,644,0,93q�6@   $��11��6f   $	��119��6t   6�   �� 5'   
   -   5        $��label7��5'   �   $��نوع جلسه :��6   $��RightToLeft=�6%   $%��/RTM;component/Fonts/#B Nazanin)�6A   $��20(�6n   $��40��6|   $
��Left=�6�   $��782,247,160,0q�6�   $	��Top=�6�   $��Center=�6�   �� 5(   
   -   5        $��TypeCom��5(   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6/   $��20(�6\   $��Normal"�6j   $��32��6~   $
��Left=�6�   {�.  �� 
IsReadOnly .  $��588,255,0,0q�6�    �� SelectedIndex$ -1��6�   $��5��6   $	��Top=�6  $��Center=�6%  $	��172��6G  ��6S  �� .@�5)      �� $��ارزیابی کیفی��6   �� 5*      $��ارزیابی قیمت��6   5+      5,      5-      