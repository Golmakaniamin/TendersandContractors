   M S B A M L   `   `   `  ����I  EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null[<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkitMicrosoft.Windows.Controls  5       RTM/   )RTM.Tendering1.UI15RegisterBankGaurantees   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ced4http://schemas.microsoft.com/expression/2010/drawing     5      Lmyd<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit     5      -   5          N�Name$
  page��5
   U    N� Title$  UI15RegisterBankGaurantees��6   $	��768��6;   $
��1024��6H   $��0q�6c    N� 
Background 6%   Z� .��5      � -   5        $��
layoutRoot��5   0   $
��1024��6   $	��768��6   $��0q�6%   .+�5   
   �� -   5         ��Name$ border1_Copy1��5   �    J� 	AllowDrop . 
����������	#FF9A9696$��1q�6M    �� CornerRadius$ 0��6a   $	��550��6r   $��Right=�6   $��
0,0,21,133q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��986��6�   �� 5   
   -   5        $ border1��5   �    . 
�������$��1q�6L   $ 0��6`   $��472.5��6q   $��Right=�6�   $��
0,0,39,180q�6�   $	 0.4Q�6�   $��Bottom=�6�   $	��953��6�   ��65   Z� 6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5   3     AutoGenerateColumns .  	   CanUserAddRows	 . 
   
IsReadOnly
 .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $��230.5��6   $��Center=�6     SelectionMode$ Single=�6E  $��1��6\  $��Center=�6i  $��Bottom=�6�   � UseLayoutRounding .  $��154,0,52.5,377.5q�6�  $   HorizontalScrollBarVisibility$ Visible=�6     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        GauranteeNom��,  &System.Windows.Controls.DataGridColumn   Header$# شماره ضمانتنامه��5   V      FontSize$ 17Q�6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Number+6o   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ تاریخ ثبت��6)      CellTemplate 5      �� 5      .R�5      +   %Microsoft.Windows.Controls.DatePicker  $��5q�6�      SelectedDate 6-   �� *RegisterDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5        5      $ تاریخ اعتبار��6)    5      �� 5      .R�5        $��5q�6�    6-   �� *ValidityDate+$ TwoWay=�$ PropertyChanged=�6�   5      5        5       -   5        Bank��$ نام بانک��5    P    63   �� *
BankName+6P     5!      $ نام شعبه��6E    6&   �� *
BankBranch+6E     5"      -   5        City��$ نام شهر��5"   P    63   �� *
BankCity+6P     5#      -	   5        	Price��$ مبلغ��5#   `      
FontFamily$ Tahoma)�6n    64   �� *Amount+ �� StringFormat$ N0��6n   5%      �� 5&   
   -
   5         ��Name$ label22��5&      $��0��6   $��0��6,   $��518,388,506,380q�66   �� 5'   
   -   5        $ label24��5'   �   $1��+ثبت ضمانتنامه های بانکی��6   $��RightToLeft=�62   $��	B Nazanin)�6N   $��20(�6e   $��50��6s   $
��Left=�6   $
��Left=�6�   $��
812,75,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��166��6  �� 5(   
   -   5        $ label1_Copy1��5(   �   $%��انتخاب پیمانکار :��6   $��RightToLeft=�6,   $��	B Nazanin)�6H   $��20(�6_   $��50��6m   $
��Left=�6y   $��Center=�6�   $��847,115,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��128��6  �� 5)   
   -   5         ��Name$ SaveBtn��5)      $��ثبت��6   $��	B Nazanin)�6   $��20(�66   $��32��6D   $
��Left=�6P   $��
32,595,0,0q�6k   $��4��6�   $	��Top=�6�   $��93��6�   $��Normal"�6�   6�   �� 5*   
   -   5        $ label49��5*   �   $��توضیحات :��6   $��RightToLeft=�6$   $��	B Nazanin)�6@   $��20(�6W   $
��Left=�6e   $
��Left=�6�   $��894,0,0,336q�6�   $��Center=�6�   $��80��6�   $��50��6�   $��Bottom=�6  �� 5+   
   -   5         ��Name$ DescriptionTxt��5+   �   $��RightToLeft=�6   $��	B Nazanin)�6.   $��18(�6E   $��Normal"�6S   $��Right=�6g   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��154,424,53.111,195q�6�    �� MaxLines$ 5��6�   $��3��6�     �� TextAlignment$
  Left=�6�   ! �� TextWrapping$
! Wrap=�6   .  $��Stretch=�6A  $��Stretch=�6]  "" �� VerticalScrollBarVisibility$
" Auto=�6�  # � DataContext# 6�  �� $ �� ElementName$$ dataGrid��% �� Path$% SelectedItem���6�  �� *Description+�� 5,   
   -   5        $ 	DeleteBtn��5,   �   $��حذف ضمانتنامه��6   $��	B Nazanin)�6)   $��20(�6@   $��Normal"�6N   $��32��6b   $��Right=�6n   $��0,358,878,0q�6�   $��2��6�   $	��Top=�6�   $	��102��6�   6�   �� 5-   
   -   5        $��	ChooseCom��5-   �   $��RightToLeft=�6   $��	B Nazanin)�6/   $��20(�6F   $��Normal"�6T   $��33��6h   $
��Left=�6t   $��646,124,0,0q�6�   & �� SelectedIndex$& 0��6�   $��0��6�   $	��Top=�6�   $��Center=�6�   $	��203��6  ' �� SelectedValuePath$' ContractorId��6  ( �� DisplayMemberPath$( CompanyName��6;  6[  5.      5/      