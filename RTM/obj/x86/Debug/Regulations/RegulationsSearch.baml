   M S B A M L   `   `   `  ����  RTM'    !RTM.Regulations.RegulationsSearch   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6my-http://schemas.microsoft.com/wpf/2008/toolkit  5   1   -   5          N�Name$
  page��5   1    N� Title$ RegulationsPage2��5       N� 
Background 6   Z� .��5
      � $	��768��6   $
��1024��6   ��6%   Z� .+�5   
   �� -   5        $��Border��5   �   
�������$��1q�6;    �� CornerRadius$ 0��6O   $	��540��6`   $��Right=�6m   $��
0,0,86,134q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��847��6�   ��6$   Z� ._�5      �� -   5        $��label2��5      $��0��6   $��0��6-   5      �� 5   
   -   5        $��Title��5   �   $)��#جستجوی آیین نامه ها��6   $%��/RTM;component/Fonts/#B Nazanin)�6.   $��23(�6[   $��Normal"�6i   
���   �$��51��6�   $��Right=�6�   $��Center=�6�   $��0,93,106,624q�6�      
TitleLabel#��[  6�   $��Stretch=�6#  $��Center=�6?  �� 5   
   -   5        $��
RefreshBtn��5   *   $��133,313,771,423q�6   $��6��6<   $	��120��6I   $��تازه سازی��6U   6i   �� 5   
   -   5        $��TypeCom��5   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6/   $��20(�6\   $��Normal"�6j   $��32��6~   $��496,157,232,0q�6�    �� SelectedIndex$ -1��6�   $��0��6�   $	��Top=�6�   $��Center=�6�    �� Text 6
  ��  �� ElementName$
 page�� �� Path$ CurrentRegulation.Type�.@�5      �� $��
قانون��6   6-   �� 5      $��آئين نامه��6   61   �� 5      $��بخشنامه��6   6/   �� 5      $��دستورالعمل��6   62   5      �� 5   
   -   5        $��TitleTxt��5   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6.   $��20(�6[   $��Normal"�6i   $��32��6}   $��Right=�6�   $	 �� HorizontalScrollBarVisibility$
	 Auto=�6�   $��385,312.723,232,0q�6�   
 �� MaxLines$
 5��6�   $��4��6	   �� TextAlignment$
 Left=�6   � UseLayoutRounding .  $	��Top=�6E  $��Center=�6]  ��6  �� $
 page��$ CurrentRegulation.Title�&   System.Windows.Controls.DataGrid  5   
   -   5        $
��Grid��5        AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns .  $��RightToLeft=�6�   $%��/RTM;component/Fonts/#B Nazanin)�6�   $��20(�6�   $��Normal"�6
  $	��229��6  $
��Left=�6+  $��Center=�6F  $��131,355,0,0q�6j     SelectionMode$ Single=�6�  $��7��6�  $	��Top=�6�  $��Center=�6�  $	��661��6�     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ گروه��6&   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Group+  5      $ نوع��6&    63   �� *Type+  5      $ 
موضوع��6&    65   �� *Title+  5      $" مرجع صادر کننده��6&    6A   �� $ IssuingReferenceId�  issuingConverter �� 	Converter# [   5      $$ واحد اقدام کننده��6&    6@   �� $ ActingReferenceId�  orgConverter# [   5      $ تاريخ صدور��6&    6:   �� $ IssuingDate�  dateConverter# [ 4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ تأييد نهايي��6)    6>   �� *PermanentRecord+5!      �� 5"   
   -	   5        $��GroupCom��5"   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6/   $��20(�6\   $��Normal"�6j   $��32��6~   $��496,195,232,0q�6�   $ -1��6�   $��1��6�   $	��Top=�6�   $��Center=�6�    6  �� $
 page��$ CurrentRegulation.Group�.@�5#   
   �� $��مناقصات��6   6+   �� 5$   
   $��ارزيابي��6   6+   �� 5%   
   $��قراردادها��6   6-   �� 5&   
   $��
حقوقي��6   6)   5'      �� 5(   
   -
   5        $��ReferenceCom��5(   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6/   $��20(�6\   $��Normal"�6j   $��32��6~   $��496,233,232,0q�6�   $��2��6�   $	��Top=�6�   $��Center=�6�    �� DisplayMemberPath$ Title��6R   �� SelectedValuePath$ IssuingReferenceId��6l   �� SelectedValue 6�   �� $
 page��$* $CurrentRegulation.IssuingReferenceId�6l  �� 5)   
   -   5        $��	ActingCom��5)   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�6/   $��20(�6\   $��Normal"�6j   $��32��6~   $��496,271,232,0q�6�   $��3��6�   $	��Top=�6�   $��Center=�6�   $ Title��6N  $ ChartNodeId��6h   6�   �� $
 page��$) #CurrentRegulation.ActingReferenceId�6h  �� 5*   
   -   5        $��label1��5*   �   $��نوع :��6   $��RightToLeft=�6    $%��/RTM;component/Fonts/#B Nazanin)�6<   $��20(�6i   $��40��6w   $
��Left=�6�   $
��Left=�6�   $��798,151,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��120��6  �� 5+   
   -   5        $��label3��5+   �   $��
گروه :��6   $��RightToLeft=�6!   $%��/RTM;component/Fonts/#B Nazanin)�6=   $��20(�6j   $��41��6x   $
��Left=�6�   $
��Left=�6�   $��798,189,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��120��6  �� 5,   
   -   5        $��label4��5,   �   $#��مرجع صادرکننده :��6   $��RightToLeft=�6+   $%��/RTM;component/Fonts/#B Nazanin)�6G   $��20(�6t   $��41��6�   $
��Left=�6�   $
��Left=�6�   $��789,228,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��129��6(  �� 5-   
   -   5        $��label5��5-   �   $&�� واحد اقدام کننده :��6   $��RightToLeft=�6-   $%��/RTM;component/Fonts/#B Nazanin)�6I   $��20(�6v   $��41��6�   $
��Left=�6�   $
��Left=�6�   $��798,264,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��120��6*  �� 5.   
   -   5        $��label6��5.   �   $��تاریخ صدور :��6   $��RightToLeft=�6'   $%��/RTM;component/Fonts/#B Nazanin)�6C   $��20(�6p   $��41��6~   $
��Left=�6�   $
��Left=�6�   $��760,299,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��120��6$  $y�Hidden=�60  �� 5/   
   -   5        $��label7��5/   �   $��موضوع :��6   $��RightToLeft=�6"   $%��/RTM;component/Fonts/#B Nazanin)�6>   $��20(�6k   $��41��6y   $
��Left=�6�   $
��Left=�6�   $��798,313,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��120��6  �� 50   
   -   5        $��	SearchBtn��50   T   $��
جستجو��6   $��Right=�6!   $��0,313,645,423q�6=   $��5��6e   $	��120��6r   6~   +  %Microsoft.Windows.Controls.DatePicker  51   
   -   5        $��datePicker1��51   d   $��RightToLeft=�6   $
��Left=�64   $��458,311,0,0q�6O   $	��Top=�6�   $	��296��6�   $y�Hidden=�6�      SelectedDate 6w   �� $
 page��$# CurrentRegulation.IssuingDate�6�   �� 52   
   -   5        $��button1��52   U   $��مشاهده��6   $��Right=�6"   $��0,590,771,146q�6>   $��9��6d   $	��120��6q   6}   �� 53   
   -   5        $��button2��53   U   $��ویرایش��6   $��Right=�6"   $��0,590,645,146q�6>   $��8��6d   $	��120��6q   6}   �� 54   
   -   5        $��PrintBtn��54   W   $��چاپ گزارش��6   $
��Left=�6%   $��673,590,0,147q�6@   $��9��6g   $	��119��6t   6�   55      56      