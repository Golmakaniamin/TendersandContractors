   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RTM.ClassesRTM.Classes  5           RTM.Tenderingg.Evaluation2   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:RTM.Classes     5      -   5          N� Title$  Evaluation2��5
      $	��768��6   $
��1024��6#    N� 
Background 60   Z�  � 	Resources 5      )  #RTM.Classes.DoubleToStringConverter   doubleConverter��%   &	          5   
   6(   5      .��5      � -   5        $��
layoutRoot��5   ;   $	��768��6   $
��1024��6   ��6%   Z� .+�5   
   �� -   5        $��Border��5   �   
�������$��1q�6;    �� CornerRadius$ 0��6O   $	��557��6`   $��Right=�6m   $��
0,0,100,89q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��832��6�   ��6$   Z� ._�5      �� -   5        $��label2��5      $��0��6   $��0��6-   5      �� 5   
   -   5        $��Title��5   �   $&�� جلسه ارزیابی کیفی��6   $��	B Nazanin)�6,   $��23(�6C   $��Normal"�6Q   
���   �$��51��6x   $��Right=�6�   $��Center=�6�   $��0,119,124,598q�6�     
TitleLabel#��[ 6�   $��Stretch=�6  $��Center=�6(  �� 5   
   -   5        $��EditBtn��5   8   $��ثبت��6   $��230,634,674,102q�6   $��3��6G   $	��120��6T   6`   �� 5   
   -   5        $��
ConfirmBtn��5   <   $��ثبت نهایی��6   $��0,634,800,102q�6%   $��8��6N   $	��120��6[   $��Right=�6g   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $
��Grid��5   x     AutoGenerateColumns .     CanUserSortColumns .    CanUserAddRows .     
IsReadOnly . 	   CanUserDeleteRows	 . 
   CanUserReorderColumns
 .     CanUserResizeRows .  $��RightToLeft=�6�   $��Arial)�6�   $��18(�6�   $��Normal"�6  $	��178��6  $
��Left=�6$  $��Center=�6?  $��104,322,0,0q�6c     SelectionMode$ Single=�6�  $��0��6�  $	��Top=�6�  $��Center=�6�  $	��634��6�     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  نام شرکت��6&   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ contractor.CompanyName�  5      $ نام مديرعامل��6&    6<   �� $ contractor.CeoFamily�  5      $ شناسه ملي��6&    69   �� $! contractor.NationalIdNumber�  5      $ جمع امتياز��6&    6:   �� $ 
totalScore� �� 	Converter# [  5        5   
   -	   5        $��	dataGrid1��5   _   .   .  
 .   .   . $��RightToLeft=�6�   $��Arial)�6�   $��18(�6�   $��Normal"�6�   $	��178��6�   $
��Left=�6�   $��Center=�6  {�. $��106,135,0,0q�6J  $ Single=�6p  $��1��6�  $	��Top=�6�  $��Center=�6�  $	��633��6�   5        5         
IsReadOnly . $  اسم معيار��68      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6k    6L   �� $ Title�6k     5       $ وزن��6&    64   �� $ Weight� �� Mode$ TwoWay=�  5!      $ امتياز��6&    66   �� $ Score�$ TwoWay=�5#      �� 5$   
   -
   5        $��button2��5$   A   $��چاپ صورتجلسه��6   $��776,634,114,102q�6(   $��4��6P   6]   �� 5%   
   -   5        $��AddFile��5%   D   $��Right=�6   $��0,635,254,101q�6-   $��5��6S   $	��135��6`   $'��!بارگذاری صورتجلسه��6l   6�   �� 5&   
   -   5        $��OpenFileBtn��5&   \   $#��مشاهده صورتجلسه��6   $��Right=�6+   $��0,0,394,101q�6G   $��6��6o   $	��135��6|   $��32��6�   $��Bottom=�6�   6�   �� 5'   
   -   5        $��HasFile��5'   �   #��[ 6   $��14(�64   $��31��6C   $
��Left=�6O   $��749,391,0,0q�6j   $��RightToLeft=�6�   $	��Top=�6�   $	��147��6�   $��	B Nazanin)�6�   $��Center=�6�   
�������$y�Hidden=�6  �� 5(   
   -   5        $��label1��5(   �   $C��=توجه : همه امتیازها از 100 وارد شوند��6   $��	B Nazanin)�6?   $��12(�6V   $
��Bold"�6d   
���   �$��Right=�6�   $��Center=�6�   $��0,320,122,418q�6�   #��[ 6�   $��Stretch=�6  $��Center=�6.  $��Normal$�6P  ��6c  Z� 6{  �� 5)   
   -   5        $��label3��5)   �   $��: جمع وزن ها��6   $��	B Nazanin)�6'   $��12(�6>   $��Normal$�6L   $
��Bold"�6_   
���   �$��Right=�6�   $��Center=�6�   $��0,355,122,387q�6�   #��[ 6�   $��Stretch=�6  $��Center=�6)  ��6K  Z� �� 5*   
   -   5        $��SumTxt��5*   �   $��.....��6   $��	B Nazanin)�6    $��12(�67   $��Normal$�6E   $
��Bold"�6X   
���   �$��Right=�6}   $��Center=�6�   $��0,351,188,381q�6�   #��[ 6�   $��Stretch=�6  $��Center=�6"  ��6D  Z� �� 5+   
   -   5        $��DelBtn��5+   d   $��حذف صورتجلسه��6   $��32��6(   $
��Left=�64   $��356,0,0,101q�6O   $��7��6r   $��Bottom=�6   $	��135��6�   6�   �� 5,   
   -   5        $��MinTxt��5,      �� 
IsReadOnly . $��RightToLeft=�6%   $��	B Nazanin)�6A   $��20(�6X   $��Normal"�6f   $��32��6z   $
��Left=�6�   $��Right=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��837.5,268,0,0q�6�    �� MaxLines$ 5��6   $��2��6   �� TextAlignment$
 Left=�6(   � UseLayoutRounding .  $	��Top=�6W  $��Center=�6o  $��54��6�  �� 5-   
   -   5        $	��l22��5-   �   $1��+حداقل امتیاز مورد قبول :��6   $��RightToLeft=�64   $��	B Nazanin)�6P   $��18(�6g   $��41��6u   $
��Left=�6�   $
��Left=�6�   $��730,232,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��171��6  �� 5.   
   -   5        $��label49��5.   �   $��* توضیحات :��6   $��RightToLeft=�6&   $��	B Nazanin)�6B   $��20(�6Y   $
��Left=�6g   $
��Left=�6�   $��754,497,0,221q�6�   $��Center=�6�   $	��144��6�   �� 5/   
   -   5        $��RecordDescriptionTxt��5/   �   $��RightToLeft=�6   $��	B Nazanin)�6.   $��18(�6E   $��Normal"�6S   $��Right=�6g   $
 Auto=�6�   $��104.5,506,285.5,140q�6�   $ 5��6�   $��2��6�   $
 Left=�6   �� TextWrapping$
 Wrap=�6   .  $��Stretch=�6E  $��Stretch=�6a  " �� VerticalScrollBarVisibility$
 Auto=�6�   � DataContext 6�  �� 50      51      