   M S B A M L   `   `   `  ����H  DGENPRO_Design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GENPRO_Design.DialogWindowGENPRO_Design.DialogWindow  5      1    +GENPRO_Design.DialogWindow.CreateNameWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GENPRO_Design.DialogWindow     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $	��360��5
      $	��150��5        � WindowStartupLocation$  CenterScreen=�5       � Title$ Новое имя��5         GenproWindowStyle#���   5       � 	Resources 5       �� Source�� 5   
   $P Jpack://application:,,,/GENPRO_Design;component/GenproDesignDictionary.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6-   �� 5      $��50 �6   6*   �� 5      $
��auto �6   $��30��6*   6;   �� 5      $
��auto �6   $��40��6*   6;   .+�5   
   ��   GenproWindowHeader#��[ 6   � 5    
   $��1��6   $��5,0,0,0q�6    � ColumnDefinitions 5!      �� 5"      $��75 �6#   60   �� 5#      $	��220 �6#   61    5%      �� 5&      $��40 �6    6.   .+�5(      �� $��Center=�5)      .��5*      Новое имя:6   �� 5+      -   5         ��Name$ TextBoxNewName��5,      $��1��5-      $��Center=�5.      $��25��50      $	��210��6   $��0q�6)   67   51      �� 52   
   -   5         ��Name$ LabelErrorWrite��53      
���\\��$��11(�55      $��Italic$�56      $��2��57      $
��auto��58      $
��Wrap=�59      $��5q�5:      6   � 5<   
   $��3��6   $
��auto��6   $��Right=�6)    5=      �� 5>      $
��auto �6#   62   �� 5?      $
��auto �6#   62   .+�5B      �� -   5         ��Name$ ButtonApply��5C        GenproButtonMain#��[ 5D      $��11(�5E      $��0��5F      $
��auto��5G      $��25��5H      $��5q�5I      $��Right=�5J      .��6G   Применить6R   �� 5L      -   5        $ ButtonCancel��5M      $��1��5N      $
��auto��5O      $��25��5P      $��5q�5Q      $��11(�5R      $��Right=�5S      .��6H   Отмена6P   5T      5U      5V      