   M S B A M L   `   `   `  ����I  EPlanner.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Planner.Client.View.PagesPlanner.Client.View.Pages  5      .    (Planner.Client.View.Pages.CalculatorPage   5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Planner.Client.View.Pages     5        N� Title$  CalculatorPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��250 �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��1��6%      MahApps.Brushes.Gray1#���   62   .+�5      �� $��Assign Subject��6   $��Center=�6-   $��28(�6H   $��Segoe UI Semilight)�6V   
�������6v   �� 5      $��Subject��6   $��Center=�6&   
�������6A   �� 5      $	��230��6   $
��Left=�6#   $��5,0,5,0q�6>    �� DisplayMemberPath$ SubjectName��5      ��5      �� *
Subjects+ �� SelectedItem 5      �� *SelectedSubject+ �� Mode$ TwoWay=��� 5!      $��Result��6   $��4��6%   $��Center=�62   $��0,0,0,0q�6M   
�������6^   �� 5"      $	��230��6   $
��Left=�6#   $��5,0,5,0q�6>   ��6O   �� *Grades+ 5#      �� *SelectedSubjectGrade+$ TwoWay=�)  #MahApps.Metro.Controls.ToggleSwitch  5%      $��Repeat?��6   $	��230��61   $
��Left=�6=   $��5,10,5,0q�6X   
�������   IsOn 6}   �� *
IsRepeat+  5'      $��Enhancement?��6   $	��230��66   $
��Left=�6B   $��5,0,5,0q�6]   
������� 6�   �� *IsEnhancement+�� 5)        MahApps.Styles.Button.Flat#���  6   $	��Add��6J   $	��100��6Y   $��	0,20,15,0q�6e   $��Right=�6x   ��6�   �� *
AddCommand+�� 5+      $��10q�6   �� 5-      $��Filters��6   $��Center=�6&   $��28(�6A   $��Segoe UI Semilight)�6O   
�������6o   �� 50      $��Level��6   $��Center=�6$   
�������6?   �� 51      $	��230��6   $
��Left=�6"   $��5,0,5,0q�6=   ��52      �� *
FilterYear+$ TwoWay=�  55      $	��230��6   $
��Left=�6+   $��5,0,5,0q�6F   
�������$��	All Years��6j    6~   �� *
IsAllYears+�� 58      #���  6   $	��Set��6J   $	��100��6Y   $��	0,20,15,0q�6e   $��Right=�6x   ��6�   �� *ResetFiltersCommand+�� 5:      $��10q�6   �� 5<      $��	Total GPA��6   $��Center=�6(   $��28(�6C   $��Segoe UI Semilight)�6Q   
�������6q   �� 5>      $��Center=�61   $��28(�6L   $��Consolas)�6Z   
�������$��10,0,0,0q�6�   ��6   �� *
TotalGPA+6�   5@      &   System.Windows.Controls.DataGrid  5C   
   $��1��6   $��0��6       AutoGenerateColumns$ False��5F         
IsReadOnly$
 True��5G      $��Stretch=�5H      ��5D      �� *DisplayedScores+ 5E      �� *SelectedSubject+$ TwoWay=�	   Columns	 5J      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Index��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Index+6N     5O      $

 Code��6%   $ * 6L    63   �� *Code+6L     5R      $
 Subject��6%   $ * 6R    66   �� *	Subject+6R   4  .System.Windows.Controls.DataGridCheckBoxColumn  5U      $
 Repeat��6)   $
 Auto 6T    69   �� *Repeat+6T     5X      $
 Enhancement��6)   $
 Auto 6^    6>   �� *Enhancement+6^     5[      $
 Grade��6%   $
 Auto 6W    64   �� *GradeDisplayed+6W     5^      $
 Credits��6%   $ * 6R    66   �� *	Credits+6R     5a      $
 Weight��6%   $
 Auto 6P    65   �� *Weight+6P   5c      �� 5f   
   $��0��6   $��2��6"   ���	#FFD6E9F9 �� Orientation$ 
Horizontal=�6M   .+�5g      �� $��5,5,0,5q�6   $	��100��6&    # MahApps.Styles.Button.Hamburger#���  62   ���	#19D5D5D5��6l   �� *CalculateCommand+.��5h      �� $ Vertical=�6   .+�5i      �� $5��//Assets/InterfaceIcons/icons8-calculator-64.png��6   $��32��6U   $��32��6`   �� 5j      $��
 Calculate��6    $��12(�62   5k      5l      �� 5m      ���	#7FA9A9A9$��0,5,0,5q�6/   #��["�6@   �� 5n      $��1,5,0,5q�6   $	��100��6&   #���  62   ���	#19D5D5D5��6l   �� *RemoveCommand+.��5o      �� $ Vertical=�6   .+�5p      �� $1��+/Assets/InterfaceIcons/icons8-remove-64.png��6   $��32��6Q   $��32��6\   �� 5q      $�� Remove��6    $��12(�6/   5r      5s      �� 5t      $��1,5,0,5q�6   $	��100��6&   #���  62   ���	#19D5D5D5��6l   �� *ResetFiltersCommand+.��5u      �� $ Vertical=�6   .+�5v      �� $0��*/Assets/InterfaceIcons/icons8-reset-64.png��6   $��32��6P   $��32��6[   �� 5w      $�� Reset ��6    $��12(�6/   5x      5y      �� 5z      $��1,5,0,5q�6   $	��100��6&   #���  62   ���	#19D5D5D5��6l   �� *SaveCommand+.��5{      �� $ Vertical=�6   .+�5|      �� $/��)/Assets/InterfaceIcons/icons8-save-64.png��6   $��32��6O   $��32��6Z   �� 5}      $�� Save ��6    $��12(�6.   5~      5      5�      5�      5�      