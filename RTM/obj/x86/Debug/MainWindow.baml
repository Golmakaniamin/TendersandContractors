   M S B A M L   `   `   `  ����>  :RTM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:RTM.UserControlsRTM.UserControls  5   	   clr-namespace:RTMRTM  6A       RTM.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=nullH 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;RTM_UserControlsclr-namespace:RTM.UserControls     5   	   #localclr-namespace:RTM     6A   -   5        $
��Page��5        � Title$G  Aسامانه یکپارچه امور پیمان ويرايش 1.31��5   	   $	��768��67   $
��1024��6D    � WindowStartupLocation$ CenterScreen=�6Q    � WindowStyle$ ThreeDBorderWindow=�6v   $
��1024��6�   $	��768��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�    � WindowState$ 	Maximized=�6�   |�.   � 	Resources 5        RTM.DateConverter   DateConverter��%   &	          5	      6   5
      ��5      �� 5   
    �� ImageSource$, &/RTM;component/Pictures/Background.jpg��6   .��5      � .+�5   
    � -   5          �Name$ 	MainFrame��5      $��Stretch=�6#     � NavigationUIVisibility$ Hidden=�6F   	  � JournalOwnership$	 OwnsJournal=�6f   $��0q�6�   
  � Source$#
 UserManagement/LoginPage.xaml?�6�   $   RTM.UserControls.NavigationBar  5   
   -   5          Name$ NavBar��5   `   $��56��6)   $��	48,8,12,0q�65   $	��Top=�6H   6`   �� 5      -   5         ��Name$ DateTIme��5      $
��Wrap=�6#   $��18.667(�67   $%��/RTM;component/Fonts/#B Nazanin)�6I   
������� �� TextAlignment$ Right=�6�   $��0,16.576,0,0q�6�   $
��Left=�6�   $	��Top=�6�   $��73��6�   $y�	Collapsed=�6�   �� 6   �� FlowDirection$ RightToLeft=�6   � Language$ fa-ir�6+  �6<  �� *Date+ �� 	Converter# [   �� ElementName$
 Page��6�  �� 5   
   -   5        $��button1��5   �   ���	#FF686868$��0q�6(   $��24(�6<   $��Arial)�6J   
���   �$��32��6q   $��	10,10,0,0q�6}     GlassButton#���  6�   $��32��6�   $
��Left=�6�   $	��Top=�6  .��6  ؟5      5      5      