   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   I EPlanner.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Planner.Client.ViewPlanner.Client.View 5   	   E'clr-namespace:Planner.Client.BehavioursPlanner.Client.Behaviours 5   	   %   Planner.Client.View.ShellWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   3local!clr-namespace:Planner.Client.View     5   	   9behav'clr-namespace:Planner.Client.Behaviours     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	   	   $	��768��5   $   $
��1366��61     � Icon$1  +/Assets/WindowIcons/GPAPlanner_darkIcon.ico��6>    � Title 6	   �� *
AppTitle+(   "MahApps.Metro.Controls.MetroWindow   Flyouts 5      +   %MahApps.Metro.Controls.FlyoutsControl  5   
   .@�5      #   MahApps.Metro.Controls.Flyout  -   5          Name$ FirstFlyout��5         Position$
 Left=�6R   $	��250��6b   ��6.   �� *CurrentPageTitle+   IsOpen 6n   �� *
IsMenuOpen+.��5      �� $��0,10,0,0q�6   .+�5      ��  #  MahApps.Styles.Button.Hamburger#���   6   $	��200��6W   $��45��6c   $��10,0,0,0q�6o   ��6�   �� *Goto_SubjectsCommand+.��5      ��  �� Orientation$ 
Horizontal=�6%   $	��250��6>   .+�5      �� $&�� /Assets/Icons/icons8-book-48.png��6$   $��35��6N   $��35��6Y   �� 5      $��Subjects��6$   $��10,0,0,0q�67   
�������$��16(�6\   $	��215��6j   5      5      �� 5      #���   6   $	��200��6W   $��45��6c   $��10,0,0,0q�6o   ��6�   �� *Goto_CalculatorCommand+.��5      �� $ 
Horizontal=�6%   $	��250��6>   .+�5      �� $,��&/Assets/Icons/icons8-calculator-48.png��6$   $��35��6T   $��35��6_   �� 5      $��
Calculator��6$   $��10,0,0,0q�69   
�������$��16(�6^   $	��215��6l   5      5      �� 5      #���   6   $	��200��6W   $��45��6c   $��10,0,0,0q�6o   ��6�   �� *Goto_PlannerCommand+.��5       �� $ 
Horizontal=�6%   $	��250��6>   .+�5!      �� $)��#/Assets/Icons/icons8-planner-50.png��6$   $��35��6Q   $��35��6\   �� 5"      $��Planner��6$   $��10,0,0,0q�66   
�������$��16(�6[   $	��215��6i   5#      5$      �� 5%      #���   6   $	��200��6W   $��45��6c   $��10,0,0,0q�6o   ��6�   �� *Goto_TeachingCommand+.��5&      �� $ 
Horizontal=�6%   $	��250��6>   .+�5'      �� $*��$/Assets/Icons/icons8-teaching-50.png��6$   $��35��6R   $��35��6]   �� 5(      $
��STXT��6$   $��10,0,0,0q�63   
�������$��16(�6X   $	��215��6f   5)      5*      5+      5,      5-      .��50      �  � RowDefinitions 51   
   �� 52      $��25 �6   �� 53      $��* �6   .+�55   
   �� $ 
Horizontal=�6     MahApps.Brushes.Accent#���  6.   .+�56      ��  * &MahApps.Styles.Button.MetroWindow.Base#���  6   $��80��57      $��25��6   ���	#FF3393DF
�������$
��Home��6S   ��56   V   �� *OpenMenuCommand+59      �� 5:      #���  6   $��80��5;      $��25��6   ���	#FF3393DF
�������$��
Calculator��6R   ��6g   �� *Goto_CalculatorCommand+*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5<      1 +Planner.Client.Behaviours.ButtonHighlighter  5=      	   SelectedBackground
	 �����  MahApps.Brushes.Gray1
   SelectedForeground#
 �  6I      	IsDefault$
 True��6�   5?      �� 5@      #���  6   $��80��5A      $��25��6   ���	#FF3393DF
�������$��Subjects��6R   ��5@   V   �� *Goto_SubjectsCommand+ 5B        5C      
	 �����#
 �  6I   5E      �� 5F      #���  6   $��80��5G      $��25��6   ���	#FF3393DF
�������$��Planner��6R    5H        5I      
	 �����#
 �  6I   5K      �� 5L      #���  6   $��80��5M      $��25��6   ���	#FF3393DF
�������$
��STXT��6S    5N        5O      
	 �����#
 �  6I   5Q      �� 5R      #���  6   $��80��5S      $��25��6   ���	#FF3393DF
�������$	��VLE��6S   ��6b   �� *Goto_VLECommand+ 5T        5U      
	 �����#
 �  6I   5W      �� 5X      #���  6   $��80��5Y      $��25��6   ���	#FF3393DF
�������$��Drawer��6S   ��6e   �� *Goto_DrawerCommand+ 5Z        5[      
	 �����#
 �  6I   5]      5^      8   2MahApps.Metro.Controls.TransitioningContentControl  5b   
   -   5          Name$ PageFrameHolder��5b   *   $��1��6C      
Transition$
 Left=�6Q   .��5c       �   � NavigationUIVisibility$ Hidden=�64   ��6   �� *CurrentPage+64   5d      5e      5f      