   M S B A M L   `   `   `  ����  RTM#    RTM.Contracts.ContractsSearch   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6my-http://schemas.microsoft.com/wpf/2008/toolkit  5      -   5          N�Name$
  page��5   S    N� Title$ ContractsSearch��6   .��5
      � $��Center=�6   $��Center=�6&   $	��768��6Y   $
��1024��6f   ��6C   Z� .+�5   
   �� -   5        $��Border��5   �   $��1q�6>    �� CornerRadius$ 0��6R   $	��540��6c   $��Right=�6p   $��0,0,203.333,130q�6�    J� Opacity$ 1Q�6�   $��Bottom=�6�   $	��631��6�   ��6   Z� ��6'   Z� ._�5      � $
��Left=�6   $	��Top=�6.   $	��628��6F   .+�5      �� -   5        $��border1_Copy��5   �    J� 	AllowDrop . 
�������$��1q�6T   $ 0��6h   $	��605��6y   $
��Left=�6�   $	 0.6Q�6�   $��Bottom=�6�   $	��669��6�   $��-22,0,0,-53q�6�   ��6=   Z� 6�   �� 5      -   5        $��Title��5   �   $%��جستجوی قراردادها��6   $%��/RTM;component/Fonts/#B Nazanin)�63   $��23(�6`   $��Normal"�6n   
���   �$��51��6�   $
��Left=�6�   $��Center=�6�   $��451,6,0,481q�6�      
TitleLabel#��[  6  $��Stretch=�6&  $��Center=�6B  �� 5      -   5        $��
RefreshBtn��5   D   $��تازه سازی��6   $��348,328,0,178q�6-   $��9��6V   $	��120��6c   $
��Left=�6o   6�   �� 5      -   5        $��TitleTxt��5   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�66   $��20(�6c   $��Normal"�6q   $��32��6�   $��Right=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��26.5,214,0,0q�6�    �� MaxLines$ 5��6�   $��5��6   �� TextAlignment$
 Left=�6_   � UseLayoutRounding .  $	��Top=�6�  $��Center=�6�  $
��Left=�6�  $��464.5��6�  ��6  �� 	 �� ElementName$
	 page��
 �� Path$#
 CurrentContract.ContractTitle�6�  &   System.Windows.Controls.DataGrid  5      -   5        $
��Grid��5   �     AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns .  $��RightToLeft=�6�   $%��/RTM;component/Fonts/#B Nazanin)�6�   $��20(�6  $��Normal"�6  $	��166��6&  $
��Left=�63  $��Center=�6N     
IsReadOnly . $��
26,366,0,0q�6�     SelectionMode$ Single=�6�  $��10��6�  $	��Top=�6�  $��Center=�6�  $	��568��6     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ شماره قرارداد��6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *ContractNumber+6P     5      $ شماره مناقصه��6U    6-   �� *TenderingSystemCode+6U     5      $ نوع قرارداد��6�    6-   �� *ContractTypeId+  contractTypeConverter �� 	Converter# [ 6�     5      $ عنوان قرارداد��6O    6-   �� *ContractTtile+6O     5      $ تاريخ قرارداد��6~    6-   �� $
 AgreementDate�  dateConverter# [ 6~     5      $ نام پيمانکار��6    6-   �� *ContractorId+  companyNameConverter# [ 6     5      $ نام مشاور��6    6-   �� *ConsultantId+# [ 6   5!      �� 5"      -   5        $��TypeCom��5"   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�68   $��20(�6e   $��Normal"�6s   $��32��6�   $��172,141,0,0q�6�   $��2��6�   $	��Top=�6�   $��Center=�6�   $
��Left=�6   $	��319��6   �� SelectedValuePath$ ContractTypeId��6'   �� DisplayMemberPath$ ContractType1��6J  �� 5#      -	   5        $��label1��5#   �   $��شماره مناقصه :��6   $��RightToLeft=�61   $%��/RTM;component/Fonts/#B Nazanin)�6M   $��20(�6z   $��40��6�   $
��Left=�6�   $
��Left=�6�   $��
474,61,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��120��6-  �� 5$      -
   5        $��label3��5$   �   $!��شماره قرارداد :��6   $��RightToLeft=�62   $%��/RTM;component/Fonts/#B Nazanin)�6N   $��20(�6{   $��41��6�   $
��Left=�6�   $
��Left=�6�   $��
474,99,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��120��6.  �� 5%      -   5        $��label4��5%   �   $��نوع قرارداد :��6   $��RightToLeft=�60   $%��/RTM;component/Fonts/#B Nazanin)�6L   $��20(�6y   $��41��6�   $
��Left=�6�   $
��Left=�6�   $��466,136,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��129��6-  �� 5&      -   5        $��label5��5&   �   $��عنوان :��6   $��RightToLeft=�6*   $%��/RTM;component/Fonts/#B Nazanin)�6F   $��20(�6s   $��41��6�   $
��Left=�6�   $
��Left=�6�   $��474,212,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��120��6'  �� 5'      -   5        $��label7��5'   �   $��تاریخ :��6   $��RightToLeft=�6*   $%��/RTM;component/Fonts/#B Nazanin)�6F   $��20(�6s   $��41��6�   $
��Left=�6�   $
��Left=�6�   $��474,173,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��120��6'  �� 5(      -   5        $��	SearchBtn��5(   [   $��
جستجو��6   $
��Left=�6)   $��474,328,0,178q�6D   $��8��6l   $	��120��6y   6�   �� 5)      -   5        $��TenderNumberTxt��5)   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�66   $��20(�6c   $��Normal"�6q   $��32��6�   $��Right=�6�   $
 Auto=�6�   $��
290,65,0,0q�6�   $ 5��6�   $��0��6  $
 Left=�6b   .  $	��Top=�6�  $��Center=�6�  $
��Left=�6�  $	��201��6�  ��6  �� $
	 page��$!
 CurrentContract.TenderingId�6�  �� 5*      -   5        $��ContractNumberTxt��5*   �   $��RightToLeft=�6   $%��/RTM;component/Fonts/#B Nazanin)�66   $��20(�6c   $��Normal"�6q   $��32��6�   $��Right=�6�   $
 Auto=�6�   $��290,103,0,0q�6�   $ 5��6�   $��1��6  $
 Left=�6h   .  $	��Top=�6�  $��Center=�6�  $
��Left=�6�  $��201.097��6�  ��6!  �� $
	 page��$$
 CurrentContract.ContractNumber�6�  +  %Microsoft.Windows.Controls.DatePicker  5+      -   5        $��ToDate��5+   x   $��RightToLeft=�6    $��31��6<   $
��Left=�6H   $��172,179,0,0q�6c      Text$ انتخاب تاريخ��6�   $	��Top=�6�   $	��141��6�   $��4��6�     5,      -   5        $��FromDate��5,   x   $��RightToLeft=�6    $��31��6<   $
��Left=�6H   $��350,179,0,0q�6c   $ انتخاب تاريخ��6�   $	��Top=�6�   $	��141��6�   $��3��6�   �� 5-      -   5        $��label6��5-   �   $
��تا��6   $��RightToLeft=�6%   $%��/RTM;component/Fonts/#B Nazanin)�6A   $��20(�6n   $��41��6|   $
��Left=�6�   $
��Left=�6�   $��319,173,0,0q�6�   $	��Top=�6�   $��Center=�6   $��21��6"  �� 5.      -   5        $��ContractorsCom��5.     $ CompanyName��6   $��RightToLeft=�6;   $%��/RTM;component/Fonts/#B Nazanin)�6W   $��20(�6�   $��Normal"�6�   $��32��6�   $��Right=�6�    �� 
IsEditable .   �� IsTextSearchEnabled . $��0,252,137,0q�6�    �� SelectedIndex$ 0��6'  $ ContractorId��6m  $��6��6�  $	��Top=�6�  $��Center=�6�  $	��463��6�   �� SelectedValue 69  �� *ContractorId+ �� Mode$ TwoWay=�6�  �� 5/      -   5        $��label11��5/   �   $��نام پیمانکار:��6   $��RightToLeft=�60   $%��/RTM;component/Fonts/#B Nazanin)�6L   $��20(�6y   $��40��6�   $��Right=�6�   $
��Left=�6�   $��
0,248,36,0q�6�   $	��Top=�6�   $��Center=�6  $	��102��6.  �� 50      -   5        $��ConsultantCom��50   �   $ CompanyName��6   $��RightToLeft=�6;   $%��/RTM;component/Fonts/#B Nazanin)�6W   $��20(�6�   $��Normal"�6�   $��32��6�   $
��Left=�6�   $��
28,289,0,0q�6�   $ 0��6�   $ ContractorId��6/  $��7��6P  $	��Top=�6]  $��Center=�6u  $	��463��6�  $y�Hidden=�6�   6  �� *ConsultantId+6�  �� 51      -   5        $��label16��51   �   $��مشاور :��6   $��RightToLeft=�6*   $%��/RTM;component/Fonts/#B Nazanin)�6F   $��20(�6s   $��40��6�   $��Right=�6�   $
��Left=�6�   $��
0,284,38,0q�6�   $	��Top=�6�   $��Center=�6  $	��102��6(  $y�Hidden=�64  52      53      �� 54   
   -   5        $��PrintBtn��54   V   $��چاپ گزارش��6   $
��Left=�6%   $��191,645,0,92q�6@   $��13��6f   $	��119��6t   6�   �� 55   
   -   5        $��button2��55   S   $��ویرایش��6   $
��Left=�6"   $��441,645,0,91q�6=   $��11��6b   $	��120��6p   6|   �� 56   
   -   5        $��button1��56   S   $��مشاهده��6   $
��Left=�6"   $��315,645,0,91q�6=   $��12��6b   $	��120��6p   6|   57      58      