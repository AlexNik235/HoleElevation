   M S B A M L   `   `   `  ���� H  DGENPRO_Design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GENPRO_Design.DialogWindowGENPRO_Design.DialogWindow  1    +GENPRO_Design.DialogWindow.CommonInfoWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:GENPRO_Design.DialogWindow     _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -   $	��300��$
��auto��$	��150��$	��500��  � WindowStartupLocation$  CenterScreen=� � Title$ Новое имя��   GenproWindowStyle#���    � Cursor$
 Hand�� � 	Resources  �� Source�� $P Jpack://application:,,,/GENPRO_Design;component/GenproDesignDictionary.xaml?�%    .���  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+�� $��0�� � ColumnDefinitions �� �� .+���  K� ZIndex$ 0��  GenproWindowHeader#��[ $��4���� -    ��Name$ ButtonClose��$��1��$ 2��$��30��$��30��$��5q�$��Right=�  GenproButtonClose#��[ $
 Hand��� $��1��$��15q�$	��400�� �� $
��Auto ��� .+��� -   	 ��Name$	 IconStatusType��$��0��$��0 0 15 0q�$��35��$��35��� $��1�� �� �� $
��auto �.+��� -   
 ��Name$
 TextBlockContent�� ) %MaterialDesignComboBoxEditableTextBox#��[ $��0�� �� 
IsReadOnly . $
��Auto=� �� TextWrapping$
 Wrap=�$��Center=�.��XV"Элемент не найден, попробуйте ввести другой id."�� -    ��Name$ TextBlockCaption��$��1��$��11(�$��Italic$�$��0,15,0,0q�
�����p�$
��Wrap=�$�� ������  �� 
TargetType" �� �� Triggers P�  P� Property � �� P� Value$  ��. ���  �� Property � y� �� Value$ 	Collapsed=��� -   $ ButtonClosed��$��2��$��10q�$��11(�$��80��$��25��$
 Hand��.��Закрыть