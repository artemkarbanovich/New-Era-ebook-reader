   M S B A M L   `   `   `  ����G  CEbook Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Ebook_Reader.ViewEbook_Reader.View  5   	   (    "Ebook_Reader.View.RegistrationView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=20.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:Ebook_Reader.View  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Icon$ ../Image/AppIcon.png��5
   	    � Title$ Регистрация��5   	   $	��440��5   	   $	��450��6    � 
ResizeMode$ NoResize=�6"    � 	Resources 5         validationFailed��%f   &	        �� 5   
   .R�5      �� 
��� E��$	��1.5q�6-   ._�5      �� 5      5      5      .��5      � ���#BAD899 � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��10 �6   �� 5      $��30 �6   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��20 �6   �� 5      $��30 �6   �� 5       $��20 �6   �� 5!      $��30 �6   �� 5"      $��30 �6   �� 5#       � ColumnDefinitions 5%   
   �� 5&      �� 5'      �� 5(      .+�5,   
   � $��0��6   $��0��6   $
��Left=�6,   .+�5-      �� $��60��6c   ��6   �� *signInWindow+��66   Z� ��6L   Z� +  %MaterialDesignThemes.Wpf.RippleAssist   Feedback 6n   Z� .��5.      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6*   $��25��6;   $��25��6F   
���   �6R   5/      50      � 52   
   $��2��6   $��3��6   $��Center=�60   .+�53      �� 	 =� ErrorTemplate#	 [  6n   $��15(�6�   $	��300��6�   ���#84B153.  (MaterialDesignThemes.Wpf.TextFieldAssist
   UnderlineBrush
 �#4A751C)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6=   �� 
CaretBrush
 �   �$��4q�6w  ��6   �� *Login+ �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=� � ToolTip 6�   �� *ErrorCollection[Login]+6w  54      � 56   
   $��4��6   $��3��6   $��Center=�60   .+�57      �� #	 [  6r   $��15(�6�   $	��300��6�   ���#84B153
 �#4A751C$ Имя��6E  
 �   �$��4q�6}  ��6   �� *	FirstName+ . $ PropertyChanged=� 6�   �� *ErrorCollection[FirstName]+6}  58      � 5:   
   $��6��6   $��3��6   $��Center=�60   .+�5;      �� #	 [  6s   $��15(�6�   $	��300��6�   ���#84B153
 �#4A751C$ Фамилия��6G  
 �   �$��4q�6�  ��6   �� *
SecondName+ . $ PropertyChanged=� 6�   �� *ErrorCollection[SecondName]+6�  5<      � 5>   
   $��8��6   $��3��6   $��Center=�60   .+�5?      G� -   5         G�Name$ Password��5?   �   #	 [  6T   $��15(�6  $	��300��6  ���#84B153
 �#4A751C$ Пароль��6k   G� 
CaretBrush
 �   �$��4q�6�  
 � Tag 6   �� *PasswordExtra+ .  6�   �� * ErrorCollection[PasswordExtra]+6�  5@      � 5B   
   $��10��6   $��3��6   $��Center=�61   .+�5C      G� -   5        $ RepeatPassword��5C      #	 [  6Z   $��15(�6  $	��300��6&  ���#84B153
 �#4A751C$% Повторите пароль��6  
 �   �$��4q�6�   6   �� *RepeatPasswordExtra+ .  6�   �� *&$ErrorCollection[RepeatPasswordExtra]+6�  5D      � 5F   
   $��11��6   $��3��6   .+�5G      �� $��Center=�6   $��14(�63    �� TextAlignment$ Center=�6A   ��6X   �� *NotificationColor+��6�   �� *NotificationText+5H      � 5J   
   $��12��6   $��3��6   $��Center=�61   .+�5K      �� $��35��6   $	��190��6!   $*��$Зарегистрироваться��6H   $��15(�6e   ���#4A751C��6-   �� *signUp+��6�   Z� 5L      5M      5N      