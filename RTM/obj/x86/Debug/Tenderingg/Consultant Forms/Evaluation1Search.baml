   M S B A M L   `   `   `  ����I  EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null[<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkitMicrosoft.Windows.Controls  5       RTM&    RTM.Tenderingg.Evaluation1Search   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Kdp<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit     5      -   5          N� Title$  Evaluation1Search��5	      $	��768��62   $
��1024��6?    N� 
Background 6   Z� .��5      � $	��768��6!   $
��1024��6.   ��6   Z� .+�5   
   �� -   5        $��Border��5   �   
�������$��1q�6;    �� CornerRadius$ 0��6O   $	��346��6`   $��Right=�6m   $��0,0,224,238q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��588��6�   ��6$   Z� ._�5      �� -   5        $��label2��5      $��0��6   $��0��6-   5      +   %Microsoft.Windows.Controls.DatePicker  5   
   -   5        $��
datepicker��5   M   $��539,236,312,504q�6   $��RightToLeft=�61   $��0��6_   �� 5   
   -   5        $��Title��5   �   $5��/جستجوی جلسه ارزیابی مشاور��6   $%��/RTM;component/Fonts/#B Nazanin)�64   $��23(�6a   $��Normal"�6o   
���   �$��51��6�   $��Right=�6�   $��Center=�6�   $��0,182,230,534q�6�      
TitleLabel#��[  6  $��Stretch=�6*  $��Center=�6F  �� 5   
   -   5        $��OpenBtn��5   ;   $��مشاهده��6   $��514,490,390,246q�6"   $��5��6J   $	��120��6W   6c   �� 5   
   -   5        $��	SearchBtn��5   T   $��
جستجو��6   $��Right=�6!   $��0,490,265,246q�6=   $��3��6e   $	��120��6r   6~   &   System.Windows.Controls.DataGrid  5   
   -   5        $
��Grid��5   �     
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .     CanUserDeleteRows .     CanUserReorderColumns .  	   CanUserResizeRows	 .  
   CanUserSortColumns
 .  $��RightToLeft=�6�   $%��/RTM;component/Fonts/#B Nazanin)�6�   $��20(�6  $��Normal"�6  $	��178��61  $
��Left=�6>  $��Center=�6Y  $��233,306,0,0q�6}     SelectionMode$ Single=�6�  $��4��6�  $	��Top=�6�  $��Center=�6�  $	��544��6�     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ عنوان جلسه��6&   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$ Title�4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $  وضعيت ثبت��6*    6>   �� $ PermanentRecord�5      �� 5   
   -	   5        $��label32��5   �   $��از تاریخ :��6   $��RightToLeft=�6%   $%��/RTM;component/Fonts/#B Nazanin)�6A   $��20(�6n   $��40��6|   $
��Left=�6�   $��707,228,247,0q�6�   $	��Top=�6�   $��Center=�6�   �� 5   
   -
   5        $��TitleTxt��5   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6.   $��20(�6[   $��Normal"�6i   $��32��6}   $��Right=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��233,267.5,301,0q�6�    �� MaxLines$ 5��6�   $��2��6  $�� ��6   �� TextAlignment$
 Left=�6   � UseLayoutRounding .  $	��Top=�6K  $��Center=�6c  �� 5   
   -   5        $��label3��5   �   $��عنوان :��6   $��RightToLeft=�6"   $%��/RTM;component/Fonts/#B Nazanin)�6>   $��20(�6k   $��40��6y   $
��Left=�6�   $��729,262,247,0q�6�   $	��Top=�6�   $��Center=�6�   �� 5   
   -   5        $��
RefreshBtn��5   >   $��تازه سازی��6   $��262,490,642,246q�6%   $��6��6P   $	��120��6]   6i   �� 5   
   -   5        $��EditBtn��5   U   $��ویرایش��6   $��Right=�6"   $��0,490,516,246q�6>   $��8��6d   $	��120��6q   6}     5   
   -   5        $��datePicker1��5   M   $��RightToLeft=�6   $��234,236,617,504q�64   $��1��6`   �� 5    
   -   5        $��label1��5    �   $��تا تاریخ :��6   $��RightToLeft=�6%   $%��/RTM;component/Fonts/#B Nazanin)�6A   $��20(�6n   $��40��6|   $
��Left=�6�   $��408,228,554,0q�6�   $	��Top=�6�   $��Center=�6�   5!      5"      