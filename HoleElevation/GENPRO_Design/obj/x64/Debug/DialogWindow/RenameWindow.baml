   M S B A M L   `   `   `  ����H  DGENPRO_Design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GENPRO_Design.DialogWindowGENPRO_Design.DialogWindow  5      -    'GENPRO_Design.DialogWindow.RenameWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GENPRO_Design.DialogWindow     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $	��330��5	      $	��170��5
        � WindowStartupLocation$  CenterScreen=�5      ���#002d87 � Title$ Новое имя��5         GenproWindowStyle#���   5       � 	Resources 5       �� Source�� 5   
   $P Jpack://application:,,,/GENPRO_Design;component/GenproDesignDictionary.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6-   �� 5      $��75 �6   6*   �� 5      $
��auto �6   $��25��6*   6;   �� 5      $
��auto �6   $��35��6*   6;   .+�5   
   ��   GenproWindowHeader#��[ 6   � 5   
   $��1��6   $��	10,10,0,0q�6    � ColumnDefinitions 5      �� 5       $��75 �6#   60   �� 5!      $	��235 �6#   61    5#      �� 5$      $��30 �6    6.   �� 5%      $��35 �6    6.   .+�5'      �� $��0��5(      $��Center=�5)      .��5*      Старое имя:6   �� 5+      -   5         ��Name$ TextBlockOldName��5,      $��0��5-      $��1��5.      $��Italic$�5/      
���OO/�$��Center=�51      $��5,1,0,0q�52      6$   �� 54      $��1��55      $��Center=�56      .��57      Новое имя:6   �� 58      -   5         ��Name$ TextBoxNewName��59      $��1��5:      $��1��5;      $��Center=�5<      $��25��5>      $��5q�6   6+   5?      �� 5@   
   -   5        $ labelErrorWrite��5A      
���\\��$��11(�5C      $��Italic$�5D      $��2��5E      $
��auto��5F      $��	15,5,5,10q�5G      $
��Wrap=�5H      6#   � 5J   
   $��4��6   $��1��6   $
��auto��6,   $��Right=�69    5K      �� 5L      $
��auto �6#   62   �� 5M      $
��auto �6#   62   .+�5P      �� -   5         ��Name$ ButtonApply��5Q        GenproButtonMain#��[ 5R      $��0��5S      $	��100��5T      $��25��6   $��5q�6)   $��11(�5U      $��Right=�5V      	 � Cursor$
	 Hand��5W   +   .��5X      Применить6   �� 5Y      -   5        $ ButtonCancel��5Z      $��1��5[      $��90��5\      $��25��6   $��5q�6(   $��11(�5]      $��Right=�5^      .��5_   ,   Отмена64   5`      5a      5b      