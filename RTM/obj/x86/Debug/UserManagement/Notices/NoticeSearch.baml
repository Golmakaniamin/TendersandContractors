   M S B A M L   `   `   `  ����  RTM    RTM.Notices.NoticeSearch   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          N� Title$  NoticeSearch��5      .��5	      � $	��768��6!   $
��1024��6.   ��6   Z� .+�5
   
   �� -   5        $��Border��5
   �   
�������$��1q�6;    �� CornerRadius$ 0��6O   $	��608��6`   $
��Left=�6m   $��169,55,0,105q�6�    J� Opacity$	 0.4Q�6�   $��Center=�6�   $	��648��6�   ��6$   Z� ._�5      �� -   5        $��label2��5      $��0��6   $��0��6-   5      �� 5   
   -   5        $��Title��5   �   $!��جستجوی فراخوان��6   $%��/RTM;component/Fonts/#B Nazanin)�6)   $��23(�6V   $��Normal"�6d   
���   �$��51��6�   $��Right=�6�   $��Center=�6�   $��0,51,219,666q�6�      
TitleLabel#��[  6�   $��Stretch=�6  $��Center=�6:  �� 5   
   -   5        $��
RefreshBtn��5   Y   $��تازه سازی��6   $
��Left=�6'   $��576,249,0,487q�6B   $��5��6k   $	��110��6x   6�   �� 5   
   -   5        $��	SearchBtn��5   �   $��
جستجو��6)   $��	B Nazanin)�69   $��20(�6P   $��Normal"�6^   $��32��6r   $��0,249,222,0q�6~   $��4��6�   $	��Top=�6�   $��Right=�6�   $	��110��6�   �� 5   
   -   5        $��TenderSystemCodeTxt��5      $��RightToLeft=�6   $��	B Nazanin)�6.   $��20(�6E   $��Normal"�6S   $��31��6g   $
��Left=�6s   $��Right=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��494.714,142.231,0,0q�6�    �� MaxLines$ 5��6�   $��1��6   �� TextAlignment$
 Left=�6n   �� TextWrapping$
 Wrap=�6�   � UseLayoutRounding .  $	��Top=�6�  $��Center=�6�  $	��188��6�  ��6(  ��  �� ElementName$
 page��	 �� Path$#	 CurrentTender.TenderingNumber�6�  �� 5   
   -   5        $��label9��5   �   $!��شماره فراخوان :��6   $��RightToLeft=�6*   $��	B Nazanin)�6F   $��20(�6]   $��50��6k   $��Right=�6w   $��Center=�6�   $��0,132,198,0q�6�   $	��Top=�6�   $��Center=�6�   $	��150��6  �� 5   
   -	   5        $��label10��5   �   $��عنوان پروژه :��6   $��RightToLeft=�6(   $��	B Nazanin)�6D   $��20(�6[   $��50��6i   $��Right=�6u   $��Center=�6�   $��0,165,207,0q�6�   $	��Top=�6�   $��Center=�6�   $	��114��6  �� 5   
   -
   5        $��TenderTitleTxt��5      $��RightToLeft=�6   $��	B Nazanin)�6.   $��20(�6E   $��Normal"�6S   $��31��6g   $
��Left=�6s   $��Right=�6�   $
 Auto=�6�   $��182.714,176.231,0,0q�6�   $ 5��6�   $��2��6  $
 Left=�6k  $
 Wrap=�6�   .  $	��Top=�6�  $��Center=�6�  $	��500��6�  ��6#  �� $
 page��$%	 CurrentTendering.TenderingTitle�6�  �� 5   
   -   5        $��RequestNumber��5      $��RightToLeft=�6   $��	B Nazanin)�6.   $��20(�6E   $��Normal"�6S   $��31��6g   $
��Left=�6s   $��Right=�6�   $
 Auto=�6�   $��494.714,108.231,0,0q�6�   $ 5��6�   $��0��6  $
 Left=�6h  $
 Wrap=�6}   .  $	��Top=�6�  $��Center=�6�  $	��188��6�  ��6"  �� $
 page��$#	 CurrentTender.TenderingNumber�6�  �� 5   
   -   5        $��label8��5   �   $!��شماره درخواست :��6   $��RightToLeft=�6*   $��	B Nazanin)�6F   $��20(�6]   $��50��6k   $��Right=�6w   $��Center=�6�   $��
0,97,220,0q�6�   $	��Top=�6�   $��Center=�6�   $	��118��6  &   System.Windows.Controls.DataGrid  5   
   -   5        $
��Grid��5   m  
   AutoGenerateColumns
 .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $��329.389��6  $��Center=�6     
IsReadOnly . $��182.714,0,220,151.611q�6N     SelectionMode$ Single=�6y  $��6��6�   .  $��Bottom=�6�  $��Center=�6�     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ شماره درخواست��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *RequestNumber+6G     5      $ شماره فراخوان��6F    6%   �� *NoticeNumber+6F     5      $ عنوان پروژه��6F    6%   �� *ProjectTitle+6F     5      $ واحد متقاضی��6q    6%   �� *RequestingUnit+  orgConverter �� 	Converter# [ 6q   5      �� 5   
   -   5        $��OpenBtn��5   �   $��مشاهده��6)   $��	B Nazanin)�6:   $��20(�6Q   $��Normal"�6_   $��32��6s   $��183,622,731,0q�6   $��7��6�   $	��Top=�6�   �� 5    
   -   5        $��label7��5    �   $��واحد متقاضی :��6   $��RightToLeft=�6(   $��	B Nazanin)�6D   $��20(�6[   $��50��6i   $��Center=�6u   $��701,202,219,0q�6�   $	��Top=�6�   $��Center=�6�   �� 5!   
   -   5        $��RequestUnitCom��5!   �   $��RightToLeft=�6    �� DisplayMemberPath$ Title��6/    �� SelectedValuePath$ ChartNodeId��6I   $��	B Nazanin)�6j   $��20(�6�   $��Normal"�6�   $��32��6�   $
��Left=�6�   $��494,0,0,525q�6�    �� SelectedIndex$ -1��6�   $��3��6  $��Bottom=�6Y  $��Center=�6t  $	��189��6�   �� Text 6  �� $
 page��$!	 CurrentTender.TenderingType�6�  5"      5#      