   M S B A M L   `   `   `  ����H  DGENPRO_Design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GENPRO_Design.DialogWindowGENPRO_Design.DialogWindow  5      1    +GENPRO_Design.DialogWindow.CommonInfoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GENPRO_Design.DialogWindow     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $	��300��5
      $
��auto��5      $	��150��5      $	��500��5        � WindowStartupLocation$  CenterScreen=�5       � Title$ Новое имя��5         GenproWindowStyle#���   5       � Cursor$
 Hand��6:    � 	Resources 5       �� Source�� 5   
   $P Jpack://application:,,,/GENPRO_Design;component/GenproDesignDictionary.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      $
��auto �6   6.   �� 5      $
��auto �6   6.   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5       6%   �� 5!      6%   .+�5$      ��  K� ZIndex$ 0��6     GenproWindowHeader#��[ 5%      $��4��5&      �� 5(      -   5         ��Name$ ButtonClose��5.      $��1��5(      $ 2��5)      $��30��5*      $��30��5+      $��5q�5,      $��Right=�5-        GenproButtonClose#��[ 50      $
 Hand��6@   51      � 52   
   $��1��6   $��15q�6   $	��400��6(    53      �� 54      $
��Auto �6#   62   �� 55      6%   .+�58      �� -   5        	 ��Name$	 IconStatusType��59      $��0��5:      $��0 0 15 0q�5;      $��35��5<      $��35��5=      � 5?      $��1��6    5@      �� 5A      6&   �� 5B      $
��auto �6$   64   .+�5E      �� -   5        
 ��Name$
 TextBlockContent��5E       ) %MaterialDesignComboBoxEditableTextBox#��[ 5F      $��0��5G       �� 
IsReadOnly . $
��Auto=�5I       �� TextWrapping$
 Wrap=�5J      $��Center=�5K      .��61   XV"Элемент не найден, попробуйте ввести другой id."5M      �� 5O      -   5         ��Name$ TextBlockCaption��5P      $��1��5Q      $��11(�5R      $��Italic$�5S      $��0,15,0,0q�5T      
�����p�$
��Wrap=�5V      $�� ��5W      ��5X      �� 5Y       �� 
TargetType" ��6     �� Triggers 5Z      P� 5[   "    P� Property � �� P� Value$  ��6:   . �5\   &   ��  �� Property � y� �� Value$ 	Collapsed=�6C   5]   #   5_      5a      5c      5d      �� 5e   
   -   5        $ ButtonClosed��5f      $��2��5g      $��10q�5h      $��11(�5i      $��80��5j      $��25��5k      $
 Hand��5l   '   .��65   Закрыть5n      5o      5�      