   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RTMRTM  5   5   /    )RTM.TenderingArchive.TenderingArchiveMain   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5       myclr-namespace:RTM     5   5   -   5          N� Title$  TenderingArchiveMain��5      $
��1024��6g   $	��768��6t    N� 
Background 6   Z� .��5
      � -   5         �Name$ 
layoutRoot��5
   ;   $	��768��6   $
��1024��6   ��6%   Z� .+�5   
   �� -   5        $��border1��5   �   
�������$y�Hidden=�6$   $��1q�6P    �� CornerRadius$ 0��6d   $	��590��6u   $��Right=�6�   $��	0,0,23,74q�6�    J� Opacity$	 0.6Q�6�   $��Bottom=�6�   $	��989��6�   ��69   Z� ._�5      �� -   5        $��label9��5      $��0��6   $��0��6-   5      �� 5   
   -   5        $��Border��5   �   
�������$��1q�6=   $ 0��6Q   $	��599��6b   $��Right=�6o   $��	0,0,23,65q�6�   $	 0.4Q�6�   $��Bottom=�6�   $	��989��6�   ��6&   Z� 6�   �� 5   
   -   5        $��Title��5   �   $4��.ثبت و ویرایش اسناد مناقصه��6   $%��/RTM;component/Fonts/#B Nazanin)�64   $��23(�6a   $��Normal"�6o   
���   �$��51��6�   $��Right=�6�   $��Center=�6�   $��0,104,43,613q�6�      
TitleLabel#��[  6  $��Stretch=�6)  $��Center=�6E  &   System.Windows.Controls.DataGrid  5   
   -   5        $
��Grid��5   q     AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .    CanUserReorderColumns .  	   CanUserResizeRows	 .  
   CanUserSortColumns
 .  $��RightToLeft=�6�   $%��/RTM;component/Fonts/#B Nazanin)�6�   $��20(�6�   $��Normal"�6	  $��Right=�6  $��Center=�69  $��
0,360,43,0q�6]     SelectionMode$ Single=�6}  $��0��6�  $��Center=�6�  $	��950��6�  $	��293��6�  $	��Top=�6�     Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
عنوان��6)      MinWidth$	 170Q�68      
IsReadOnly .     CellTemplate 5      �� 5      .R�5      �� $��	DocTitles��6'    �� DisplayMemberPath$ Title��68    �� SelectedValuePath$ DocumentIndex��6R   {�.   �� SelectedValue 6t   ��  �� Path$ DocumentIndex���6�   �� $ DocTypes� �� RelativeSource �� *FindAncestor+ �� AncestorType" N�6  5      5      0  *System.Windows.Controls.DataGridTextColumn  5       . $ زمان بارگذاري��68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� $ AttachedDate�  dateConverter �� 	Converter# [   5      $ مشاهده��6)    5      �� 5      .R�5      �� -   5        $��مشاهده��5   %   $��5q�66   6B   5       5"        5*      $ توضیحات��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6c    66   �� $ Version� �� Mode$ TwoWay=�6c   5,          RTM.TenderingHeaderControl  5-   
   -	   5          Name$ Header��5-   S       RTM.TenderingHeaderControl   Loaded$ Header_Loaded��6{   $
��Left=�6$   $��
31,154,0,0q�6?   $	��Top=�6c   6{   �� 5.   
   -
   5        $��
RefreshBtn��5.   U   $��تازه سازی��6   $
��Left=�6%   $��31,657,0,79q�6@   $��1��6g   $	��110��6t   6�   5/      50      