   M S B A M L   `   `   `  ����H  DGENPRO_Design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:GENPRO_Design.DialogWindowGENPRO_Design.DialogWindow  5      8    2GENPRO_Design.DialogWindow.GenproProgressBarWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:GENPRO_Design.DialogWindow     5      -   5        $
��auto��5      $	��400��6     � WindowStartupLocation$  CenterScreen=�5	       � Title$' !Процесс выполения��5         GenproWindowStyle#���   5       � 	Resources 5       �� Source�� 5   
   $P Jpack://application:,,,/GENPRO_Design;component/GenproDesignDictionary.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   ��   GenproWindowHeader#��[ 6   � 5   
   $��1��6   .+�5      � -   5         �Name$ progressBar��5      $��1��5      
�������
�������$��Center=�5       $
��Left=�5!      $��0q�5"      $��5q�5#      $��25��5$      $	��385��5%      5&      �� 5'      -   5         ��Name$ TextBlockProgressBar��5)      $��Center=�5'      $��Center=�5(      5*      5+      �� 5,   
   -   5        $ 
messageLbl��5.      $��2��5-      $��5q�5/      $	��385��50      $
��Wrap=�51      $
��Left=�52      $��Center=�53      $��11(�54      $0��*Подождите пожалуйста...��55      $��Italic$�56      
�������
���iii�58   $   �� 59   
   -   5         ��Name$ ButtonCancel��5:      $��3��5;      $��	5,5,10,10q�5<      $��11(�5=      $��80��6   $��25��6&   $��Right=�5?      .��6)   Отмена5A      5B      5C      