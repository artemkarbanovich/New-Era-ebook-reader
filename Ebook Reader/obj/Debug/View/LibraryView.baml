   M S B A M L   `   `   `  ����G  CEbook Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Ebook_Reader.ViewEbook_Reader.View  5      #    Ebook_Reader.View.LibraryView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      +localclr-namespace:Ebook_Reader.View  5      .��5      �    MainPannel_Color#���   6     � RowDefinitions  5   
   �� 5      $��0 �6   �� 5      $��30 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��1.2* �6   �� 5      $
��1.1* �6   �� 5      $
��1.3* �6   �� 5      $
��0.1* �6   �� 5      $
��1.3* �6   �� 5      $��2* �6   .+�5   
   � $
��Left=�6   $��0��6*   $��0��67   $��	0,-50,0,0q�6G     Top-leftPannel_Color#���  6Z   .+�5      �� $
��Left=�6g   ��6   �� *addBookToLibrary+��6:   Z� ��6Q   Z� +  %MaterialDesignThemes.Wpf.RippleAssist   Feedback 6�   Z� .��5      ��  �� Orientation$ 
Horizontal=�6   $��0��66   $��0��6C   $��Center=�6S   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�6.      Kind$
 Plus=�6I   $��18��6U   $��18��6a     AddBook_Color#���  6l   �� 5        Font#���  6    $!��Добавить книгу��6D   $��13(�6Z   $��4,0,0,0q�6h   #���  6y   5       5!      5"      � 5$   
   $
��Left=�6   $��0��6*   $��1��67   $��	0,-50,0,0q�6G   #���  6Z   .+�5%      �� $
��Left=�6l   ��6   �� *deleteBookFromLibrary+��6?   Z� ��6V   Z�  6�   Z� .��5&      �� $ 
Horizontal=�6   $��0��66   $��0��6C   $��Center=�6S   .+�5'        $��Center=�6.   $ Delete=�6I     DeleteBook_Color#���  6W   $��18��6�   $��18��6�   �� 5(      $��Удалить книгу��6    #���  65   $��13(�6Y   $��4,0,0,0q�6g   #���  6x   5)      5*      5+      � 5-   
   $��0��6   $��2��6   $��	0,-50,0,0q�6,   #���  6?   .+�5.      �� #���  6     SearchBox_BgColor#���  6{   $��30��6�   $��15(�6�     SearchBox_UlColor.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush# �  6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$( "Поиск в библиотеке��6   �� 
CaretBrush
 �   �$��4q�6a  ��6:   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�6a  5/      � 51   
   $��0��6   $��4��6   $��	0,-50,0,0q�6,   #���  6?   .+�52      �� #���  6   $ Сортировка��6z   #���  6�   $��30��6�   $��15(�6�   $��4q�6�   # �  6�   	 �� Text	 6;   �� *
SortText+$ PropertyChanged=�.@�53      �� $��По умолчанию��6   �� 54      $!��По возрастанию��6   �� 55      $��По убыванию��6   �� 56      $!��Только txt файлы��6   �� 57      $!��Только pdf файлы��6   58      59      � 5;   
   $��1��6   $��6��6    5<      �� 5=      $
��3.5* �6#   �� 5>      $
��1.5* �6#   �� 5?      $��1* �6#   .+�5B      �� $��0��6     BooksBorderBrush_Color#���  6%   $��0,0,1.5,1.5q�6\   ._�5C      �� #���  6   $��0��6@   $��Center=�6P   $
��Bold"�6k   $
��Left=�6}     BooksList_Color#���  6�   $��18,0,0,0q�6�   $��16(�6�   $!��Название книги��6�   5D      �� 5E      $��1��6   #���  6%   $��0,0,1.5,1.5q�6\   ._�5F      �� #���  6   $��1��6@   $��Center=�6P   $
��Bold"�6k   $��Center=�6}   #���  6�   $��16(�6�   $#��Дата добавления��6�   5G      �� 5H      $��2��6   #���  6%   $��	0,0,0,1.5q�6\   ._�5I      �� #���  6   $��2��6@   $��Center=�6P   $
��Bold"�6k   $��Center=�6}   #���  6�   $��16(�6�   $��Формат книги��6�   5J      5K      � 5M   
   $��2��6   $��6��6   .+�5N      �� ��.  $��Stretch=�6<   ��6a   �� *FilteredBooks+$ Explicit=�
 �� SelectedItem
 6�   �� *Book+.  (System.Windows.Interactivity.Interaction   Triggers 5O      /  )System.Windows.Interactivity.EventTrigger  5P         	EventName$ MouseDoubleClick��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5Q      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *openDocumentReader+5R      ��5T      �� 5U      .R�5V      �  5W      �� 5X   "   $
��3.5* �63   �� 5Y   "   $
��1.5* �63   �� 5Z   "   $��1* �63   .+�5^      �� $��Center=�6)   $��0��6D   .+�5_   "   �� #���  6,   $
��Left=�6P   $��10,0,0,0q�6k   #���  6}   $��14(�6�   ��6�   ��  �� Path$
 Name�5`      �� 5a      $��Center=�6)   $��1��6D   .+�5b   "   �� #���  6,   #���  6P   $��Center=�6   $��14(�6�   ��6�   �� $ 	DateAdded� �� StringFormat$ dd.MM.yyyy HH:mm��5c      �� 5d      $��0��6)   $��Center=�66   $��2��6Q   .+�5e   "   �� #���  6,   $��Center=�6P   #���  6m   $��14(�6�   ��6�   �� $ 
BookFormat�5f      5h      5i      5k      5l      5m      5n      