   M S B A M L   `   `   `  ����I  EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null[<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkitMicrosoft.Windows.Controls  5       RTM&    RTM.Tendering1.UI16RegisterBills   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ced4http://schemas.microsoft.com/expression/2010/drawing     5      Lmyd<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit     5      -   5          N�Name$
  page��5
   L    N� Title$ UI16RegisterBills��6   $	��768��62   $
��1024��6?   $��0q�6Z    N� 
Background 6   Z� .��5      � -   5        $��
layoutGrid��5   0   $
��1024��6   $	��768��6   $��0q�6%   .+�5   
   �� -   5         ��Name$ border1_Copy1��5   �    J� 	AllowDrop . 
����������	#FF9A9696$��1q�6M    �� CornerRadius$ 0��6a   $	��550��6r   $��Right=�6   $��
0,0,18,137q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��986��6�   �� 5   
   -   5         ��Name$ label22��5      $��0��6   $��0��6,   $��521,384,503,384q�66   �� 5   
   -   5        $ border1��5   �    . 
�������$��1q�6L   $ 0��6`   $��472.5��6q   $��Right=�6�   $��0,0,36,183.5q�6�   $	 0.4Q�6�   $��Bottom=�6�   $	��953��6�   ��65   Z� 6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5     	   AutoGenerateColumns	 .  
   CanUserAddRows
 .    CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $	��230��6�   $��Center=�6�      SelectionMode$ Single=�6/  $��1��6F  $��Center=�6S  $��Bottom=�6�   � UseLayoutRounding .  $��152.999,0,48.501,382q�6�  $   HorizontalScrollBarVisibility$ Visible=�6�     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        GauranteeNom��,  &System.Windows.Controls.DataGridColumn   Header$ شماره فيش��5   V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Number+6V   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ تاریخ ثبت��6)      CellTemplate 5      �� 5      .R�5      +   %Microsoft.Windows.Controls.DatePicker  $��5q�6�      SelectedDate 6-   �� *RegisterDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5        5      -   5        Bank��$ نام بانک��5   P    63   �� *
BankName+6P     5      $ نام شعبه��6E    6&   �� *
BankBranch+6E     5      -	   5        City��$ نام شهر��5   P    63   �� *
BankCity+6P     5      -
   5        	Price��$ مبلغ��5   `      
FontFamily$ Tahoma)�6n      FontSize$ 17Q�6�    64   �� *Amount+ �� StringFormat$ N0��6�   5       �� 5!   
   -   5        $ label24��5!   �   $'��!ثبت فیش های واریزی��6   $��RightToLeft=�6-   $��	B Nazanin)�6I   $��20(�6`   $��50��6n   $
��Left=�6z   $
��Left=�6�   $��815,71.333,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��166��6  �� 5"   
   -   5         ��Name$ SaveBtn��5"   �   $��ثبت��6'   $��	B Nazanin)�65   $��20(�6L   $��32��6Z   $
��Left=�6f   $��
35,591,0,0q�6�   $��5��6�   $	��Top=�6�   $��93��6�   $��Normal"�6�   �� 5#   
   -   5        $ label49��5#   �   $��توضیحات :��6   $��RightToLeft=�6$   $��	B Nazanin)�6@   $��20(�6W   $
��Left=�6e   $
��Left=�6�   $��895,0,0,339q�6�   $��Center=�6�   $��80��6�   $��50��6�   $��Bottom=�6  �� 5$   
   -   5         ��Name$ DescriptionTxt��5$   �   $��RightToLeft=�6   $��	B Nazanin)�6.   $��18(�6E   $��Normal"�6S   $��Right=�6g   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $$��152.999,418.664,48.235,195.614q�6�    �� MaxLines$ 5��6�   $��3��6�    �� TextAlignment$
 Left=�6	    �� TextWrapping$
  Wrap=�6   .  $��Stretch=�6L  $��Stretch=�6h  "! �� VerticalScrollBarVisibility$
! Auto=�6�  " � DataContext" 6�  �� # �� ElementName$# dataGrid��$ �� Path$$ SelectedItem���6�  �� *Description+�� 5%   
   -   5        $ 	DeleteBtn��5%   �   $��حذف مورد��6)   $��	B Nazanin)�6<   $��20(�6S   $��Normal"�6a   $��32��6u   $��Right=�6�   $��0,353,878,0q�6�   $��2��6�   $	��Top=�6�   $��93��6�   �� 5&   
   -   5        $��label1_Copy1��5&   �   $%��انتخاب پیمانکار :��6   $��RightToLeft=�6,   $��	B Nazanin)�6H   $��20(�6_   $��50��6m   $
��Left=�6y   $��Center=�6�   $��856,108,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��128��6  �� 5'   
   -   5        $��	ChooseCom��5'   �   $��RightToLeft=�6   $��	B Nazanin)�6/   $��20(�6F   $��Normal"�6T   $��31��6h   $��Right=�6t   $��0,119,162,0q�6�   % �� SelectedIndex$% 0��6�   $��0��6�   $	��Top=�6�   $��Center=�6�   $	��235��6  & �� SelectedValuePath$& ContractorId��6I  ' �� DisplayMemberPath$' CompanyName��6j  5(      5)      