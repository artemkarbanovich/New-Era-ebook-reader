   M S B A M L   `   `   `  ����G  CEbook Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Ebook_Reader.ViewEbook_Reader.View  5   	   *    $Ebook_Reader.View.AuthenticationView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:Ebook_Reader.View  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Icon$ ../Image/AppIcon.png��5
   	    � Title$ Вход��5   	   $	��400��5   	   $	��450��6    � 
ResizeMode$ NoResize=�6"    � 	Resources 5         validationFailed��%f   &	        �� 5   
   .R�5      �� 
��� E��$	��1.5q�6-   ._�5      �� 5      5      5      .��5      � ���#BAD899 � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��90 �6   �� 5      $��25 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��35 �6   �� 5       � ColumnDefinitions 5!   
   �� 5"      �� 5#      �� 5$      .+�5(   
   �� $��../Image/AppLogo.png��6   $��1��6.   $��1��6;   � 5*   
   $��3��6   $��3��6   .+�5+      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5,      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Person=�6*   $��25��68   $��25��6C   $��Center=�6O   $��0,0,5,0q�6j   �� 5-      	 =� ErrorTemplate#	 [  6r   $��15(�6�   $	��300��6�   ���#84B153.  (MaterialDesignThemes.Wpf.TextFieldAssist
   UnderlineBrush
 �#4A751C)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6A   �� 
CaretBrush
 �   �$��4q�6{  ��6   �� *Login+ �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=� � ToolTip 6�   �� *ErrorCollection[Login]+6{  5.      5/      � 51   
   $��5��6   $��3��6   .+�52      �� $ 
Horizontal=�6   $��Center=�62   .+�53        $ Password=�6*   $��25��6:   $��25��6E   $��Center=�6Q   $��0,0,5,0q�6l   G� 54      -   5        $ Пароль��54      #	 [  6�   $	��300��6  $��15(�6*  ���#84B153
 �#4A751C G� 
CaretBrush
 �   �$��4q�6�  
 � Tag 6F   �� *PasswordExtra+ .  6�   �� * ErrorCollection[PasswordExtra]+6�  55      56      � 58   
   $��6��6   $��3��6   .+�59      �� $��Center=�6   $��14(�63    �� TextAlignment$ Center=�6A   ��6X   �� *NotificationColor+��6�   �� *NotificationText+5:      � 5<   
   $��7��6   $��1��6   .+�5=      �� $��
Войти��60   $��15(�6@   ���#4A751C��6   �� *signIn+��6c   Z� 5>      � 5@   
   $��9��6   $��2��6   $��Center=�6,   .+�5A      �� $	��120��6   $��Регистрация��6B   $��15(�6X   
���������6!   �� *signUpWindow+��6g   Z� ��6�   Z� +  %MaterialDesignThemes.Wpf.RippleAssist   Feedback 6�   Z� 5B      5C      5D      