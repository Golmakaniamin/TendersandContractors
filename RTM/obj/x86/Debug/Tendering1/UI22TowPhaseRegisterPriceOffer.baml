   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RTMRTM  5	   X   3    -RTM.Tendering1.UI22TowPhaseRegisterPriceOffer   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ced4http://schemas.microsoft.com/expression/2010/drawing     5       myclr-namespace:RTM     5	   X   -   5          N�Name$
  page��5	   ?    N� Title$
 UI22��6   $	��768��6%   $
��1024��62   $��0q�6M    N� 
Background 6   Z� .��5      � -   5        $��
layoutRoot��5   0   $
��1024��6   $	��768��6   $��0q�6%   .+�5   
   �� -   5         ��Name$ border1_Copy1��5   �    J� 	AllowDrop . 
����������	#FF9A9696$��1q�6M    �� CornerRadius$ 0��6a   $	��561��6r   $��Right=�6   $��
0,0,18,112q�6�    J� Opacity$	 0.4Q�6�   $��Bottom=�6�   $	��989��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5   !     AutoGenerateColumns .  	   CanUserDeleteRows	 .  
   CanUserReorderColumns
 .     CanUserResizeRows .     CanUserSortColumns . $��RightToLeft=�6�   $��	B Nazanin)�6�   $��20(�6�   $��Normal"�6�   $	��249��6�   $��Center=�6�      SelectionMode$ Single=�63  $��0��6J  $��Center=�6W  $	��915��6y  $��Bottom=�6�   � UseLayoutRounding .  $��52.963,0,56.037,162.5q�6�     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Cntrctr��,  &System.Windows.Controls.DataGridColumn   Header$ نام پیمانکار��5   �      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ��  �� Path$ ContractorId�   companyNameConverter �� 	Converter# [  6�     5      -   5        	SocialNom��$( "شناسه ملی پیمانکار��5   �    .  68   �� *ContractorId+  companySNConverter# [ 6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      -   5        estimate��$, &ارزیابی شکلی پیشنهاد��5   ]    6;   �� *BidEvaluation+6]     5      -   5        PrcOffer��$ مبلغ پیشنهادی��5   a    67   �� *Bid1+ �� StringFormat$ N0��6a   5      �� 5   
   -	   5         ��Name$ label22��5      $��0��6   $��0��6,   $��518,384,506,384q�66   �� 5   
   -
   5         ��Name$ SaveBtn��5   �   $��ثبت��6   $��	B Nazanin)�6    $��20(�67   $��32��6E   $
��Left=�6Q   $��
53,615,0,0q�6l   $��2��6�   $	��Top=�6�   $��93��6�   $��Normal"�6�   6�   �� 5   
   -   5        $ label24��5   �   $9��3ثبت پیشنهاد قیمت دو مرحله ای��6   $��RightToLeft=�67   $��	B Nazanin)�6S   $��20(�6j   $��50��6x   $
��Left=�6�   $
��Left=�6�   $��
779,95,0,0q�6�   $	��Top=�6�   $��Center=�6�   $	��211��6       RTM.TenderingHeaderControl  5   
   -   5          Name$ Header��5   S   $
��Left=�6$   $��
31,148,0,0q�6?   $	��Top=�6c   5      5      