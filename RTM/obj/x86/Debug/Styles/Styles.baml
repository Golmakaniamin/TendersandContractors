   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RTMRTM  5   9   ?$clr-namespace:RTM.Classes.ConvertersRTM.Classes.Converters  5      clr-namespace:RTMRTM  5      )clr-namespace:RTM.ClassesRTM.Classes  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullR NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� Property �� Value   RTM.DateConverterGrid   dateConverter.  (RTM.Classes.OrganizationalChartConverter  orgConverter.  (RTM.Classes.Converters.WarrantyConverter  warrantyConverter2  ,RTM.Classes.Converters.ContractTypeConverter  contractTypeConverter/  )RTM.Classes.Converters.SubsystemConverter  subsystemConverter,  &RTM.Classes.Converters.ActionConverter  actionConverter6  0RTM.Classes.Converters.IssuingReferenceConverter  issuingConverter.  (RTM.Classes.Converters.PositionConverter  positionConverter1  +RTM.Classes.Converters.CompanyNameConverter  companyNameConverter/	  )RTM.Classes.Converters.CompanySNConverter 	 companySNConverter4
  .RTM.Classes.Converters.TenderingTitleConverter 
 tenderingTitleConverter(  "System.Windows.Controls.DatePicker)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value&   System.Windows.Controls.DataGrid  
TitleLabel  ButtonFocusVisual J� SnapsToDevicePixels �� StrokeDashArray  ButtonNormalBackground �� EndPoint	 �� 
StartPoint
 � Color � Offset  ButtonNormalBorder �� Color  StartPageButtons �� 
TargetType � RowDefinitions ��Name �� TextAlignment ��Name  GreyBackground  TreeViewItemFocusVisual  	TreeArrow  ExpandCollapseToggleStyle �� Padding F�Name �� Angle �� CenterY �� CenterX �� Triggers �� 
TargetName  TreeViewItemStyle �� RelativeSource �� AncestorType � ColumnDefinitions d�Name �� 	ClickMode d� 	IsChecked ��Name  ��Name! ��Name" ]� 
Conditions# �� Property$ �� Value  	MainBrush�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      RTMclr-namespace:RTM  69   ,cvs$clr-namespace:RTM.Classes.Converters  5      dateclr-namespace:RTM  5      !orgclr-namespace:RTM.Classes  5      6my-http://schemas.microsoft.com/wpf/2008/toolkit  5      %W  '��       '�� �     &	  �    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	 %    &		 8    &	
 K    '  ^    '  �    '  �    &	 �    &	 �    &	 Q    &	 E    &	 h    &	 x    &	 �    &	 		    &	 3	    7  &	 �    7  7  &	     �� 5
      "  ��6   .�5   
   ��  � ��$% /RTM;component/Fonts/#B Nazanin)�6'   �� 5   
    � ��$ 17(�6%   �� 5   
    � ��$
 Bold"�6'   5      �� 5      "  ��6   .�5   
   �� # �@��VerticalScrollBarVisibility$ Hidden=�68   �� 5   
    �@��AcceptsReturn . 6*   �� 5   
   % �@��HorizontalScrollBarVisibility$ Hidden=�6:   5         5      6     5      6'     5      6     5      6      5      6     5      6     5      6$     5      6     5      6   	  5      6   
  5       6"   �� 5!      "   6   .�5"   
   ��  � ��$ 13(�6%   5#      �� 5$      "   6    5%   
   P� 5&       �@��AlternationIndex$ 1��6?   . �5'      ��  � ��
 �����6/   5(      P� 5)       �@��AlternationIndex$ 0��6?   . �5*      ��  � ��
 �����6/   5+      5-      �� 5.      "   6   .�5/   
   ��  �@��AlternationCount$ 2��6-   50      �� 52      "  ��6   .�53   
   ��  � ��$% /RTM;component/Fonts/#B Nazanin)�6'   �� 54   
    � ��$ 24(�6%   �� 55   
    � ��
 �����6'   56      �� 57      .�58   
   ��  � �� 59      �� 5:      .R�5;      �� $��2q�6     . #��� ��6F   $��1��6�   $	 1 2R�6�   5<      5>      5?      �� 5@      $	 0,1&�69   $		 0,0&�6H   .��5A   
   � $
 #F3F3F3��6   $ 0Q�6'   � 5B   
   $
 #EBEBEB��6   $	 0.5Q�6'   � 5C   
   $
 #DDDDDD��6   $	 0.5Q�6'   � 5D   
   $
 #CDCDCD��6   $ 1Q�6'   5E      �� 5F      $ 	#FF707070��61   �� 5H      " ��6/   .R�5I   
   �  5J      �� 5K      $��0.343* �6    �� 5L      $��0.657* �6    .+�5N      �� ���	#FFA19D9A$��Stretch=�6)   $
��Auto��6G   $��2��6U   �� 5O      $ 	textBlock��6   $��Stretch=�6+   $
��Auto��6I   $
��Wrap=�6W   $��Stretch=�6k   $
��Auto��6�   $ Center=�6�   $%��/RTM;component/Fonts/#B Nazanin)�6�   $��21.333(�6�   $
��Bold"�6�   #��z��6�   �� 5P      $ image��6   $��1��6#   $��1��60   $��UniformToFill=�6A   5Q      5R      �� 5S      $ 	#FFBDBDBD��6-   �� 5U      .�5V   
   ��  � �� 5W      �� 5X      .R�5Y      �� 5Z      5\      5]      B� 5^      $��M0,0 L0,6 L6,0 zC�6%   �� 5_      "  d�6.   .�5`   
   ��  � |� .  6&   �� 5a   
    � ��$ 16��6"   �� 5b   
    � ��$ 16��6#   �� 5c   
    � �� 5d      �� 5e      " d�6"   .R�5f      �� 
������ $��16��66   $ 5,5,5,5q�6B   $��16��6T   ._�5g      F� $ 
ExpandPath��6   8��  
������ ���	#FF989898z�5h      �� 5i   "   $	 135Q�62   $ 3Q�6>   $ 3Q�6J   5k      5l       5m      P� 5n       �@J�IsMouseOver . . �5o      �� $ 
ExpandPath��67    � �� �	#FF1BBBFA6O   �� 5p      $ 
ExpandPath��65    � ��
 ���� 6M   5q      P� 5r       �@d�	IsChecked$
 TrueY�67   . �5s      �� $ 
ExpandPath��6@    � z� 5t   "   �� 5u   &   $	 180Q�66   $ 3Q�6B   $ 3Q�6N   5w      �� 5x      $ 
ExpandPath��65    � �� �	#FF5959596M   �� 5y      $ 
ExpandPath��67    � �� �	#FF2626266O   5z      5|      5~      5      �� 5�      "  Q�6&   .�5�   
   ��  � ��
 ���� 6'   �� 5�   
    � �� 67   �� *HorizontalContentAlignment+ �� " ���� 5�   
    � �� 65   �� *VerticalContentAlignment+ �� " ���� 5�   
    � ��$ 1,0,0,0q�6$   �� 5�   
    � ��# � ��6'   �� 5�   
    �@�FocusVisualStyle8   6-   �� 5�   
    � �� 5�      �� 5�      " Q�6"   .R�5�      �  5�      �� 5�      $��19��6/   $
��Auto �6=   �� 5�      $
��Auto �6/   �� 5�      $��* �6/    5�      �� 5�      $
��Auto �6,   �� 5�      .+�5�      d� $ Expander��6'   $ Press=�69   8��  6K   �� *
IsExpanded+ �� *TemplatedParent+6�   �� 5�      $ Bd��6!   #��z��6-   #��z��6Y   #��z��6�   $��1��6�   # z��6�    . ._�5�      �� $  PART_Header��6/   $��Header��6D   #��z��6[   # z 6�   5�      �� 5�      $! 	ItemsHost��6)   $��2��6<   $��1��6P   $��1��6`   5�       5�      P� 5�       �@Q�
IsExpanded .  . �5�      �� $ 	ItemsHost��6;    � y�$ 	Collapsed=�6R   5�      P� 5�       �@��HasItems .  . �5�      �� $ Expander��6;    � y�$ Hidden=�6Q   5�      P� 5�       �@Q�
IsSelected . . �5�      �� $ Bd��6;   # � ��6K    � ���� 5�      # � ��6;    � ��5�      ]� 5�      " 5�      �� 5�   "   # �@Q�
IsSelected$ . 6B   �� 5�   "   # �@Q�IsSelectionActive$ .  6I   ./�5�      �� $ Bd��6;   # � ��6K    � ���� 5�      # � ��6;    � ��5�      P� 5�       � {� .  . �5�      �� # � ��6;    � ��5�      5�      5�       5�   
   P� 5�       �@$�IsVirtualizing . . �5�      ��  � �� 5�      �� 5�      .R�5�      $� 5�      5�      5�      5�      �� 5�      $ 	#FFFFA949��6(   5�      