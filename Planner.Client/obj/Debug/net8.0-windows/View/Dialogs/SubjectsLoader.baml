   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   I EPlanner.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Planner.Client.View.DialogsPlanner.Client.View.Dialogs 5   	   0   *Planner.Client.View.Dialogs.SubjectsLoader   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   ;local)clr-namespace:Planner.Client.View.Dialogs     5   	     � Title$  Subjects Loader��5	   	   $	��450��6!   $	��270��6.    � WindowStyle$ 
ToolWindow=�6:    � 
ResizeMode$ NoResize=�6S   .��5
      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��25 �6    � ColumnDefinitions 5   
   �� 5      $	��270 �6   �� 5      $	��530 �6   .+�5   
   ��    MahApps.Brushes.Gray1#���   6   $��0��6J   $��0��6Z   .+�5      ��  # MahApps.Styles.Button.Hamburger#���  6   $	��270��6O   $��45��6[   $��0,0,0,0q�6g   $
��Left=�6�   ��6x   �� *Goto_SubjectsCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   $	��250��66   .+�5      �� $+��%/Assets/Icons/icons8-open-file-48.png��6   $��35��6K   $��35��6V   �� 5      $��	From File��6   $��10,0,0,0q�60   
�������$��16(�6U   $	��215��6c   5      5      �� 5      -   5        #���  5      $	��270��6O   $��45��6[   $��0,0,0,0q�6g   $
��Left=�6�   ��6x   �� *Goto_CalculatorCommand+.��5      �� $ 
Horizontal=�6   $	��250��66   .+�5      �� $)��#/Assets/Icons/icons8-library-48.png��6   $��35��6I   $��35��6T   �� 5      $��	Templates��6   $��10,0,0,0q�60   
�������$��16(�6U   $	��215��6c   5      5       �� 5!      #���  6   $	��270��6O   $��45��6[   $��0,0,0,0q�6g   $
��Left=�6�   ��6x   �� *Goto_PlannerCommand+.��5"      �� $ 
Horizontal=�6   $	��250��66   .+�5#      �� $(��"/Assets/Icons/icons8-backup-48.png��6   $��35��6H   $��35��6S   �� 5$      $��Backups��6   $��10,0,0,0q�6.   
�������$��16(�6S   $	��215��6a   5%      5&      �� 5'      #���  6   $	��270��6O   $��45��6[   $��0,0,0,0q�6g   $
��Left=�6�   ${�False��6�   ��6x   �� *Goto_TeachingCommand+.��5(      �� $ 
Horizontal=�6   $	��250��66   .+�5)      �� $6��0/Assets/Icons/icons8-cloud-backup-restore-48.png��6   $��35��6V   $��35��6a   �� 5*      $��Cloud��6   $��10,0,0,0q�6,   
�������$��16(�6Q   $	��215��6_   5+      5,      5-      �� 5/   
   $��1��6   $��0��6"     MahApps.Brushes.Gray2#���  6/   51      �� 53   
   $��1��6   $��2��6"     MahApps.Brushes.Accent#���  66   54      56      