   M S B A M L   `   `   `  ����E  ALogWindow., Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogWindow.ViewModelsLogWindow.ViewModels  5      C&clr-namespace:LogWindow.Views.ControlsLogWindow.Views.Controls  5      &     LogWindow.Views.LoggerWindowView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5	      @d2http://schemas.microsoft.com/expression/blend/2008     5
      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9
viewModels"clr-namespace:LogWindow.ViewModels     5      ;controls&clr-namespace:LogWindow.Views.Controls     5      -   5          �Name$  Window��5      $	��450��5      $	��800��5       � WindowStyle$ 
ToolWindow=�5       � SizeToContent$ WidthAndHeight=�5       � 	Resources 5       �� MergedDictionaries �� Source �� Color   SecondBackground�� 5   
    5      �� 5      $P Jpack://application:,,,/GENPRO_Design;component/GenproDesignDictionary.xaml?�6%   �� 5      $7 1DataTemplates/DataTemplateResourceDictionary.xaml?�6%   %0   &	        �� 5      $ #BDBDBD��6   6.   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5!   
   ��  K� ZIndex$ 0��6   $��0��5"        GenproWindowHeader#��[ 5#      � 5%   
   $��
32,0,32,32q�6   $��1��6#    5&      �� 5'      $
��Auto �6    �� 5(      $��* �6    .+�5+      �� $��24(�5,      $��0,0,0,16q�5-      	 �� Padding$	 0q�5.      ��5/      �� *Title+�� 51        PrimaryHueDarkBrush#��[ 52      #���   53      
 �� CornerRadius$
 8��54      $��1��55      ._�56      �  � ColumnDefinitions 57      �� 58      �� 59      $��1 �6+   �� 5:      $
��Auto �6+   .+�5=      �� $��16,16,12,16q�6L   ��6#   �� */+ �� Path$ Messages���5>      �� 5?      .R�5@   "   �� .��5A   &   �� 5B   #   5C      5E      �� 5H      #��[ 5I      $��1��5J      $
��0,16q�5K      /   )LogWindow.Views.Controls.SimpleStackPanel  5M      $��2��5N      $��16q�5O         Spacing$ 8Q�5P      .+�5Q      �� $%��Показать элемент��6#    d� 	IsChecked 6>   �� *IsShowElement+�� 5S      $(��"Открыть в блокноте��5U      $��36��5V      $
��auto��5W      ��5T      �� *OpenNotepadCommand+5W      5X      5Y      5Z      5[      5\      5]      