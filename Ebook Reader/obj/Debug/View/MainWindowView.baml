   M S B A M L   `   `   `  ����G  CEbook Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Ebook_Reader.ViewEbook_Reader.View  5   	   &     Ebook_Reader.View.MainWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:Ebook_Reader.View  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Icon$ ../Image/AppIcon.png��5
   	    � Title$ New Era��5   	   $	��600��5   	   $
��1200��6   $	��600��6)   $
��1200��66   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��160 �6   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   �    Top-leftPannel_Color#���   6   $��0��6C   $��0��6P   $��4��6`    5      �� 5      $	��160 �6#   �� 5      �� 5      �� 5      .+�5!      �� $��70��6   $$��../Image/AppLogoMainWindow.png��6    5"      � 5$   
   $��1��6   #���   6    5%      �� 5&      $��10 �6    �� 5'      $��35 �6    �� 5(      $��35 �6    �� 5)      $��35 �6    �� 5*      .+�5.      � $��1��6   $	��160��6    .+�5/      �� $��Library��6?   $��10,0,0,0q�6Z   $
��Left=�6�   ��6   �� *UpdateViewCommand+��6m   Z� ��6�   Z� .��50      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   .+�51      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Library=�62     NavigationText_Color#���  6A   $��20��6u   $��20��6�   �� 52        Font#���  6$   $
��15.5(�6H   $��Библиотека��6X   #���  6j   $��7,0,0,0q�6�   53      54      55      � 56      $��2��6   $	��160��6    .+�57      �� $��
Statistics��6?   $��10,0,0,0q�6]   $
��Left=�6�   ��6   �� *UpdateViewCommand+��6p   Z� ��6�   Z� .��58      �� $ 
Horizontal=�6!   $��Center=�6:   .+�59        $ ChartAreaspline=�62   #���  6I   $��20��6}   $��20��6�   �� 5:      #���  6$   $
��15.5(�6H   $��Статистика��6X   #���  6j   $��7,0,0,0q�6�   5;      5<      5=      � 5>      $��3��6   $	��160��6    .+�5?      �� $��Settings��6?   $��10,0,0,0q�6[   $
��Left=�6�   ��6   �� *UpdateViewCommand+��6n   Z� ��6�   Z� .��5@      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5A        $ Settings=�62   #���  6B   $��20��6v   $��20��6�   �� 5B      #���  6$   $
��15.5(�6H   $��Настройки��6X   #���  6i   $��7,0,0,0q�6�   5C      5D      5E      � 5F      $��4��6   $��Bottom=�6    $��35��6;   $	��160��6G   .+�5G      �� $��10,0,0,0q�6:   $
��Left=�6z   ��6   �� *aboutProgram+��6M   Z� ��6d   Z� .��5H      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5I        $ About=�62   #���  6?   $��20��6s   $��20��6~   �� 5J      #���  6$   $
��15.5(�6H   $��О программе��6X   #���  6k   $��7,0,0,0q�6�   5K      5L      5M      5N      � 5P   
   $��3��6   .+�5Q      �� $��30��6   $��0,0,0,7q�6%   $��Right=�66   $ 
Horizontal=�6R   $��Center=�6k   .+�5R        $��Center=�6*   #���  6E   $ Account=�6y   $��20��6�   $��20��6�   �� 5S      $��Center=�6   #���  68   $��17(�6\   #���  6j   $��3,0,20,0q�6�   ��6�   �� *
User.Login+6�   5T      �� 5U      #���  60   $��Bottom=�6�   $��
выйти��6�   $��29��6�   $��80��6�   $��Right=�6�     LogOutText_Color#���  6  $��0,0,0,0q�6?  ��6   �� *logOut++  %MaterialDesignThemes.Wpf.RippleAssist   Feedback 6T   Z� ��6�   Z� ��6�   Z� 6?  5V      � 5X   
     MainPannel_Color#���  6   $��1��6?   $��1��6L   $��3��6\   .+�5Y      �� ��6   �� *SelectedViewModel+5Z      5[      5\      